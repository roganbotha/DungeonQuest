using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    public class DungeonCard : Card
    {
        public override void Draw(Player playerToDraw)
        {
            int dungeonCardToDraw = Factory.RNG.DrawDungeonCard();
            if (playerToDraw.GetType().Equals(typeof(ChandrallaAndBrightblaze)))
            {
                switch (dungeonCardToDraw)
                {
                    case 1:
                        Factory.Console.Output("You draw an Empty Room card.");
                        break;
                    case 2:
                        Factory.Console.Output("You draw an Ambush card.");
                        break;
                    case 3:
                        Factory.Console.Output("You draw a Hidden Trap card.");
                        break;
                    case 4:
                        Factory.Console.Output("You draw a Corpse card.");
                        break;
                    case 5:
                        Factory.Console.Output("You draw a Crypt card.");
                        break;
                    case 6:
                        Factory.Console.Output("You draw a Gold card. (100G)");
                        break;
                    case 7:
                        Factory.Console.Output("You draw a Gold card. (50G)");
                        break;
                    case 8:
                        Factory.Console.Output("You draw a Gold card. (200G)");
                        break;
                    case 9:
                        Factory.Console.Output("You draw a Wizard's Curse card.");
                        break;
                    case 10:
                        Factory.Console.Output("You draw an Unstable Potion card.");
                        break;
                    case 11:
                        Factory.Console.Output("You draw an Unstable Potion card.");
                        break;
                    case 12:
                        Factory.Console.Output("You draw a Grumpy Wizard card.");
                        break;
                    default:
                        Factory.Console.Output("You draw an Empty Room card.");
                        break;
                }
                Factory.Console.Output("Re-draw? [Y/N]");
                string input = Factory.Console.Input().ToUpper();
                switch (input)
                {
                    case "Y":
                        dungeonCardToDraw = Factory.RNG.DrawDungeonCard();
                        break;
                    default:
                        break;
                }
            }
            DrawWithNumber(playerToDraw, dungeonCardToDraw);
        }
        public void DrawWithNumber(Player playerToDraw, int dungeonCardNum)
        {
            switch (Factory.RNG.DrawDungeonCard())
            {
                case 1:
                    Factory.Console.Output("The room is empty.");
                    break;
                case 2:
                    Factory.Console.Output("Ambush!");
                    playerToDraw.Fight();
                    break;
                case 3:
                    Factory.Console.Output("Hidden Trap! Draw a trap card.");
                    Factory.Console.Input();
                    TrapCard newTrap = new TrapCard();
                    newTrap.Draw(playerToDraw);
                    break;
                case 4:
                    Factory.Console.Output("You find the corpse of an unfortunate explorer. Loot it? [Y/N]");
                    string input = Factory.Console.Input().ToUpper();
                    switch (input)
                    {
                        case "Y":
                            CorpseCard newCorpseCard = new CorpseCard();
                            newCorpseCard.Draw(playerToDraw);
                            break;
                        default:
                            break;
                    }
                    break;
                case 5:
                    Factory.Console.Output("You find the crypt of a long dead warrior. Loot the crypt? [Y/N]");
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
                case 6:
                    Factory.Console.Output("You found some gold! (100 gold)");
                    playerToDraw.GoldValue += 100;
                    break;
                case 7:
                    Factory.Console.Output("You found some gold! (50 gold)");
                    playerToDraw.GoldValue += 50;
                    break;
                case 8:
                    Factory.Console.Output("You found some gold! (200 gold)");
                    playerToDraw.GoldValue += 200;
                    break;
                case 9:
                    Factory.Console.Output("Wizard's Curse! Rotate all coridoors 90 degrees.");
                    foreach (Tile thisParticularTile in Board.Instance.Tiles)
                    {
                        if (thisParticularTile != null && thisParticularTile.GetType().Equals(typeof(Corridor)))
                        {
                            thisParticularTile.Rotate();
                        }
                    }
                    break;
                case 10:
                    Factory.Console.Output("You found an Unstable Potion!");
                    playerToDraw.NumberOfUnstablePotions++;
                    break;
                case 11:
                    Factory.Console.Output("You found an Unstable Potion!");
                    playerToDraw.NumberOfUnstablePotions++;
                    break;
                case 12:
                    Factory.Console.Output("You encounter a grumpy Wizard who telports you to a random room in the dungeon.");
                    playerToDraw.XPosition = Factory.RNG.RandomXPosition();
                    playerToDraw.YPosition = Factory.RNG.RandomYPosition();
                    Factory.Console.Input();
                    Factory.Console.Output("You were teleported to: ({0}, {1})", playerToDraw.XPosition, playerToDraw.YPosition);
                    if (Board.Instance.Tiles[playerToDraw.XPosition, playerToDraw.YPosition] == null)
                    {
                        Board.Instance.MakeNewRandomTile(playerToDraw.XPosition, playerToDraw.YPosition, Factory.RNG.RandomDirection0To3());
                    }
                    Board.Instance.Tiles[playerToDraw.XPosition, playerToDraw.YPosition].TileDoThings(playerToDraw);
                    break;
                default:
                    Factory.Console.Output("The room is empty.");
                    break;
            }
        }
    }
}
