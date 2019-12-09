using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    class TreasureChamber : Tile
    {
        public TreasureChamber() : base()
        {
            for (int i = 0; i < 4; i++)
                entrances[i] = 1;
        }

        public override void TileDoThings(Player playerToDoThingsOnTile)
        {
            Factory.Console.Output("You have entered the dragon's treasure chamber.");
        }

        public override void Search(Player playerPokingTheDragon)
        {
            DragonDeck.Instance.Draw(playerPokingTheDragon);
        }
    }
}
