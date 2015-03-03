using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossBattleAndAlternativeMechanics
{
    class Boss
    {
        public Coordinates core;
        public int lives;
        public List<Coordinates> bits=new List<Coordinates>();


        public Boss(int pos1,int pos2, int l)
        {
            this.core = new Coordinates(pos1, pos2);
            lives = l;

            bits.Add(this.core);
            // plus shape
            bits.Add(new Coordinates(pos1+1, pos2));
            bits.Add(new Coordinates(pos1-1, pos2));
            bits.Add(new Coordinates(pos1, pos2-1));
            bits.Add(new Coordinates(pos1, pos2 +1));

           

        }

        public void UpdateBits()
        {
            this.bits[0] = new Coordinates(core.x, core.y );
            this.bits[1] = new Coordinates(core.x+1, core.y);
            this.bits[2] = new Coordinates(core.x-1, core.y);
            this.bits[3] = new Coordinates(core.x, core.y+1);
            this.bits[4] = new Coordinates(core.x, core.y-1);
        }
        public void PlaceInGrid(int[,] grid)
        {
            foreach (var item in bits)
            {
                grid[item.x, item.y] = 1;
            }
        }

        public void RemoveFromGrid(int[,] grid)
        {
            foreach (var item in bits)
            {
                grid[item.x, item.y] = 0;
            }
        }

        public void Move(int[,] grid)
        {
            int move = 0;

            Random rng = new Random();

            int ch = rng.Next(0, 4);

            switch(ch)
            {
                case 0:
                    move = 1;
                    break;
                case 1:
                    move = -1;
                    break;
                case 2:
                    move = 2;
                    break;
                case 3:
                    move = -2;
                    break;
            }
            this.RemoveFromGrid(grid);

            if (move == 1) { this.core = new Coordinates(core.x, core.y - 1); }
            if (move == -1) { this.core = new Coordinates(core.x, core.y + 1); }
            if (move == 2) { this.core = new Coordinates(core.x-1, core.y); }
            if (move == -2) { this.core = new Coordinates(core.x+1, core.y); }

            this.UpdateBits();

            this.PlaceInGrid(grid);
        }
    }
}
