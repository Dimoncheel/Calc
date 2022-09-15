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

        public void Run()
        {
            RomanNumber rn1,rn2;
            while (true)
            {
                try
                {
                    Console.WriteLine("Input number");
                    string? inp = Console.ReadLine();
                   
                    rn1 =new RomanNumber(RomanNumber.Parse(inp));
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
            while (true)
            {
                try
                {
                    Console.WriteLine("Input number");
                    string? inp = Console.ReadLine();

                    rn2 = new RomanNumber(RomanNumber.Parse(inp));
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
            Console.WriteLine(rn1.Add(rn2));
            //поменял Run
        }
    }
}
