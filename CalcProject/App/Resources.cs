using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcProject.App
{
    public class Resources
    {
        public string EmptyStringMessage(string culture="en-US")
        {
            return culture switch
            {
                "en-US"=>"Empty string not allowed",
                "uk-UA"=>"Порожній рядок неприпустимий",
                _=>throw new ArgumentException("Culture unsupported")
            };
        }
        public string InvalidDigitMessage(char digit, string culture = "en-US")
        {
            return culture switch
            {
                "en-US" => $"Invalid digit '{digit}'",
                "uk-UA" => $"Неприпустимий символ '{digit}'"
            };
        }
        public string InvalidDigitMessage(string digit,string culture = "en-US")
        { 
            return culture switch
            {
                "en-US" => $"Invalid digit '{digit}'",
                "uk-UA" => $"Неприпустимий символ '{digit}'",
                _ => throw new ArgumentException("Culture unsupported")
            };
        }
        public string InvalidTypeMessage(string typeName, string culture = "en-US")
        {

            return culture switch
            {
                "en-US" => $"Invalid argument type '{typeName}'",
                "uk-UA" => $"Неприпустимий тип '{typeName}",
                _ => throw new ArgumentException("Culture unsupported")
            };
        }
        public string ArgumentNullMessage()
        {
            return "Argument null exception";
        }
    }
}
