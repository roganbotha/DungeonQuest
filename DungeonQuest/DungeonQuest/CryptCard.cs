using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    class CryptCard : Card
    {
        public override void Draw(Player playerToDraw)
        {
            switch (Factory.RNG.DrawCryptCard())
            {
                case 1:
                    Factory.Console.Output("The crypt was empty.");
                    break;
                case 2:
                    Factory.Console.Output("You find a pile of old bones. Roll a d6");
                    Factory.Console.Input();
                    int playerRoll = Factory.RNG.RollD6();
                    Factory.Console.Output("You rolled {0}.", playerRoll);
                    if (playerRoll <= 3)
                    {
                        Factory.Console.Output("The bones rattled and pull themselves together to attack!");
                        playerToDraw.Fight();
                    }
                    else
                    {
                        Factory.Console.Output("Just a dead adventurer. Loot their corpse? [Y/N]");
                        string input1 = Factory.Console.Input().ToUpper();
                        switch (input1)
                        {
                            case "Y":
                                CorpseCard newCorpseCard = new CorpseCard();
                                newCorpseCard.Draw(playerToDraw);
                                break;
                            case "N":
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case 3:
                    Factory.Console.Output("You found an Unstable Potion!");
                    playerToDraw.NumberOfUnstablePotions++;
                    break;
                case 4:
                    Factory.Console.Output("Hidden trap! Draw a trap card.");
                    Factory.Console.Input();
                    TrapCard newTrap = new TrapCard();
                    newTrap.Draw(playerToDraw);
                    break;
                case 5:
                    Factory.Console.Output("You found some gold! (20 gold)");
                    playerToDraw.GoldValue += 20;
                    break;
                case 6:
                    Factory.Console.Output("You found some gold! (220 gold)");
                    playerToDraw.GoldValue += 120;
                    break;
            };
        }
    }
}
