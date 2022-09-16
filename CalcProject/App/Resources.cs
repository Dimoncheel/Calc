using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcProject.App
{
    public class Resources
    {
        public string[] SupportedCultures = { "en-US","uk-UA"};

        const string UNSUPPORTEDCULTURE = "Unsupported culture";

        private string _culture;

        public string Culture
        {
            get => _culture;
            set {
                if (Array.IndexOf(SupportedCultures, value) != -1)
                {
                    _culture = value;
                }
                else
                {
                    throw new ArgumentException(UNSUPPORTEDCULTURE);
                }
            } 
        }

        public Resources()
        {
            Culture = SupportedCultures[0];
        }

        public string EnterNumberMessage()
        {
            return Culture switch
            {
                "en-US" => "Enter number",
                "uk-UA" => "Введіть число",
                _ => throw new ArgumentException("Culture unsupported")
            };
        }

        public string EnterOperationMessage()
        {
            return Culture switch
            {
                "en-US" => "Enter operation",
                "uk-UA" => "Введіть операцію",
                _ => throw new ArgumentException("Culture unsupported")
            };
        }

        public string ResultMessage()
        {
            return Culture switch
            {
                "en-US" => "Result",
                "uk-UA" => "Результат",
                _ => throw new ArgumentException("Culture unsupported")
            };
        }
        public string EmptyStringMessage()
        {
            return Culture switch
            {
                "en-US"=>"Empty string not allowed",
                "uk-UA"=>"Порожній рядок неприпустимий",
                _=>throw new ArgumentException("Culture unsupported")
            };
        }
        public string InvalidDigitMessage(char digit)
        {
            return Culture switch
            {
                "en-US" => $"Invalid digit '{digit}'",
                "uk-UA" => $"Неприпустимий символ '{digit}'",
                _ => throw new ArgumentException("Culture unsupported")
            };
        }
        public string InvalidDigitMessage(string digit)
        { 
            return Culture switch
            {
                "en-US" => $"Invalid digit '{digit}'",
                "uk-UA" => $"Неприпустимий символ '{digit}'",
                _ => throw new ArgumentException("Culture unsupported")
            };
        }
        public string InvalidTypeMessage(string typeName)
        {

            return Culture switch
            {
                "en-US" => $"Invalid argument type '{typeName}'",
                "uk-UA" => $"Неприпустимий тип '{typeName}",
                _ => throw new ArgumentException("Culture unsupported")
            };
        }
        public string ArgumentNullMessage()
        {
            return Culture switch
            {
                "en-US" => "Argument null exception",
                "uk-UA" => "Аргумент дорівнює NULL",
                _ => throw new ArgumentException("Culture unsupported")
            };
        }
    }
}
