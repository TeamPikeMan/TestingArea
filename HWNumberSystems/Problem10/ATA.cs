using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem10
{
    class ATA
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting number system");
            int system1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Input Number");
            string input = Console.ReadLine();
            Console.WriteLine("End number system");
            int system2 = int.Parse(Console.ReadLine());
            
            Console.WriteLine(AnyToAny(input,system1,system2));
        }

        static string AnyToAny(string input, int sys1, int sys2)
        {
            int value10 = (int)AnyToDecimal(input, sys1);
            return DecimalToAny(value10,sys2);
        }

        static double AnyToDecimal(string n, int sys1)
        {
            double num = 0;
            int l = n.Length - 1;
            for (int i = 0; i < n.Length; i++)
            {
                num += (int.Parse(n[l - i].ToString()) * Math.Pow(sys1, i));
            }

            return num;
        }

        static string DecimalToAny(int n, int sys2)
        {
            string result = "";

            string[] numbers =
            {
                "0","1","2","3","4","5","6","7","8","9","A","B","C","D","E","F",
            };

            int temp = n;

            while (temp >= 0)
            {
                
                result = numbers[temp % sys2]+result;
                temp /= sys2;
                
                if (temp == 0) { break; }
            }

            return result;
        }
    }
}
