using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem06
{
    class FirstBigger
    {
        static void Main(string[] args)
        {
            int[] test = {1,1, 1, 3, 5, 5, 6, 11, 6, 4, 3, 21, 1, 4 };
            Console.WriteLine(alabala(test));
        }

        static bool LargerThanNeighboors(int index, int[] matrix)
        {
            return (matrix[index] > matrix[index + 1] && matrix[index] > matrix[index - 1]);
        }

        static int FirstBiggest(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if(LargerThanNeighboors(i,a))
                {
                    return i;
                }
            }
            return -1;
        }

       /* static int alabala(int[] a)
        {
            var b = a.First(x => a[x]< a[x] > a[x + 1] && x >= 1);
            
            return a[b];
        }*/
    }
}
