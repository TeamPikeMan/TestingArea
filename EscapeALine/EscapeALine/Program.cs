//Move with arrows
//EscapeZobmibes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EscapeAlinesTest
{
    class Alines
    {
        public int x;
        public int y;
        public string Name = "";

        public Alines(int xpos, int ypos, string name)
        {
            x = xpos;
            y = ypos;
            Name = name;
        }

        public void placeInGrid(int[,] grid)
        {
            grid[x, y] = 1;
        }

        public void RemoveFromGrid(int[,] grid)
        {
            grid[x, y] = 0;
        }
        public void Move(int xnew, int ynew, int[,] grid)
        {
            this.RemoveFromGrid(grid);
            if (grid[x + xnew, y + ynew] != 1 && grid[x + xnew, y + ynew] != 3)
            {
                x += xnew;
                y += ynew;
            }
            this.placeInGrid(grid);

            Console.WriteLine(Program.printGrid(grid));



        }


        public void zombieMove(Hero A, int[,] grid)
        {

            int xdirection = -Math.Sign(this.x - A.x); // 4|2
            int ydirection = -Math.Sign(this.y - A.y);// 7|2
            int xsteps = Math.Abs(this.x - A.x);
            int ysteps = Math.Abs(this.y - A.y);
            int maxMove = 3;

            if (xsteps >= ysteps)
            {
                if (maxMove > xsteps)
                {
                    for (int i = 0; i < xsteps; i++)
                    {
                        this.Move(xdirection, 0, grid);
                        Thread.Sleep(100);
                    }
                }
                else
                {
                    for (int i = 0; i < maxMove; i++)
                    {
                        this.Move(xdirection, 0, grid);
                        Thread.Sleep(100);
                    }
                }
            }
            else
            {
                if (maxMove > ysteps)
                {
                    for (int i = 0; i < ysteps; i++)
                    {
                        this.Move(0, ydirection, grid);
                        Thread.Sleep(100);
                    }
                }
                else
                {
                    for (int i = 0; i < maxMove; i++)
                    {
                        this.Move(0, ydirection, grid);
                        Thread.Sleep(100);
                    }
                }
            }
        }

        public int Lose(Hero a)
        {
            if (this.x == a.x && this.y == a.y)
            {
                Console.WriteLine("Zombie " + Name + " ate the human!");
                return 1;
            }
            else { return 0; }
        }
    }

    class Hero
    {
        public int x;
        public int y;

        public Hero(int xpos, int ypos)
        {
            x = xpos;
            y = ypos;
        }

        public void placeInGrid(int[,] grid)
        {
            grid[x, y] = 2;
        }

        public void RemoveFromGrid(int[,] grid)
        {
            grid[x, y] = 0;
        }
        public void Move(int xnew, int ynew, int[,] grid)
        {
            this.RemoveFromGrid(grid);
            if (grid[x + xnew, y + ynew] != 1 && grid[x + xnew, y + ynew] != 3)
            {
                x += xnew;
                y += ynew;
            }
            this.placeInGrid(grid);

            Console.WriteLine(Program.printGrid(grid));



        }
    }

    class Rock
    {
        public int x;
        public int y;

        public Rock(int xpos, int ypos)
        {
            x = xpos;
            y = ypos;
        }

        public void placeInGrid(int[,] grid)
        {
            grid[x, y] = 3;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight = 25;
            Console.BufferWidth = Console.WindowWidth = 80;
            int[,] matrix = new int[20, 40];
            Array.Clear(matrix, 0, matrix.Length);


            List<Alines> All = new List<Alines>();
            List<Rock> allRocks = new List<Rock>();
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\ArgiDUX\Desktop\DataBase.txt");

            foreach (string value in lines)
            {
                string[] temp = value.Split(',');
                All.Add(new Alines(int.Parse(temp[0]), int.Parse(temp[1]), temp[2]));
            }

            string[] lines1 = System.IO.File.ReadAllLines(@"C:\Users\ArgiDUX\Desktop\Rocks.txt");

            foreach (string value in lines1)
            {
                string[] temp = value.Split(',');
                allRocks.Add(new Rock(int.Parse(temp[0]), int.Parse(temp[1])));
            }
            //Read From file


            Hero c = new Hero(10, 15);
            c.placeInGrid(matrix);

            foreach (Alines value in All)
            {
                value.placeInGrid(matrix);
            }

            foreach (Rock value in allRocks)
            {
                value.placeInGrid(matrix);
            }
            int count = 0;
            Console.WriteLine(printGrid(matrix));
            while (count < 20)
            {
                int heromove = 3;
                for (int i = 0; i < heromove; i++)
                {
                    Console.SetCursorPosition(50, 10);
                    Console.WriteLine("Moves:{0}/3", i + 1);
                    ConsoleKeyInfo userInput = Console.ReadKey();
                    if (userInput.Key == ConsoleKey.LeftArrow && c.y >= 1)
                    {
                        c.Move(0, -1, matrix);
                    }
                    if (userInput.Key == ConsoleKey.RightArrow && c.y <= Console.BufferWidth - 1)
                    {
                        c.Move(0, 1, matrix);
                    }
                    if (userInput.Key == ConsoleKey.UpArrow && c.x >= 1)
                    {
                        c.Move(-1, 0, matrix);
                    }
                    if (userInput.Key == ConsoleKey.DownArrow && c.x < Console.BufferHeight - 1)
                    {
                        c.Move(1, 0, matrix);
                    }
                }
                foreach (Alines value in All)
                {
                    value.zombieMove(c, matrix);
                    if (value.Lose(c) == 1)
                    {
                        Console.WriteLine(count);
                        return;
                    }
                }
                count++;
            }




        }

        static public string printGrid(int[,] grid)
        {
            Console.SetCursorPosition(0, 0);
            string result = string.Empty;
            //result += " 0123456789";
            result += System.Environment.NewLine;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                //result += i.ToString();
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    switch (grid[i, j])
                    {
                        case 0:
                            result += " ";
                            break;
                        case 1:
                            result += "Z";
                            break;
                        case 2:
                            result += "H";
                            break;
                        case 3:
                            result += "@";
                            break;
                        default:
                            break;
                    }
                }
                result += System.Environment.NewLine;
            }
            //Array.Clear(grid, 0, grid.Length);
            return result;
        }

    }


}
