using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02
{
    class BinToDec
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(BinaryToDecimal(input));
        }

        static double BinaryToDecimal(string n)
        {
            double num = 0;
            int l=n.Length-1;
            for (int i = 0; i < n.Length; i++)
            {
                num += (int.Parse(n[l-i].ToString())*Math.Pow(2,i));
            }

            return num;
        }
    }
}
