using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(180, 50);
            Console.WriteLine("Welcome to DungeonQuest! [ENTER]");
            Console.ReadLine();
            Console.WriteLine("You are a band of adventurers, trying to loot the treasure chamber of the Dragon Lord Kalladra. [ENTER]");
            Console.ReadLine();
            Console.WriteLine("To win, you must loot her treasure chamber located somewhere in this dungeon, and then escape before sundown. [ENTER]");
            Console.ReadLine();
            Console.WriteLine("(Press [P] at any point to check your stats). [ENTER]");
            Console.ReadLine();
            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();
            Player player1;
            if (name.Equals("HugoTheGlorious") || name.Equals("Hugo The Glorious") || name.Equals("HUGO THE GLORIOUS"))
            {
                player1 = new HugoTheGlorious(name);
            }
            else if(name.Equals("Chandralla") || name.Equals("Chandralla and Brightblaze") || name.Equals("ChandrallaAndBrightblaze"))
            {
                player1 = new ChandrallaAndBrightblaze(name);
            }
            else if (name.Equals("Brother Gherrin") || name.Equals("Brother Gherkin") || name.Equals("BrotherGherkin"))
            {
                player1 = new BrotherGherkin(name);
            }
            else
            {
                player1 = new Player(name);
            }
            while (true)
            {
                Console.WriteLine("Add another player? [Y/N]");
                string userInput = Console.ReadLine().ToUpper();
                if (userInput.Equals("Y"))
                {
                    Console.WriteLine("Please enter your name:");
                    Player playerN;
                    name = Console.ReadLine();
                    if (name.Equals("HugoTheGlorious") || name.Equals("Hugo The Glorious") || name.Equals("HUGO THE GLORIOUS"))
                    {
                        playerN = new HugoTheGlorious(name);
                    }
                    else if (name.Equals("Chandralla") || name.Equals("Chandralla and Brightblaze") || name.Equals("ChandrallaAndBrightblaze"))
                    {
                        playerN = new ChandrallaAndBrightblaze(name);
                    }
                    else if (name.Equals("Brother Gherrin") || name.Equals("Brother Gherkin") || name.Equals("BrotherGherkin"))
                    {
                        playerN = new BrotherGherkin(name);
                    }
                    else
                    {
                        playerN = new Player(name);
                    }
                }
                else
                    break;
            }
            while (Players.Instance.GetPlayerCount() > 0)
            {
                Players.Instance.TakeATurn();
            }
            
        }
    }
}
