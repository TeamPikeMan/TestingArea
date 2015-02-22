using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWNumberSystems
{
    class Conversion
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(DecimalToBinary(n));
        }

        static string DecimalToBinary(int n)
        {
            string result = "";

            int temp = n;

            while (temp>=0)
            {
                
                result = (temp % 2).ToString() + result;
                temp /= 2;
                if (temp == 0) { break; }
            }

            return result;
        }
    }
}
