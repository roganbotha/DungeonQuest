using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    public class CatacombCard : Card
    {
        public override void Draw(Player playerToDraw)
        {
            playerToDraw.NumberOfCatacombsCards++;
            switch (Factory.RNG.DrawCatacombCard())
            {
                case 1:
                    Factory.Console.Output("You found a way out!");
                    playerToDraw.ExitCatacombs();
                    break;
                case 2:
                    Factory.Console.Output("You found a hole in the ceiling! Test agility. If you suceed, exit the catacombs.");
                    Factory.Console.Input("Your agility: "+ playerToDraw.Agility);
                    int agilityRoll = Factory.RNG.RollD6() + Factory.RNG.RollD6();
                    Factory.Console.Output("You rolled: {0}.", agilityRoll);
                    if (agilityRoll <= playerToDraw.Agility)
                        playerToDraw.ExitCatacombs();
                    break;
                case 3:
                    Factory.Console.Output("Vampire attack! Suffer 1d6 wounds, then test armour.");
                    int vampDamage = Factory.RNG.RollD6();
                    Factory.Console.Input("You take " + vampDamage + " damage.");
                    playerToDraw.Health -= vampDamage;
                    Factory.Console.Input("Your armour: " + playerToDraw.Armour);
                    int armourRoll = Factory.RNG.RollD6() + Factory.RNG.RollD6();
                    Factory.Console.Output("You rolled: {0}.", armourRoll);
                    if (armourRoll > playerToDraw.Armour)
                    {
                        playerToDraw.BittenByVamp = true;
                        Factory.Console.Input("Suffer 1 damage every turn you are in the catacombs.");
                    }
                    break;
                case 4:
                    Factory.Console.Output("You stumble over a corpse in the darkness. Loot it? [Y/N]");
                    string input1 = Factory.Console.Input().ToUpper();
                    switch (input1)
                    {
                        case "Y":
                            CryptCard newCryptCard = new CryptCard();
                            newCryptCard.Draw(playerToDraw);
                            break;
                        default:
                            break;
                    }
                    break;
                case 5:
                    Factory.Console.Output("You found an Unstable Potion!");
                    playerToDraw.NumberOfUnstablePotions++;
                    break;
                case 6:
                    Factory.Console.Output("You found some gold! (250 gold)");
                    playerToDraw.GoldValue += 250;
                    break;
                case 7:
                    Factory.Console.Output("You activated over a tripwire! Draw a trap card.");
                    Factory.Console.Input();
                    TrapCard newTrap = new TrapCard();
                    newTrap.Draw(playerToDraw);
                    break;
                case 8:
                    Factory.Console.Input("A monster leaped out of the darkness!");
                    playerToDraw.Fight();
                    break;
                case 9:
                    Factory.Console.Input("Two monsters attacked!");
                    playerToDraw.Fight();
                    if (playerToDraw.Health > 0)
                        playerToDraw.Fight();
                    break;
                case 10:
                    Factory.Console.Output("You found a large diamond! (4000 gold)");
                    playerToDraw.GoldValue += 4000;
                    break;
                default:
                    Factory.Console.Output("You found a way out!");
                    playerToDraw.ExitCatacombs();
                    break;
            }
        }
    }
}
