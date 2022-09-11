using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcProject.App
{
    public class RomanNumber
    {
        public int Val { get; set; }
        public RomanNumber(int x)
        {
            Val = x;
        }
        public static int Parse(string str) //ололо
        {
<<<<<<< HEAD
            bool counter = false;
            if(str=="N")
            {
                return 0;
            }
            if (str[0] == '-')
=======
            if (str == null) throw new ArgumentNullException("string was null");
            if (str.Length == 0) throw new ArgumentNullException("string was empty");

            bool counter=false;
            if (str.StartsWith("-"))
>>>>>>> 98c4998cbaf89499f0c8cad08f52c07a60d5ac46
            {
                counter = true;
                str = str.Substring(1, str.Length - 1);
            }
            
            if (str == "N") return 0;
            
            

            char[] digits = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            int[] digitValues = { 1, 5, 10, 50, 100, 500, 1000 };
            int res = 0;
            char lastStr = ' ';
            if (str.Length == 1)
            {
                int ind = Array.IndexOf(digits, str[0]);
                return digitValues[ind];
            }
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (res == 0)
                {
                    int ind = Array.IndexOf(digits, str[i]);
                    lastStr = str[i];
                    if (ind == -1)
                    {
                        throw new ArgumentException($"Invalid digit '{str[i]}'");
                    }
                    res = digitValues[ind];
                }
                else
                {

                    int ind = Array.IndexOf(digits, str[i]);
                    if (ind == -1)
                    {
                        throw new ArgumentException($"Invalid digit '{str[i]}'");
                    }
                    if (lastStr == str[i])
                    {
                        res += digitValues[ind];
                    }
                    else if (digitValues[ind] < res) res -= digitValues[ind];
                    else res += digitValues[ind];
                    lastStr = str[i];
                }
            }
            if (counter)
            {
                return -res;
            }
            return res;
        }

        public override string ToString()
        {
            int x = Val;
            if (x == 0)
                return "N";
            string result = "";
            int[] digits = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] romanDigits = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            for (int i = 0; i < digits.Length; i++)
            {
                while (x >= digits[i])
                {
                    x -= digits[i];
                    result += romanDigits[i];
                }
            }

            return result;
        }

<<<<<<< HEAD
        public RomanNumber Add(RomanNumber other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Digit was null");
            }
            return new(this.Val + other.Val);
        }
        public RomanNumber Add(int right)
        {
            if (right == null)
            {
                throw new ArgumentNullException("Digit was null");
            }
=======
        public RomanNumber Add(RomanNumber right)
        {
            if (right == null) throw new ArgumentNullException("number was null");
            return new(this.Val + right.Val);
        }

        public RomanNumber Add(int right)
        {
>>>>>>> 98c4998cbaf89499f0c8cad08f52c07a60d5ac46
            return new(this.Val + right);
        }
        public RomanNumber Add(string right)
        {
<<<<<<< HEAD
            if (right == null)
            {
                throw new ArgumentNullException("Digit was null");
            }

            return new(this.Val + RomanNumber.Parse(right));
=======
            if (right == null) throw new ArgumentNullException("number was null");
            return new(this.Val + Parse(right));
>>>>>>> 98c4998cbaf89499f0c8cad08f52c07a60d5ac46
        }
    }
}