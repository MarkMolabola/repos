using System.Text;

namespace Longest_Common_Prefix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = { "flower", "flow", "flight" };
            string result = LongestCommonPrefix(strings);
        }

        

            static string LongestCommonPrefix(string[] strs)
        {


            if (strs == null || strs.Length == 0) return "";

            int i = 0;
            while (true)
            {
                if (i >= strs[0].Length) break;
                char currentChar = strs[0][i];

                foreach (string word in strs)
                {
                    if (i >= word.Length || word[i] != currentChar)
                    {
                        return strs[0].Substring(0, i);
                    }
                }

                i++;
            }

            return strs[0].Substring(0, i);

        }
    }
}
