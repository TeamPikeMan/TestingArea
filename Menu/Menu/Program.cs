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
                }//move up selection
                if (userInput.Key == ConsoleKey.DownArrow && select<=menuText.Length-2)
                {
                    select++;
                } //move down selection
                if (userInput.Key == ConsoleKey.Enter)
                {
                    break; //stop selection process
                } //user input
              

                printMenu(select, menuText); //custom print method
            }

            
            //Add switch to call other functions

        }

        static public void printMenu(int s, string[] menu)
        {
            Console.Clear(); //refresh screen
            var total = 40; //should be console width in final version
            Console.CursorVisible = false;
            for (int i = 0; i < menu.Length; i++) //printing cycle
            {
                int n = menu[i].Length % 2 == 0 ? 1 : 0; //take care of even lenght situation
                if(i==s) //set color for the selected option
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; //set color
                    Console.WriteLine(("+  "+menu[i]).PadLeft(((total - menu[i].Length) / 2)
                                            + menu[i].Length-n)
                                   .PadRight(total));  //centering text
                    Console.ForegroundColor = ConsoleColor.White;//reset color
                }
                else
                {
                    Console.WriteLine(menu[i].PadLeft(((total - menu[i].Length) / 2)
                                            + menu[i].Length-n)
                                   .PadRight(total));
                }

            }
           // Console.WriteLine(s);
        }
    }
}
