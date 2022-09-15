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
                    Console.WriteLine("Next patch");
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

        public void Run()
        {
            RomanNumber rn1=CreateRomanNumber();
            RomanNumber rn2=CreateRomanNumber();
         
            CalcRomanNumber(rn1,rn2);
        }
    }
}
