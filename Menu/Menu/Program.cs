using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] menuText = { "Start", "Options", "HighScore", "Exit" };
            int select = 0;
            printMenu(select, menuText);

            while (true)
            {
                
                ConsoleKeyInfo userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.UpArrow && select>=1)
                {
                    select--;
                }
                if (userInput.Key == ConsoleKey.DownArrow && select<=menuText.Length-2)
                {
                    select++;
                }
                if (userInput.Key == ConsoleKey.Enter)
                {
                    break;
                }
              

                printMenu(select, menuText);


            }

        }

        static public void printMenu(int s, string[] menu)
        {
            Console.Clear();
            var total = 40;

            for (int i = 0; i < menu.Length; i++)
            {
                if(i==s)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(menu[i].PadLeft(((total - menu[i].Length) / 2)
                                            + menu[i].Length)
                                   .PadRight(total));
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine(menu[i].PadLeft(((total - menu[i].Length) / 2)
                                            + menu[i].Length)
                                   .PadRight(total));
                }

            }
           // Console.WriteLine(s);
        }
    }
}
