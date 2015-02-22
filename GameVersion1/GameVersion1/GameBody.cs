using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GameVersion1
{
    class GameBody
    {
        struct Score
        {
            public string name;
            public int points;
            public DateTime date;

            public Score(string playerName, int p, DateTime dateTime)
            {

                this.name = playerName;
                this.points = p;
                this.date = dateTime;
            }

            public string ToString()
            {
                return name + "-" + points.ToString() + "-" + date.ToString();
            }
        }
        static void Main(string[] args)
        {
            int h = 29;
            int w = 80;
            int tbBorder = 4;
            ConsoleSetUp(w, h);
            DrawBackGround(h, w);


            List<Alien> swarm = new List<Alien>();
            List<Projectile> missles = new List<Projectile>();
            Random rng = new Random();
            int[,] matrix = new int[h - 2 * tbBorder, w / 2];

            string[] menuText = { "Start", "Options", "HighScore", "Exit" };

        Selection:
            int select = 0;
            PrintMenu(select, menuText, w);

            while (true)
            {

                ConsoleKeyInfo userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.UpArrow && select >= 1)
                {
                    select--;
                }//move up selection
                if (userInput.Key == ConsoleKey.DownArrow && select <= menuText.Length - 2)
                {
                    select++;
                } //move down selection
                if (userInput.Key == ConsoleKey.Enter)
                {
                    break; //stop selection process
                } //user input


                PrintMenu(select, menuText, w); //custom print method
            }

            switch (select)
            {
                case 0:
                    ConsoleSetUp(w, h);
                    DrawBackGround(h, w);
                    RunGame(swarm, missles, rng, matrix, tbBorder);
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("Remains to be implemented");

                    Console.ReadLine();
                    goto Selection;
                case 2:
                    PrintHighScore();
                    goto Selection;
                case 3:
                    return;
                default:
                    break;
            }

            //RunGame(swarm, missles, rng, matrix, tbBorder);
        }

        static public void RunGame(List<Alien> swarm, List<Projectile> missles, Random rng, int[,] matrix, int b)
        {
            string[] txtFile = System.IO.File.ReadAllLines("TextFile1.txt");
            for (int i = 0; i < txtFile.Length; i++)
            {
                string[] temp = txtFile[i].Split(',');
                swarm.Add(new Alien(int.Parse(temp[0]), int.Parse(temp[1]), int.Parse(temp[2]), rng.Next(20, 250)));
            }


            foreach (Alien ship in swarm)
            {
                ship.PlaceInGrid(matrix);
            }
            //string monitor = printGrid(matrix);
            // Console.Write(monitor);
            Hero player = new Hero();
            player.PlaceInGrid(matrix);
            while (true)
            {
                int i = GameTurn(swarm, missles, player, matrix, b);
                if (i == 0)
                {
                    break;
                }
                if (swarm.Count == 0)
                {
                    break;
                }
            }

            Console.Clear();
            Console.WriteLine("Game Over");
            Console.WriteLine(player.score);

            HighScore(player);

        }

        static public int GameTurn(List<Alien> s, List<Projectile> p, Hero h, int[,] grid, int b)
        {

            string monitor = printGrid(grid);
            PrintMonitorLine(monitor, h, b);

            //Fire
            foreach (Alien ship in s)
            {
                p.Add(ship.Fire());
                ship.ProgressTime();


                p.RemoveAll(o => o == null);
                ship.Hit_Detect(p, grid, h);
            }

            p.RemoveAll(o => o == null);

            foreach (Projectile missle in p)
            {
                missle.PlaceInGrid(grid);
            }
            // 
            foreach (Projectile missle in p)
            {
                if (missle.x == grid.GetLength(0) - 1 || missle.x == 0)
                {
                    missle.RemoveFromGrid(grid);
                }
                if (missle.y == grid.GetLength(1) - 1 || missle.y == 0)
                {
                    missle.RemoveFromGrid(grid);
                    missle.direction2 *= -2;
                }

            }
            p.RemoveAll(o => o.x == grid.GetLength(0) - 1);
            p.RemoveAll(o => o.x == 0);
            //
            s.RemoveAll(o => o.lives <= 0);
            monitor = printGrid(grid);

            foreach (Projectile missle in p)
            {
                missle.TimeProgress(grid);
            }

            HeroMove(h, grid, p);
            h.Hit(p, grid);

            Thread.Sleep(100);

            if (h.lives > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        static public string printGrid(int[,] grid)
        {
            //Console.SetCursorPosition(0, 2);

            StringBuilder result = new StringBuilder();
            //StringBuilder[] lines= new StringBuilder[grid.GetLength(0)];


            for (int i = 0; i < grid.GetLength(0); i++)
            {
                //result.Append(new string('0', 5));
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    switch (grid[i, j])
                    {
                        case 0:
                            result.Append(" ");
                            break;
                        case 1:
                            result.Append("A");
                            break;
                        case 2:
                            result.Append("o");
                            break;
                        case 3:
                            result.Append("+");
                            break;
                        case 10:
                            result.Append("#");
                            break;
                        default:
                            break;
                    }
                }
                result.Append(System.Environment.NewLine);

            }

            return result.ToString();
        }

        static public void PrintMonitorLine(string s, Hero h, int b)
        {
            string[] lines = s.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                Console.SetCursorPosition(lines[i].Length / 2, b + i);
                Console.Write(lines[i]);
            }

            Console.SetCursorPosition(lines[1].Length / 2 + lines[0].Length + 2, b + 10);
            Console.Write(h.lives.ToString().PadLeft(5));



            Console.SetCursorPosition(lines[1].Length / 2 + lines[0].Length + 2, b + 12);
            Console.Write(h.score.ToString().PadLeft(5));
        }

        static public void HeroMove(Hero h, int[,] grid, List<Projectile> p)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.LeftArrow && h.y >= 1)
                {
                    h.Move(1, grid);
                }
                if (userInput.Key == ConsoleKey.RightArrow && h.y <= grid.GetLength(1) - 2)
                {
                    h.Move(-1, grid);
                }
                if (userInput.Key == ConsoleKey.UpArrow && h.x >= 5)
                {
                    h.Move(2, grid);
                }
                if (userInput.Key == ConsoleKey.DownArrow && h.x < grid.GetLength(0) - 1)
                {
                    h.Move(-2, grid);
                }
                if (userInput.Key == ConsoleKey.Spacebar)
                {
                    
                    switch (h.powerUpLevel)
                    {
                        case 0:
                            p.Add(h.Fire(0));
                            break;
                        case 1:
                            p.Add(h.Fire(0));
                            p.Add(h.Fire(-1));
                            break;
                        case 2:
                            p.Add(h.Fire(0));
                            p.Add(h.Fire(-1));
                            p.Add(h.Fire(1));
                            break;
                        default:
                            break;
                    }

                }
            }

            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
            }
        }

        static public void ConsoleSetUp(int h, int w)
        {
            Console.WindowHeight = w;
            Console.BufferHeight = w;
            Console.WindowWidth = h;
            Console.BufferWidth = h;
            Console.CursorVisible = false;
        }

        static public void DrawBackGround(int h, int w)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(new string(' ', w * h));
            Console.BackgroundColor = ConsoleColor.Black;
            string gameTitle = " Space Invaders";
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(0, 0);
            Console.Write((gameTitle).PadLeft(((w - gameTitle.Length) / 2)
                                            + gameTitle.Length)
                                   .PadRight(w));

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        static public void HighScore(Hero player)
        {
            Console.WriteLine("Input your Name");
            string playerName = Console.ReadLine();
            Score current = new Score(playerName, player.score, DateTime.Now);

            string[] scores = System.IO.File.ReadAllLines("HighScore.txt");

            List<Score> tempScore = new List<Score>();

            for (int i = 0; i < scores.Length; i++)
            {
                string[] temp = scores[i].Split('-');
                if (temp != null)
                {
                    tempScore.Add(new Score(temp[0], int.Parse(temp[1]), DateTime.Parse(temp[2])));
                }
            }


            tempScore.Add(current);

            tempScore.Sort((x1, x2) => x1.points.CompareTo(x2.points));

            if (tempScore.Count == 11)
            {
                tempScore.RemoveAt(10);
            }
            Console.Clear();
            List<string> output = new List<string>();

            foreach (var item in tempScore)
            {
                output.Add(item.ToString());
                Console.WriteLine(item.ToString());
            }

            System.IO.File.WriteAllLines("HighScore.txt", output.ToArray());
        }

        static public void PrintMenu(int s, string[] menu, int w)
        {
            Console.Clear(); //refresh screen
            var total = w; //should be console width in final version
            Console.CursorVisible = false;
            for (int i = 0; i < menu.Length; i++) //printing cycle
            {
                int n = menu[i].Length % 2 == 0 ? 1 : 0; //take care of even lenght situation
                if (i == s) //set color for the selected option
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; //set color
                    Console.WriteLine((">  " + menu[i]).PadLeft(((total - menu[i].Length) / 2)
                                            + menu[i].Length - n)
                                   .PadRight(total));  //centering text
                    Console.ForegroundColor = ConsoleColor.White;//reset color
                }
                else
                {
                    Console.WriteLine(menu[i].PadLeft(((total - menu[i].Length) / 2)
                                            + menu[i].Length - n)
                                   .PadRight(total));
                }

            }
            // Console.WriteLine(s);
        }

        static public void PrintHighScore()
        {
            Console.Clear();
            string[] scores = System.IO.File.ReadAllLines("HighScore.txt");

            foreach (var item in scores)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
