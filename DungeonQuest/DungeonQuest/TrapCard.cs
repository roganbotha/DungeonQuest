using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    public class TrapCard : Card
    {
        public override void Draw(Player playerToDraw)
        {
            int rolled;
            if (playerToDraw.PlayerHasRune(typeof(ProtectionRune)))
            {
                Factory.Console.Output("You were shielded from the trap by your Rune of Protection.");
                playerToDraw.RemoveRune(typeof(ProtectionRune));
                return;
            }
            switch (Factory.RNG.DrawTrapCard())
            {
                case 1:
                    Factory.Console.Output("Swinging Blades! Test agility.");
                    Factory.Console.Input();
                    Factory.Console.Output("Your agility: " + playerToDraw.Agility);
                    rolled = Factory.RNG.RollD6() + Factory.RNG.RollD6() - playerToDraw.Determination;
                    Factory.Console.Output("You rolled " + rolled);
                    if (rolled > playerToDraw.Agility)
                        playerToDraw.Health = 0;
                    break;
                case 2:
                    Factory.Console.Output("Rolling boulder! Test luck.");
                    Factory.Console.Input();
                    Factory.Console.Output("Your luck:" + playerToDraw.Luck);
                    rolled = Factory.RNG.RollD6() + Factory.RNG.RollD6() - playerToDraw.Determination;
                    Factory.Console.Output("You rolled " + rolled);
                    if (rolled > playerToDraw.Luck)
                    {
                        Factory.Console.Output("Take 2d6 damage.");
                        Factory.Console.Input();
                        int boulderDamage = Factory.RNG.RollD6() + Factory.RNG.RollD6();
                        Factory.Console.Output("You rolled {0}", boulderDamage);
                        playerToDraw.Health -= boulderDamage;
                        playerToDraw.Determination++;
                    }
                    break;
                case 3:
                    Factory.Console.Output("Snakes! Suffer 1d6 wounds.");
                    Factory.Console.Input();
                    rolled = Factory.RNG.RollD6();
                    Factory.Console.Output("You rolled a " + rolled);
                    playerToDraw.Health -= rolled;
                    break;
                case 4:
                    Factory.Console.Output("Ambush! FIGHT!");
                    playerToDraw.Fight();
                    break;
                case 5:
                    Factory.Console.Output("Ceiling Collapses. Rotate the chamber you are in 90 degrees.");
                    Board.Instance.Tiles[playerToDraw.XPosition, playerToDraw.YPosition].Rotate();
                    break;
                case 6:
                    Factory.Console.Output("Spike trap! Suffer 2d6 wounds.");
                    rolled = Factory.RNG.RollD6() + Factory.RNG.RollD6();
                    Factory.Console.Input();
                    Factory.Console.Output("You rolled " + rolled);
                    playerToDraw.Health -= rolled;
                    break;
                case 7:
                    Factory.Console.Output("Teleportation Rune! Warp to a random dungeon room.");
                    playerToDraw.XPosition = Factory.RNG.RandomXPosition();
                    playerToDraw.YPosition = Factory.RNG.RandomYPosition();
                    Factory.Console.Input();
                    Factory.Console.Output("You warped to ({0}, {1})", playerToDraw.XPosition, playerToDraw.YPosition);
                    Factory.Console.Input();
                    if (Board.Instance.Tiles[playerToDraw.XPosition, playerToDraw.YPosition] == null)
                    {
                        Board.Instance.MakeNewRandomTile(playerToDraw.XPosition, playerToDraw.YPosition, Factory.RNG.RandomDirection0To3());
                    }
                    playerToDraw.isInCatacombs = false;
                    Board.Instance.Tiles[playerToDraw.XPosition, playerToDraw.YPosition].TileDoThings(playerToDraw);
                    break;
                case 8:
                    Factory.Console.Output("Dart trap! Test armour.");
                    Factory.Console.Input();
                    Factory.Console.Output("Your armour:" + playerToDraw.Armour);
                    rolled = Factory.RNG.RollD6() + Factory.RNG.RollD6() - playerToDraw.Determination;
                    Factory.Console.Output("You rolled " + rolled);
                    if (rolled > playerToDraw.Armour)
                    {
                        Factory.Console.Output("Take 1d6 damage.");
                        Factory.Console.Input();
                        int dartDamage = Factory.RNG.RollD6();
                        Factory.Console.Output("You rolled {0}", dartDamage);
                        playerToDraw.Health -= dartDamage;
                        playerToDraw.Determination++;
                    }
                    else
                    {
                        if (rolled > playerToDraw.Armour)
                        {
                            playerToDraw.Determination -= playerToDraw.Determination - playerToDraw.Armour;
                        }
                    }
                    break;
                case 9:
                    Factory.Console.Output("Pit trap! Take 1d6 damage and fall into the catacombs.");
                    rolled = Factory.RNG.RollD6();
                    Factory.Console.Output("You rolled " + rolled);
                    playerToDraw.Health -= rolled;
                    playerToDraw.isInCatacombs = true;
                    break;
            }
        }
    }
}
