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
            if (str == null) throw new ArgumentNullException("string was null");
            if (str.Length == null) throw new ArgumentNullException("string was empty");
0
            bool counter=false;
            if (str.StartsWith("-"))
            {
                counter=true;
                str=str.Substring(1,str.Length-1); 
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
            for (int i = str.Length-1; i >= 0; i--)
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
            if(counter)
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
    }
}
