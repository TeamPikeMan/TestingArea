using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem03
{
    class LastDigit
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            LastDigitAsWord(Math.Abs(N));
        }

        static void LastDigitAsWord(int n)
        {
            string[] digits=
            {
                "zero",
                "one",
                "two",
                "three",
                "four",
                "five",
                "six",
                "seven",
                "eight",
                "nine",

            };

            Console.WriteLine(digits[n % 10]);
        }
    }
}
