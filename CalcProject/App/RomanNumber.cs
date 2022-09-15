using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcProject.App
{
    public class RomanNumber
    {
        public static Resources Resources { get; set; }
        public int Val { get; set; }
        public RomanNumber(int x)
        {
            Val = x;
        }
        public RomanNumber()
        {
        }
        private RomanNumber(object value)
        {
            if (value is null) throw new ArgumentNullException(Resources.ArgumentNullMessage());
            else if (value is RomanNumber rn) Val = rn.Val;
            else if (value is int int_val) Val = int_val;
            else if (value is string s_val) Val = RomanNumber.Parse(s_val);
            else throw new ArgumentException(Resources.InvalidDigitMessage(value.ToString()));
        }
        public static int Parse(string str) //ололо
        {
            int n_counter = 0;
            if (str == null) throw new ArgumentNullException(Resources.ArgumentNullMessage());
            if (str.Length == 0) throw new ArgumentNullException(Resources.EmptyStringMessage());

            bool counter=false;
            if (str.StartsWith("-"))
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
                if (ind == -1)
                {
                    throw new ArgumentException(Resources.InvalidDigitMessage(str));
                }
                return digitValues[ind];
            }
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (str[i] == 'N') n_counter++;
                if(n_counter >1) throw new ArgumentException(Resources.InvalidDigitMessage(str[i]));
                if (res == 0)
                {
                    int ind = Array.IndexOf(digits, str[i]);
                    lastStr = str[i];
                    if (ind == -1)
                    {
                        throw new ArgumentException(Resources.InvalidDigitMessage(str[i]));
                    }
                    res = digitValues[ind];
                }
                else
                {

                    int ind = Array.IndexOf(digits, str[i]);
                    if (ind == -1)
                    {
                        throw new ArgumentException(Resources.InvalidDigitMessage(str[i]));
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

        public RomanNumber Add(RomanNumber right)
        {
            if (right == null) throw new ArgumentNullException("Argument null exception");
            return new(this.Val + right.Val);
        }

        public  RomanNumber Add(int right)
        {
            return this.Add(new RomanNumber(right));
        }
        public  RomanNumber Add(string right)
        {
            if (right == null) throw new ArgumentNullException(Resources.ArgumentNullMessage());
            return this.Add(new RomanNumber(RomanNumber.Parse(right)));
        }

        //public static RomanNumber Add(int a,int b)
        //{
        //    return new(a + b);
        //}

        //public static RomanNumber Add(RomanNumber a, int b)
        //{
        //    return RomanNumber.Add(a.Val,b);
        //}

        //public static RomanNumber Add(RomanNumber a, RomanNumber b)
        //{
        //    return RomanNumber.Add(a.Val, b.Val); ;
        //}
        //public static RomanNumber Add(string a, string b)
        //{

        //    return RomanNumber.Add(RomanNumber.Parse(a),RomanNumber.Parse(b));
        //}
        //public static RomanNumber Add(RomanNumber a, string b)
        //{
        //    return RomanNumber.Add(a.Val,RomanNumber.Parse(b));
        //}

        public static RomanNumber Add(object obj1,object obj2)
        {
            //RomanNumber rn1, rn2 - такая запись хуже воспринимается

            RomanNumber rn1 = ConvertRomanNamber(obj1);
            RomanNumber rn2 = ConvertRomanNamber(obj2);
            /*
            if (obj1 is RomanNumber val1) rn1 = val1;
            else rn1 = new RomanNumber(obj1);
                                                        - дублирование кода (плохо)
            if (obj2 is RomanNumber val2) rn2 = val2;
            else rn2 = new RomanNumber(obj2);
            */

            return new RomanNumber(rn1.Val + rn2.Val);
        }

        private static RomanNumber ConvertRomanNamber(object obj)
        {
            if (obj is RomanNumber val) return val;
            else return new RomanNumber(obj);
        }
    }
}