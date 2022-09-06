using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcProject.App
{
    public class RomanNumber
    {
        public static int Parse(string str) //ололо
        {
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
            return res;
        }
    }
}
