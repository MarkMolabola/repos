
import argparse
import json
import sys
import os
import time
import re
import requests
from bs4 import BeautifulSoup
import google.genai as genai

# Fetch HTML 

def fetch_html(url, retries=3, timeout=10):
    headers = {"User-Agent": "Mozilla/5.0"}
    for attempt in range(retries):
        try:
            resp = requests.get(url, timeout=timeout, headers=headers)
            if resp.status_code == 200:
                return resp.text
            time.sleep(1)
        except requests.RequestException:
            time.sleep(1)
    return None

# Extract text from HTML
def extract_text(html):
    texts = BeautifulSoup(html, "html.parser")
    return texts.get_text(separator=" ", strip=True)


#Gemini Call
def call_gemini(api_key, text, url):
    client = genai.Client(api_key=api_key)

    prompt = f"""
You are an article summarizer. Summarize the following webpage content.
Produce exactly one paragraph, made from three short sentences.
Include at least 5 core keywords or phrases from the source (comma-separated).
Do not invent facts.

Content:
{text}
"""

    response = client.models.generate_content(
        model="models/gemini-2.5-flash",
        contents=prompt,
        config={
            "temperature": 0.2,
            "top_p": 0.9,
            "top_k": 40,
            "max_output_tokens": 3000
        }
    )

    return response.text.strip()


def parse_args():
    parser = argparse.ArgumentParser(description="One-paragraph summarizer using Gemini 2.5 Flash")
    parser.add_argument("--url", required=True, help="URL to summarize")
    return parser.parse_args()

def main():
    args = parse_args()
    url = args.url

    # Fetch HTML
    html = fetch_html(url)
    if not html:
        print(json.dumps({
            "error": "Failed to fetch URL after retries",
            "url": url
        }, indent=2))
        sys.exit(1)

    # Extract text
    text = extract_text(html)
    if not text or len(text.split()) < 50:
        print(json.dumps({
            "error": "Insufficient extractable text",
            "url": url
        }, indent=2))
        sys.exit(1)

    # API key
    api_key = os.getenv("GEMINI_API_KEY")
    if not api_key:
        print(json.dumps({"error": "Missing GEMINI_API_KEY environment variable"}))
        sys.exit(1)

    # Call Gemini
    try:
        result = call_gemini(api_key, text, url)
    except Exception as e:
        print(json.dumps({
            "error": "Gemini API call failed",
            "details": str(e)
        }, indent=2))
        sys.exit(1)

    #parse result
    

    # Get Keywords
  
    words = re.findall(r"[A-Za-z]+", text)
    long_words = [w for w in words if len(w) >= 6]
    top_keywords = long_words[:5]
    keywords_text = ", ".join(top_keywords)

    # print output
    print(f"From URL: {url}\n")

    print("Summary:")

    print(result.strip())

    print(f"\nKeywords: {keywords_text}")

    print(f"References: {url}")


if __name__ == "__main__":
    main()