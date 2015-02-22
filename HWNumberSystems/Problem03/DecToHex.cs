using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem03
{
    class DecToHex
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(DecimalToHex(number));
        }

        static string DecimalToHex(int n)
        {
            string result = "";

            string[] numbers =
            {
                "0","1","2","3","4","5","6","7","8","9","A","B","C","D","E","F",
            };

            int temp = n;

            while (temp >= 0)
            {

                result = numbers[temp % 16]+result;
                temp /= 16;
                if (temp == 0) { break; }
            }

            return result;
        }
    }
}
