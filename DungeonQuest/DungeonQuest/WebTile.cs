using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DungeonQuest
{
    public class WebTile : Tile
    {
        public WebTile(int directionEnteredFrom0To3) : base(directionEnteredFrom0To3)
        {
            for (int i = 0; i < 4; i++)
                entrances[i] = 1;
        }

        public override void TileDoThings(Player playerToDoThingsOnTile)
        {
            Factory.Console.Output("You are caught in sticky webs!");
        }
        public override bool CanLeave(Player playerToLeave)
        {
            Factory.Console.Output("Test strength.");
            Factory.Console.Output("Your strength: {0}", playerToLeave.Strength);
            Factory.Console.Input();
            int numberRolled = Factory.RNG.RollD6() + Factory.RNG.RollD6();
            Factory.Console.Output("You rolled {0}", numberRolled - playerToLeave.Determination);
            if (numberRolled - playerToLeave.Determination > playerToLeave.Strength)
            {
                Factory.Console.Output("You struggled in the webs, but to no avail.");
                playerToLeave.Determination++;
                return false;
            }
            else
            {
                Factory.Console.Output("You break free of the webs!");
                if (numberRolled > playerToLeave.Strength)
                {
                    playerToLeave.Determination -= numberRolled - playerToLeave.Strength;
                }
                return true;
            }
        }
    }
}