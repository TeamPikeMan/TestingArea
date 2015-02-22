using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadMulty
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(NewThread);
            t.Start();
            Console.ReadLine();
            t.Abort();
        }

        static void NewThread()
        {
            while (true)
            {
                Console.Beep(500,20);
            }
        }
    }
}
