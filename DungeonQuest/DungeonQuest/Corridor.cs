using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    class Corridor : Tile
    {
        public Corridor(int directionEnteredFrom0To3) : base(directionEnteredFrom0To3)
        {
            switch (Factory.RNG.GenerateNewCorridor2Or3Entrances())
            {
                case 1:
                    for (int i = 0; i < 4; i++)
                        entrances[i] = 1;
                    entrances[(directionEnteredFrom0To3 + Factory.RNG.RandomDirection1To3()) % 4] = 0;
                    break;
                default:
                    entrances[directionEnteredFrom0To3] = 1;
                    entrances[(directionEnteredFrom0To3 + Factory.RNG.RandomDirection1To3()) % 4] = 1;
                    break;
            }
        }

        public override void TileDoThings(Player playerToDoThingsOnTile)
        {
            Factory.Console.Output("You are in a corridor.");
            playerToDoThingsOnTile.PlayerTakeTurn();
        }
    }
}
