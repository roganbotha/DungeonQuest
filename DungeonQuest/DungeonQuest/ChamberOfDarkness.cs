using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    class ChamberOfDarkness : Tile
    {
        public ChamberOfDarkness(int directionEnteredFrom0To3) : base(directionEnteredFrom0To3)
        {
            for (int i = 0; i < 4; i++)
                entrances[i] = 1;
            entrances[(directionEnteredFrom0To3 + Factory.RNG.RandomDirection1To3()) % 4] = 0;
            
        }
        public override void TileDoThings(Player playerToDoThingsOnTile)
        {
            Factory.Console.Output("You have entered a chamber of darkness. You randomly grope in the darkness until you find an exit.");
            Factory.Console.Input();
            while (true)
            {
                int directionChosen = Factory.RNG.RandomDirection0To3();
                switch (directionChosen)
                {
                    case 0:
                        Factory.Console.Output("You went North.");
                        break;
                    case 1:
                        Factory.Console.Output("You went East.");
                        break;
                    case 2:
                        Factory.Console.Output("You went South.");
                        break;
                    case 3:
                        Factory.Console.Output("You went West.");
                        break;
                }
                if (playerToDoThingsOnTile.CanGoInThisDirection(directionChosen))
                {
                    playerToDoThingsOnTile.GoInDirection(directionChosen);
                    Factory.Console.Input();
                    break;
                }
                else
                {
                    Factory.Console.Output("That's a wall. Try again.");
                }
                Factory.Console.Input();
            }
        }
    }
}
