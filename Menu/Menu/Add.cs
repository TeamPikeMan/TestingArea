using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    class Add
    {
        public int a;
        public int b;

        public Add(int aa, int bb)
        {
            a = aa;
            b = bb;
        }

        public int Addition()
        {
            return a + b;
        }
    }
}
