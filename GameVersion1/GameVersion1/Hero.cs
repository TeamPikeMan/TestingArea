using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameVersion1
{
    class Hero
    {
        public int x;
        public int y;
        public int lives;
        public int score;
        public int powerUpLevel;

        public Hero()
        {
            this.x = 20;
            this.y = 20;
            this.lives = 3;
            this.score = 0;
            this.powerUpLevel = 0;
        }

        public void LevelUp() 
        {
            powerUpLevel++;
        }

        public void LifeUp()
        {
            lives++;
        }


        public void PlaceInGrid(int[,] grid)
        {
            grid[x, y] = 10;
        }

        public void RemoveFromGrid(int[,] grid)
        {
            grid[x, y] = 0;
        }

        public void Move(int move,int[,] grid)
        {
            this.RemoveFromGrid(grid);
            if (move == 1) { y -=1; }
            if (move == -1) { y += 1; }
            if (move == 2) { x -=1; }
            if (move == -2) { x+=1; }
            this.PlaceInGrid(grid);
        }

        public Projectile Fire(int i)
        {
            return new Projectile(x-1, y, -1, i);
        }

        public void Hit(List<Projectile> j, int[,] grid)
        {
            if (j.Exists(o => o.x==this.x && o.y==this.y && o.direction==1))
            {
                lives--;
                int index= j.FindIndex(o => o.x==this.x && o.y==this.y && o.direction==1);
                j[index].RemoveFromGrid(grid);
                j.RemoveAt(index);
            }
        }
    }
}
