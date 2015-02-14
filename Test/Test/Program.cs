using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Alien
    {
        public int x;
        public int y;

        public Alien()
        {
            x = 0;
            y = 0;
        }

        public Alien(int valueX, int valueY)
        {
            x = valueX;
            y = valueY;
        }

        public void PrintAlien()
        {
            Console.WriteLine("{0},{1}", x, y);
        }

        public int SumAlien()
        {
            return x + y;
        }

        
    }

    

    class Program
    {
        static void Main()
        {
            Alien alienA = new Alien();
            Alien alienB = new Alien(1, 2);
            alienA.PrintAlien();
            alienB.PrintAlien();
            alienA.SumAlien();
            alienA.PrintAlien();
        }
    }
}
