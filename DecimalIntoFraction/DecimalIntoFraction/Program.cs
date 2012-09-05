using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DecimalIntoFraction
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                decimal input_num;
                if (decimal.TryParse(Console.ReadLine(), out input_num))
                {
                    Fraction fr = Fraction.FromDecimal(input_num);
                    Console.WriteLine("{0} = {1}", input_num, fr);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
