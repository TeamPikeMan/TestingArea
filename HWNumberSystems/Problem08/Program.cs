using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem08
{
    class Program
    {
        static void Main(string[] args)
        {
            short n = short.Parse(Console.ReadLine());
            Console.WriteLine(BitForm(n));
        }

        static string BitForm(short num)
        {
            string result = "";

            for (int i = 0; i < 16; i++)
            {
                int temp = num;
                int ch = (temp >> i) & 1;
                result = ch.ToString() + result;
            }
            return result;
        }
    }
}
