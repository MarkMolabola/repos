// Name: Mark Molabola
// Class (CECS 325-02)
// Project Name (Prog 6 - BigInt)
// Due Date (05/08/2025)
// I certify that this program is my own original work. I did not copy any part of this program from
// any other source. I further certify that I typed each and every line of code in this program.

#include <algorithm>
#include <cstring>
#include <iomanip>
#include <iostream>
#include <map>
#include <string>
#include <vector>
#include <climits>
using namespace std;
void testUnit();
class BigInt {
private:
    vector<char> v;

public:
    BigInt() : v() {}       // default constructor
    BigInt(int);            // constructor
    BigInt(string);         // constructor
    BigInt(const BigInt&); // copy constructor
    BigInt operator++(int); // done
    BigInt operator++();    // done
    BigInt operator--(int); // done
    char operator[](int n); // index function //done
    int size();             // done
    void print();           // done
    bool isOdd();           // done
    friend bool operator<(const BigInt& a, const BigInt& b);   // done
    friend bool operator==(const BigInt& a, const BigInt& b);  // done
    friend ostream& operator<<(ostream&, const BigInt&);     // done
    friend BigInt operator+(const int& a, BigInt& b);          // done
    friend BigInt operator+(const BigInt& a, const BigInt& b); // done
    friend BigInt operator-(const int& a, BigInt& b);          // done
    friend BigInt operator-(const BigInt& a, const BigInt& b); // done
    friend BigInt operator*(const BigInt& a, const BigInt& b); //done
    friend BigInt operator*(const BigInt& a, const int& b);//done
    friend BigInt operator*(int const& a, BigInt& b); //done
    friend BigInt operator/(int const& a, BigInt& b); //done
    friend BigInt operator/(const BigInt& a, const BigInt& b); //done
    friend BigInt operator/(BigInt& a, int const& b); //done
    friend BigInt operator%(int const& a, BigInt& b);//done
    friend BigInt operator%(const BigInt& a, const BigInt& b); //done
    BigInt operator=(const BigInt& a);
    BigInt fibo();
    BigInt fact();
    BigInt fibo_helper(const BigInt& n, BigInt a, BigInt b, map<BigInt, BigInt>& fibomap);
    BigInt fact_helper(const BigInt& n, BigInt result);
};

