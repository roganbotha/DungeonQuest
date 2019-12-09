using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    abstract public class Tile
    {
        public int[] entrances = new int[4] { 0, 0, 0, 0 };
        public bool isCatacombEntrance = false;
        public virtual bool HasBeenSearched()
        {
            return true;
        }
        public Tile()
        {
        }
        public Tile(int directionEnteredFrom0To3)
        {
        }

        public void Rotate()
        {
            int temp = entrances[0];
            entrances[0] = entrances[1];
            entrances[1] = entrances[2];
            entrances[2] = entrances[3];
            entrances[3] = temp;
        }
        public abstract void TileDoThings(Player playerToDoThingsOnTile);
        public virtual void Search(Player playerWhoSearches)
        {
            Factory.Console.Output("You cannot search this tile.");
        }
        public virtual bool CanLeave(Player playerToLeave)
        {
            return true;
        }
    }
}
