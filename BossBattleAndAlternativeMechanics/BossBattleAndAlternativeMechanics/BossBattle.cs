using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BossBattleAndAlternativeMechanics
{
    class BossBattle
    {
        static void Main(string[] args)
        {
            int w = 50;
            int h = 150;
            Console.WindowHeight = w;
            Console.BufferHeight = w;
            Console.WindowWidth = h;
            Console.BufferWidth = h;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            int[,] matrix = new int[w - 2, h - 2];

            HeroV2 play = new HeroV2(20, 20, 3);
            play.PlaceInGrid(matrix);

            Boss b = new Boss(10, 10, 3);
            Console.WriteLine(printGridV2(matrix));
            List<ProjectileV2> missles = new List<ProjectileV2>();

            while (true)
            {
                HeroMoveV2(play, missles, matrix);
                foreach (var item in missles)
                {
                    item.PlaceInGrid(matrix);

                    if(item.core.x == 1 || item.core.x == w - 2)
                    {
                        item.RemoveFromGrid(matrix);
                    }

                    if(item.core.y == 1 || item.core.y == h - 2)
                    {
                        item.RemoveFromGrid(matrix);
                    }
                    
                }
                
                missles.RemoveAll(o => o.core.x == 1 || o.core.x == w - 2);
                missles.RemoveAll(o => o.core.y == 1 || o.core.y == h - 2);
                foreach (var item in missles)
                {
                    
                    item.TimeProgress(matrix);
                }
                b.Move(matrix);
                Console.WriteLine(printGridV2(matrix));
                Thread.Sleep(250);
                foreach (var item in missles)
                {
                    item.RemoveFromGrid(matrix);
                    item.TimeProgress(matrix);
                }

                Console.SetCursorPosition(0, 0);
            }
        }

        static public void HeroMoveV2(HeroV2 h, List<ProjectileV2> p, int[,] grid)
        {

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.LeftArrow && h.core.y >= 1)
                {
                    h.Move(1, grid);
                }
                if (userInput.Key == ConsoleKey.RightArrow && h.core.y <= grid.GetLength(1) - 2)
                {
                    h.Move(-1, grid);
                }
                if (userInput.Key == ConsoleKey.UpArrow && h.core.x >= 5)
                {
                    h.Move(2, grid);
                }
                if (userInput.Key == ConsoleKey.DownArrow && h.core.x < grid.GetLength(0) - 1)
                {
                    h.Move(-2, grid);
                }

                if (userInput.Key == ConsoleKey.Spacebar)
                {
                    h.Fire(p, grid);
                }

            }

            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
            }
        }
        static public string printGridV2(int[,] grid)
        {
            

            StringBuilder result = new StringBuilder();
            


            for (int i = 0; i < grid.GetLength(0); i++)
            {
                
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    switch (grid[i, j])
                    {
                        case 0:
                            result.Append(" ");//space
                            break;
                        case 1:
                            result.Append("!");//alien 1 live
                            break;

                        case 2:
                            result.Append("x");//alien 1 live
                            break;

                        case 3:
                            result.Append("o");//alien 1 live
                            break;
                        
                    }
                }
                result.Append(System.Environment.NewLine);

            }

            return result.ToString();
        }

    }
}
