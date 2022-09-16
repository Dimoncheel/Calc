using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcProject.App
{
    public class Calc
    {
        private readonly Resources _resources;

        public Calc(Resources resources)
        {
            _resources = resources;
            RomanNumber.Resources = resources;
        }

        public RomanNumber CreateRomanNumber()
        {
            RomanNumber rn;
            while (true)
            {
                try
                {
                    Console.WriteLine(RomanNumber.Resources.EnterNumberMessage());
                    string? inp = Console.ReadLine();

                    rn = new RomanNumber(RomanNumber.Parse(inp));
                    break;
                }
                catch (ArgumentNullException ex1)
                {
                    Console.WriteLine(ex1.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return rn;
        }

        public void CalcRomanNumber(RomanNumber rn1,RomanNumber rn2)
        {
            Console.WriteLine(RomanNumber.Resources.EnterOperationMessage());
            string? operation = Console.ReadLine();
            switch (operation) {
                case "+": 
                    Console.WriteLine(rn1.Add(rn2));
                    break;
                case "-": 
                    Console.WriteLine(rn1.Min(rn2));
                    break;
                case "*": 
                    Console.WriteLine("Next patch");
                    break;
                case "/":
                    Console.WriteLine("Next patch");
                    break;
                default:
                    throw new ArgumentException(RomanNumber.Resources.InvalidDigitMessage(operation));
            }

        }
        private void SelectCulture()
        {
            Console.WriteLine("Select culture:");
            for(int i = 0; i < _resources.SupportedCultures.Length; i++)
            {
                Console.WriteLine($"{i + 1} {_resources.SupportedCultures[i]}");
            }
            int selection=Convert.ToInt32(Console.ReadLine())-1;
            _resources.Culture=_resources.SupportedCultures[selection];
        }
        public RomanNumber EvalExpression(string expression)
        {
            if(expression is null)
            {
                throw new ArgumentException(_resources.ArgumentNullMessage());
            }
            String[] parts = expression.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 3)
            {
                throw new ArgumentException(_resources.InvalidDigitMessage(parts[1]));
            }
            if (parts[1] != "+")
            {
                throw new ArgumentException("Invalid operation");
            }
            RomanNumber rn1 = new(RomanNumber.Parse(parts[0]));
            RomanNumber rn2 = new(RomanNumber.Parse(parts[2]));
            return rn1.Add(rn2);
        }
        public void Run()
        {
            SelectCulture();

            Console.WriteLine("Input operation like: XY + C");

            String? operation = Console.ReadLine();

            Console.WriteLine($"{operation}:{EvalExpression(operation)}");

        }
        public void RunOld()
        {
            RomanNumber rn1=CreateRomanNumber();
            RomanNumber rn2=CreateRomanNumber();
         
            CalcRomanNumber(rn1,rn2);
        }
    }
}
