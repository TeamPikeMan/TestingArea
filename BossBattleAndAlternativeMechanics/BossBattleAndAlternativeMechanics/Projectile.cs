using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossBattleAndAlternativeMechanics
{
    class ProjectileV2
    {

        public Coordinates core;
        public int direction;
       

        

        public ProjectileV2(int xpos, int ypos, int d, int d2 = 0)
        {
            this.core = new Coordinates(xpos, ypos);
            direction = d;
            

        }

        public void PlaceInGrid(int[,] grid)
        {
            if (grid[core.x, core.y] == 0)
            {
                if (direction == 1)
                    grid[core.x, core.y] = 2;
                else
                    grid[core.x, core.y] = 3;
            }
        }

        public void RemoveFromGrid(int[,] grid)
        {
            if (grid[core.x, core.y] == 2 || grid[core.x, core.y] == 3)
            {
                grid[core.x, core.y] = 0;
            }
        }

        public void TimeProgress(int[,] grid)
        {
            this.RemoveFromGrid(grid);

            this.core = new Coordinates(core.x + direction, core.y);

            this.PlaceInGrid(grid);
        }
    }
}
