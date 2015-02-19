using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem05
{
    class BiggestInTheBlock
    {
        static void Main(string[] args)
        {
            int[] test = { 1, 1, 1, 3, 4, 5, 6, 7, 6, 4, 3, 21, 1, 4 };
            Console.WriteLine(LargerThanNeighboors(7, test));//yes 6,7,6
        }

        static bool LargerThanNeighboors(int index, int[] matrix)
        {
            return(matrix[index]>matrix[index+1]&&matrix[index]>matrix[index-1]);
        }
    }
}