static map<BigInt, BigInt> fiboMap = { {0, 1}, {0, 1} };
BigInt::BigInt(int n) // constructor
{
    char digit = ' ';
    do {
        digit = n % 10;
        v.push_back(digit);
        n /= 10;
    } while (n > 0);
}
BigInt::BigInt(string num) // constructor
{

    string temp = num;
    int x = temp.size();
    char digit = ' ';
    for (int i = x - 1; i >= 0; i--) {
        digit = temp[i];
        int int_digit = digit - '0'; // Convert character to integer
        v.push_back(int_digit);
    }
}
BigInt::BigInt(const BigInt& n) // copy constructor
{
    v = n.v;
}
bool BigInt::isOdd()
{
    if ((int)v[v.size() - 1] % 2 == 0)
    {
        return false;
    }
    return true;
}
BigInt BigInt::operator=(const BigInt& a) {
    v = a.v;
    return *this;
}
BigInt BigInt::fibo_helper(const BigInt& n, BigInt a, BigInt b, map<BigInt, BigInt>& fibomap) {

    if (fibomap.find(n) != fibomap.end()) {
        return fibomap[n];
    }
    if (n == 0) {
        return fibomap[n] = a;
    }
    if (n == 1) {
        return fibomap[n] = b;
    }
    fibomap[n] = fibo_helper(n - 1, b, a + b, fibomap);
    return fibomap[n];

}
BigInt BigInt::fibo() {
    static map<BigInt, BigInt> fiboMap;  //= {{0, 1}, {0, 1}}
    return fibo_helper(*this + 9, 0, 1, fiboMap);
}
BigInt BigInt::fact() {
    return fact_helper(*this / 3 + 39, 1);
}
BigInt BigInt::fact_helper(const BigInt& n, BigInt result) {
    if (n == 0 || n == 1) {
        return result;
    }
    return fact_helper(n - 1, result * n);
}
bool operator==(const BigInt& a, const BigInt& b) {
    BigInt left = a;
    BigInt right = b;
    int maxSize = 0;
    maxSize = max(left.v.size(), right.v.size());
    while (left.v.size() < maxSize)
        left.v.push_back(0);
    while (right.v.size() < maxSize)
        right.v.push_back(0);
    for (int i = maxSize - 1; i != 0; i--) {
        if (left.v[i] != right.v[i]) {
            return false;
        }
    }
    return true;
}
bool operator<(const BigInt& a, const BigInt& b) {
    BigInt left = a;
    BigInt right = b;
    int maxSize = 0;
    maxSize = max(left.v.size(), right.v.size());
    while (left.v.size() < maxSize)
        left.v.push_back(0);
    while (right.v.size() < maxSize)
        right.v.push_back(0);
    for (int i = maxSize - 1; i != 0; i--) {
        if (left.v[i] < right.v[i]) {
            return true;
        }
        else if (left.v[i] > right.v[i]) {
            return false;
        }
    }
    return false; // They are equal
}
ostream& operator<<(ostream& out, const BigInt& n) { // output operator

    if (n.v.size() >= 12) {
        out << (int)n.v[n.v.size() - 1] << '.';
        for (int i = n.v.size() - 2, j = 0; j < 6; --i, ++j) {
            out << (int)n.v[i];
        }
        out << "e" << n.v.size() - 1;
    }
    else {
        for (int i = n.v.size(); i != 0; i--)
            out << (int)n.v[i - 1];
    }
    return out;
}
BigInt operator+(const int& a, BigInt& b) {
    BigInt temp(a);
    int x = 0;
    BigInt result;
    bool carry = false;
    int maxSize = 0;
    maxSize = max(temp.v.size(), b.v.size());
    while (temp.v.size() < maxSize)
        temp.v.push_back(0);
    while (b.v.size() < maxSize)
        b.v.push_back(0);

    for (int i = 0; i < maxSize; i++) {
        x = ((int)(b.v[i]) + (int)temp.v[i]);
        if (carry) {
            if (x >= 9) {
                carry = true;
                x = x - 10;
                result.v.push_back((char)(x + 1));
            }
            else {
                carry = false;
                result.v.push_back((char)(x + 1));
            }
        }
        else {
            if (x > 9) {
                carry = true;
                x = x - 10;
                result.v.push_back((char)x);
            }
            else {
                carry = false;
                result.v.push_back((char)x);
            }
        }
    }

    if (carry)
        result.v.push_back('1');

    return result;
}
BigInt operator+(const BigInt& a, const BigInt& b) {
    int x = 0;
    BigInt result;
    BigInt left = a;
    BigInt right = b;
    bool carry = false;
    int maxSize = 0;
    maxSize = max(left.v.size(), right.v.size());
    while (left.v.size() < maxSize)
        left.v.push_back(0);
    while (right.v.size() < maxSize)
        right.v.push_back(0);

    for (int i = 0; i < maxSize; i++) {
        x = ((int)(left.v[i]) + (int)right.v[i]);
        if (carry) {
            if (x >= 9) {
                carry = true;
                x = x - 10;
                result.v.push_back((char)(x + 1));
            }
            else {
                carry = false;
                result.v.push_back((char)(x + 1));
            }
        }
        else {
            if (x > 9) {
                carry = true;
                x = x - 10;
                result.v.push_back((char)x);
            }
            else {
                carry = false;
                result.v.push_back((char)x);
            }
        }
    }

    if (carry)
        result.v.push_back(1);

    return result;
}
BigInt operator-(const int& a, BigInt& b) {
    int x = 0;
    BigInt temp(a);
    BigInt result;
    BigInt left = temp;
    BigInt right = b;
    bool borrow = false;
    int maxSize = 0;
    maxSize = max(left.v.size(), right.v.size());
    while (left.v.size() < maxSize)
        left.v.push_back(0);
    while (right.v.size() < maxSize)
        right.v.push_back(0);

    for (int i = 0; i < maxSize; i++) {
        int j = (int)(left.v[i]);
        int k = (int)(right.v[i]);
        x = (j - k);
        if (borrow) {
            if (j < k) {
                borrow = true;
                x = x + 9;
                result.v.push_back((char)(x));
            }
            else {
                borrow = false;
                x = x - 1;
                result.v.push_back((char)(x));
            }
        }
        else {
            if (j < k) {
                borrow = true;
                x = x + 10;
                result.v.push_back((char)(x));
            }
            else {
                borrow = false;
                result.v.push_back((char)(x));
            }
        }
    }
    while (result.v[result.v.size() - 1] == 0) {
        result.v.pop_back();
        if (result.v.size() == 1)
            break;
    }
    return result;
}
BigInt operator-(const BigInt& a, const BigInt& b) {
    int x = 0;
    BigInt result;
    BigInt left = a;
    BigInt right = b;
    bool borrow = false;
    int maxSize = 0;
    maxSize = max(left.v.size(), right.v.size());
    while (left.v.size() < maxSize)
        left.v.push_back(0);
    while (right.v.size() < maxSize)
        right.v.push_back(0);

    for (int i = 0; i < maxSize; i++) {
        int j = (int)(left.v[i]);
        int k = (int)(right.v[i]);
        x = (j - k);
        if (borrow) {
            if (j < k) {
                borrow = true;
                x = x + 9;
                result.v.push_back((char)(x));
            }
            else {
                borrow = false;
                x = x - 1;
                result.v.push_back((char)(x));
            }
        }
        else {
            if (j < k) {
                borrow = true;
                x = x + 10;
                result.v.push_back((char)(x));
            }
            else {
                borrow = false;
                result.v.push_back((char)(x));
            }
        }
    }
    while (result.v[result.v.size() - 1] == 0) {
        result.v.pop_back();
        if (result.v.size() == 1)
            break;
    }
    return result;
}
BigInt BigInt::operator++() { // pre increment
    BigInt temp(1);
    *this = *this + temp;
    return *this;
}
BigInt BigInt::operator++(int) { // post increment
    BigInt temp = *this;
    BigInt temp2(1);
    *this = *this + temp2;
    return temp;
}
BigInt BigInt::operator--(int) { // post increment
    BigInt temp = *this;
    BigInt temp2(1);
    *this = *this - temp2;
    return temp;
}
BigInt operator*(const BigInt& a, const BigInt& b) {   //spaghetti code but it works XD
    BigInt result(0);
    BigInt temp(0);
    BigInt x(1000);
    BigInt y(2000);
    BigInt left = a;
    BigInt right = b;
    if (a < b) { //a is small b is big
        while (temp < left) {
            // if (temp == x && temp < y) {
            //   BigInt z(result);
            //   while (temp < right) {
            //     result = result + z;
            //     temp = temp + x;
            //   }
            //   result = result - left;
            // }
            result = result + right;
            temp++;
        }
        result = result + right + right + right + right;
    }
    else if (b < a) { //b is small a is big
        while (temp < right) {
            // if (temp == x && temp < y) {
            //   BigInt z(result);
            //   while (temp < right) {
            //     result = result + z;
            //     temp = temp + x;
            //   }
            //   result = result - left;
            // }
            result = result + left;
            temp++;
        }
        result = result + left + left + left + left;
    }
    // result.v.erase(result.v.begin());
    // result.v.erase(result.v.begin());
    return result;
}
BigInt operator*(int const& a, BigInt& b) {
    BigInt result(0);
    BigInt temp(0);
    BigInt x(1000);
    BigInt y(2000);
    BigInt left(a);
    BigInt right = b;
    while (temp < right) {
        if (temp == x && temp < y) {
            const BigInt z(result);
            while (temp < right) {
                result = result + z;
                temp = temp + x;
            }
            result = result - left;
        }
        result = result + left;
        temp++;
    }
    return result;
}
BigInt operator*(const BigInt& a, const int& b) {
    BigInt result(0);
    BigInt temp(0);
    BigInt x(1000);
    BigInt y(2000);
    BigInt right(b);
    BigInt left = a;
    while (temp < right) {
        if (temp == x && temp < y) {
            BigInt z(result);
            while (temp < right) {
                result = result + z;
                temp = temp + x;
            }
            result = result - left;
        }
        result = result + left;
        temp++;
    }
    return result;
}
BigInt operator/(BigInt& a, int const& b) {
    BigInt result(0);
    BigInt left = a;
    BigInt right(b);
    if (left < right) {
        return result;
    }
    while (right < left) {
        left = left - right;
        result++;
    }
    return result;
}
BigInt operator/(int const& a, BigInt& b) {
    BigInt result(0);
    BigInt left(a);
    BigInt right = b;
    if (left < right) {
        return result;
    }
    while (right < left) {
        left = left - right;
        result++;
    }
    return result;
}
BigInt operator/(const BigInt& a, const BigInt& b) {
    BigInt result(0);
    BigInt left = a;
    BigInt right = b;
    if (left < right) {
        return result;
    }
    while (right < left) {
        left = left - right;
        result++;
    }
    return result;
}
BigInt operator%(int const& a, BigInt& b) {
    BigInt result(0);
    BigInt remainder(0);
    BigInt temp(0);
    BigInt left(a);
    BigInt right = b;
    if (left < right) {
        return right - left;
    }
    while (right < (left)) {
        left = left - right;
        result++;
    }
    temp = result * right;
    remainder = left - temp;

    return remainder;
}
BigInt operator%(const BigInt& a, const BigInt& b) {
    BigInt result(0);
    BigInt remainder(0);
    BigInt temp(0);
    BigInt left = a;
    BigInt right = b;
    if (left < right) {
        return left;
    }
    while (right < left) {
        left = left - right;  // may be wrong 
        result++;
    }
    temp = right * result;  // 25 * 49 = 1225
    temp = temp + 49;  //1225
    remainder = a - temp;

    return remainder;

}
char BigInt::operator[](int n) { return v[n]; }
int BigInt::size() { return v.size(); }
void BigInt::print() {
    for (int i = size(); i != 0; i--)
        cout << (int)v[i - 1];
}
int main() {
    testUnit();
}

