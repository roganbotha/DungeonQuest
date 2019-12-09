using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    class TrapTile : Tile
    {
        public TrapTile(int directionEnteredFrom0To3) : base(directionEnteredFrom0To3)
        {
            for (int i = 0; i < 4; i++)
                entrances[i] = 1;
        }

        public override void TileDoThings(Player playerToDoThingsOnTile)
        {
            Factory.Console.Output("You enter a trapped room! Press [ENTER] to draw a trap card.");
            Factory.Console.Input();
            TrapCard trap = new TrapCard();
            trap.Draw(playerToDoThingsOnTile);
        }
    }
}
