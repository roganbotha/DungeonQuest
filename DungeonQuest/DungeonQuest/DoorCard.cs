using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    class DoorCard : Card
    {
        public override void Draw(Player playerToDraw)
        {
            switch (Factory.RNG.DrawDoorCard())
            {
                case 1:
                    Factory.Console.Output("The door opens.");
                    break;
                case 2:
                    Factory.Console.Output("The door opens.");
                    break;
                case 3:
                    Factory.Console.Output("The door was trapped! Press [ENTER] to draw a trap card.");
                    Factory.Console.Input();
                    TrapCard trap = new TrapCard();
                    trap.Draw(playerToDraw);
                    break;
                case 4:
                    Factory.Console.Output("There was a monster hiding behind the door!");
                    Factory.Console.Input();
                    playerToDraw.Fight();
                    break;
                case 5:
                    Factory.Console.Output("Potion trap! You were splashed with an Unstable Potion.");
                    Factory.Console.Input();
                    playerToDraw.NumberOfUnstablePotions++;
                    playerToDraw.DrinkUnstablePotion();
                    break;
                case 6:
                    Factory.Console.Output("The door opened a trap door beneath your feet! You fell into the catacombs.");
                    playerToDraw.isInCatacombs = true;
                    break;
                default:
                    Factory.Console.Output("The door opens.");
                    break;
            }
        }
    }
}