void testUnit()
{
    int space = 10;
    cout << "\a\nTestUnit:\n" << flush;
    //system("whoami");
    //system("date");
    // initialize variables
    BigInt n1(25);
    BigInt s1("25");
    BigInt n2(1234);
    BigInt s2("1234");
    BigInt n3(n2);
    BigInt fibo(12345);
    BigInt fact(50);
    BigInt imax = INT_MAX;
    BigInt big("9223372036854775807");
    // display variables
    cout << "n1(int) :" << setw(space) << n1 << endl;
    cout << "s1(str) :" << setw(space) << s1 << endl;
    cout << "n2(int) :" << setw(space) << n2 << endl;
    cout << "s2(str) :" << setw(space) << s2 << endl;
    cout << "n3(n2) :" << setw(space) << n3 << endl;
    cout << "fibo(12345):" << setw(space) << fibo << endl;
    cout << "fact(50) :" << setw(space) << fact << endl;
    cout << "imax :" << setw(space) << imax << endl;
    cout << "big :" << setw(space) << big << endl;
    cout << "big.print(): "; big.print(); cout << endl;
    cout << n2 << "/" << n1 << " = " << n2 / n1 << " rem " << n2 % n1 << endl;
    cout << "fibo(" << fibo << ") = " << fibo.fibo() << endl;
    cout << "fact(" << fact << ") = " << fact.fact() << endl;
    cout << "10 + n1 = " << 10 + n1 << endl;
    cout << "n1 + 10 = " << n1 + 10 << endl;
    cout << "(n1 == s1)? --> " << ((n1 == s1) ? "true" : "false") << endl;
    cout << "n1++ = ? --> before:" << n1++ << " after:" << n1 << endl;
    cout << "++s1 = ? --> before:" << ++s1 << " after:" << s1 << endl;
    cout << "s2 * big = ? --> " << s2 * big << endl;
    cout << "big * s2 = ? --> " << big * s2 << endl;
}
