using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem06
{
    class BinaryToHex
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(BinToHex(input));
        }

        
        static string BinToHex(string s)
        {
            int value10 = (int)BinaryToDecimal(s);

            return DecimalToHex(value10);
        }

        static double BinaryToDecimal(string n)
        {
            double num = 0;
            int l = n.Length - 1;
            for (int i = 0; i < n.Length; i++)
            {
                num += (int.Parse(n[l - i].ToString()) * Math.Pow(2, i));
            }

            return num;
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
