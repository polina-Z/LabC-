using System;

namespace lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            RationalNumbers number1 = new RationalNumbers(1,2);
            RationalNumbers number2 = new RationalNumbers(3,4);
            RationalNumbers number3 = new RationalNumbers(2, 7);
            Console.WriteLine("1) " + number1.ToString("/"));
            Console.WriteLine("2) " + number2.ToString("\\"));
            Console.WriteLine("3) " + number3.ToString(":"));
            Console.WriteLine();

            RationalNumbers number4;
            if(RationalNumbers.TryParse("2c/5", out number4))
            {
                Console.WriteLine("4) " + number4.ToString("|"));
            }
            else
            {
                Console.WriteLine("2c/5 does not translate into a rational number");
            }

            if(RationalNumbers.TryParse("2/5", out number4))
            {
                Console.WriteLine("4) " + number4.ToString("|"));
            }
            else
            {
                Console.WriteLine("2c/5 does not parse into a rational number");
            }

            Console.WriteLine("\nnumber1 + number2 = " + (number1 + number2).ToString("/"));
            Console.WriteLine("number1 - number2 = " + (number1 - number2).ToString("/"));
            Console.WriteLine("number3 * number4 = " + (number3 * number4).ToString("/"));
            Console.WriteLine("number3 / number4 = " + (number3 / number4).ToString("/"));
            Console.WriteLine("number1 % number4 = " + (number1 % number4).ToString("/"));
            Console.WriteLine();
            if(number1 > number2)
            {
                Console.WriteLine("number1 > number2");
            }
            else
            {
                Console.WriteLine("number1 < number2");
            }
            Console.WriteLine("\n(double)number1 = {0}", Convert.ToDouble(number1));
        }
    }
}
