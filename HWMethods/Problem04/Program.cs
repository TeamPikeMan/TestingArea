using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem04
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] test = { 1, 1, 1, 3, 4, 5, 6, 7, 6, 4, 3, 21, 1, 4 };
            Console.WriteLine(AppearanceCount(1,test));//4
            Console.WriteLine(AppearanceCount(3, test));//2
        }

        static int AppearanceCount(int n, int[] a)
        {
            int result = a.Count(x => x==n);
            return result;
        }

    }
}
