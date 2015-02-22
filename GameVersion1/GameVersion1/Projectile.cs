using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameVersion1
{
    class Projectile
    {
        public int x;
        public int y;
        public int direction;
        public int direction2;

        public Projectile()
        {
            x = 0;
            y = 0;
            direction = 1;
        }

        public Projectile(int xpos, int ypos, int d, int d2=0)
        {
            x=xpos;
            y=ypos;
            direction = d;
            direction2 = d2;

        }

        public void PlaceInGrid(int[,] grid)
        {
            if (grid[x, y] == 0)
            {
                if (direction == 1)
                    grid[x, y] = 2;
                else
                    grid[x, y] = 3;
            }
        }

        public void RemoveFromGrid(int[,] grid)
        {
            if (grid[x, y] == 2 || grid[x, y] == 3)
            {
                grid[x, y] = 0;
            }
        }

        public void TimeProgress(int[,] grid)
        {
            this.RemoveFromGrid(grid);

            x = this.x + this.direction;
            y = this.y + this.direction2;
   
            this.PlaceInGrid(grid);
        }
    }
}
