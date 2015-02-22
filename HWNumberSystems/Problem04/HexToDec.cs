using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem04
{
    class HexToDec
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(HexToDecimal(input));
           
        }

        static double HexToDecimal(string n)
        {
            string[] numbers =
            {
                "0","1","2","3","4","5","6","7","8","9","A","B","C","D","E","F",
            };

            List<string> temp = numbers.ToList();

            double num = 0;
            int l = n.Length - 1;
            for (int i = 0; i < n.Length; i++)
            {
                num += temp.IndexOf(n[l-i].ToString().ToUpper())* Math.Pow(16, i);
            }

            return num;
        }
    }
}
