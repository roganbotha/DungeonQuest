using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    class DungeonTile : Tile
    {
        public bool hasBeenSearched = false;
        public DungeonTile(int directionEnteredFrom0To3) : base(directionEnteredFrom0To3)
        {
            entrances[directionEnteredFrom0To3] = 1;
            for (int i = 0; i < 4; i++)
            {
                if (i != directionEnteredFrom0To3)
                    entrances[i] = Factory.RNG.MakeADoorPassageWayOrWall();
            }
            if (Factory.RNG.Next(0,2) == 0)
            {
                isCatacombEntrance = true;
            }
        }

        public override void TileDoThings(Player playerToDoThingsOnTile)
        {
            if (isCatacombEntrance)
            {
                Factory.Console.Output("You enter a dungeon room with a staircase leading down. Press [ENTER] to draw a dungeon card.");
            }
            else
                Factory.Console.Output("You enter a dungeon room. Press [ENTER] to draw a dungeon card.");
            Factory.Console.Input();
            DungeonCard newCard = new DungeonCard();
            newCard.Draw(playerToDoThingsOnTile);
        }
        public override bool HasBeenSearched()
        {
            return hasBeenSearched;
        }
        public override void Search(Player playerWhoSearches)
        {
            switch (Factory.RNG.SearchDungeonChamber())
            {
                case 1:
                    Factory.Console.Input("Ooh! You found a treasure!");
                    TreasureCard newTreasure = new TreasureCard();
                    newTreasure.Draw(playerWhoSearches);
                    break;
                case 2:
                    Factory.Console.Input("Nice! You found a trap!");
                    TrapCard trapCard = new TrapCard();
                    trapCard.Draw(playerWhoSearches);
                    break;
                case 3:
                    Factory.Console.Input("You found a monster!");
                    playerWhoSearches.Fight();
                    break;
                case 4:
                    Factory.Console.Input("You found a comfy chair. Heal 5 wounds.");
                    playerWhoSearches.Health += 5;
                    break;
                case 5:
                    Factory.Console.Input("You found an Unstable Potion.");
                    playerWhoSearches.NumberOfUnstablePotions++;
                    break;
                default:
                    string input = Factory.Console.Input("You found a secret door! Choose a direction to go in. [N/S/E/W]").ToUpper();
                    while (true)
                    {
                        if (input.Equals("N") && playerWhoSearches.YPosition != 10)
                        {
                            playerWhoSearches.YPosition++;
                            break;
                        }
                        else if (input.Equals("S") && playerWhoSearches.YPosition != 0)
                        {
                            playerWhoSearches.YPosition--;
                            break;
                        }
                        else if (input.Equals("W") && playerWhoSearches.XPosition != 0)
                        {
                            playerWhoSearches.XPosition--;
                            break;
                        }
                        else if (input.Equals("E") && playerWhoSearches.XPosition != 7)
                        {
                            playerWhoSearches.XPosition++;
                            break;
                        }
                        else
                            input = Factory.Console.Input("Invalid input. Can't go off the edge of the map. [N/S/E/W]").ToUpper();
                    }
                    if (Board.Instance.Tiles[playerWhoSearches.XPosition, playerWhoSearches.YPosition] == null)
                    {
                        Board.Instance.MakeNewRandomTile(playerWhoSearches.XPosition, playerWhoSearches.YPosition, Factory.RNG.RandomDirection0To3());
                    }
                    Board.Instance.Tiles[playerWhoSearches.XPosition, playerWhoSearches.YPosition].TileDoThings(playerWhoSearches);
                    break;
            }
            hasBeenSearched = true;
        }
    }
}
