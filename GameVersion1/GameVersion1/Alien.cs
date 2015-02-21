using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameVersion1
{
    class Alien
    {
        public int x;
        public int y;
        public int lives;
        public int reloadTime;
        public int reloadTimer;

        public Alien(int xpos,int ypos, int l, int r)
        {
            x=xpos;
            y=ypos;
            lives = l;
            Random rng= new Random();
            reloadTimer = r;
            reloadTime = rng.Next(0, r);
        }

        public void PlaceInGrid(int[,] grid)
        {
            grid[x, y] = 1;
        }

        public void RemoveFromGrid(int[,] grid)
        {
            grid[x, y] = 0;
        }

        public void Hit_Detect(List<Projectile> j, int[,] grid, Hero pl)
        {
            if (j.Exists(o => o.x == this.x && o.y == this.y && o.direction == -1)&& this.lives>0)
            {
                lives--;
                if(lives==0)
                {
                    this.RemoveFromGrid(grid);
                    pl.score += 100;
                }
                int index = j.FindIndex(o => o.x == this.x && o.y == this.y);
                j[index].RemoveFromGrid(grid);
                j.RemoveAt(index);
            }
        }

        public Projectile Fire()
        {
            if (this.reloadTime == this.reloadTimer)
            {
                return new Projectile(x+1,y, 1);
            }
            else
            {
                return null;
            }
        }

        public void ProgressTime()
        {
            if (this.reloadTime > this.reloadTimer) { this.reloadTime = 0; }
            this.reloadTime++;
        }
        
    }
}
