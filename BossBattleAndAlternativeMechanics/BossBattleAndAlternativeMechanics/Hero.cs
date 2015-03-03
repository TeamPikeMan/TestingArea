using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossBattleAndAlternativeMechanics
{
    struct Coordinates
    {
        public int x;
        public int y;

        public Coordinates(int pos1,int pos2)
        {
            x = pos1;
            y = pos2;
        }
    }
    class HeroV2
    {
        public Coordinates core;
        public int lives;
        public List<Coordinates> bits=new List<Coordinates>();


        public HeroV2(int pos1,int pos2, int l)
        {
            this.core = new Coordinates(pos1, pos2);
            lives = l;

            bits.Add(this.core);
            bits.Add(new Coordinates(pos1, pos2 + 1));
            bits.Add(new Coordinates(pos1+1, pos2 + 1));
            bits.Add(new Coordinates(pos1+1, pos2));
        }

        public void UpdateBits()
        {
            this.bits[0] = new Coordinates(core.x, core.y );
            this.bits[1] = new Coordinates(core.x, core.y + 1);
            this.bits[2] = new Coordinates(core.x+1, core.y + 1);
            this.bits[3] = new Coordinates(core.x+1, core.y);
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

        public void Move(int move, int[,] grid)
        {
            this.RemoveFromGrid(grid);

            if (move == 1) { this.core = new Coordinates(core.x, core.y - 1); }
            if (move == -1) { this.core = new Coordinates(core.x, core.y + 1); }
            if (move == 2) { this.core = new Coordinates(core.x-1, core.y); }
            if (move == -2) { this.core = new Coordinates(core.x+1, core.y); }

            this.UpdateBits();

            this.PlaceInGrid(grid);
        }

        public void Fire(List<ProjectileV2> p, int[,] grid)
        {
            p.Add(new ProjectileV2(core.x + 1, core.y, -1));
            p.Add(new ProjectileV2(core.x + 1, core.y+1, -1));
        }


    }
}
