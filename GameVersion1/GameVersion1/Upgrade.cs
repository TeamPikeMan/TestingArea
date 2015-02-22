using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameVersion1
{
    class Upgrade
    {
        public int x;
        public int y;
        public int direction;
        public int secondDirection;
        public int type;

        public Upgrade(int xValue, int yValue, int d, int t, int sd = 0)
        {
            x = xValue;
            y = yValue;
            direction = d;
            secondDirection = sd;
            type = t;
        }

        public void PlaceInGrid(int[,] grid)
        {
            if (grid[x, y] == 0)
            {
                grid[x, y] = 5;
            }

        }

        public void RemoveFromGrid(int[,] grid)
        {
            if (grid[x, y] == 5)
            {
                grid[x, y] = 0;
            }
        }

        public void HeroCatch(Hero hero, int[,] grid)
        {
            if (this.x == hero.x && this.y == hero.y)
            {
                this.RemoveFromGrid(grid);
                type = 5;

            }
        }

        public void HitDetect(Hero hero, int[,] grid)
        {

        }

        public void MoveTimeProgress(int[,] grid)
        {
            this.RemoveFromGrid(grid);
            this.x += direction;
            this.y += secondDirection;
            this.PlaceInGrid(grid);
        }
    }
}
