using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem07
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal input3 = decimal.Parse(Console.ReadLine());
            Console.WriteLine(input3);
            Revers(ref input3);
            Console.WriteLine(input3);

        }
        static public decimal Revers(ref decimal n) //reference required so the value of the actual varible can be changed
        {
            char[] input = Math.Abs(n).ToString().ToCharArray();
            Array.Reverse(input);
            string output = new string(input);
            if (n < 0) { output = "-" + output; }
            n = decimal.Parse(output);
            return n;
        }
    }
}
