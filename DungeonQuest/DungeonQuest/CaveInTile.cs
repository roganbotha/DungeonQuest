using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DungeonQuest
{
    internal class CaveInTile : Tile
    {
        public CaveInTile(int directionEnteredFrom0To3) : base(directionEnteredFrom0To3)
        {
            for (int i = 0; i < 4; i++)
                entrances[i] = 1;
        }

        public override void TileDoThings(Player playerToDoThingsOnTile)
        {
            Factory.Console.Output("Cave-In! You must test agility to leave this room.");
        }
        public override bool CanLeave(Player playerToLeave)
        {
            Factory.Console.Output("Test agility.");
            Factory.Console.Output("Your agility: " + playerToLeave.Agility);
            Factory.Console.Input();
            int numberRolled = Factory.RNG.RollD6() + Factory.RNG.RollD6();
            Factory.Console.Output("You rolled "+ (numberRolled - playerToLeave.Determination));
            if (numberRolled-playerToLeave.Determination > playerToLeave.Agility)
            {
                Factory.Console.Output("You tripped over the rocks.");
                playerToLeave.Determination++;
                return false;
            }
            else
            {
                Factory.Console.Output("You succeed!");
                if (numberRolled > playerToLeave.Agility)
                {
                    playerToLeave.Determination -= numberRolled - playerToLeave.Agility;
                }
                return true;
            }
        }
    }
}