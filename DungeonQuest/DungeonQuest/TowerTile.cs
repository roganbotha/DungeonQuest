using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    public class TowerTile : Tile
    {
        public TowerTile() : base()
        {
            for (int i = 0; i < 4; i++)
                entrances[i] = 1;
        }
        public override void TileDoThings(Player playerToDoThingsOnTile)
        {
            if (playerToDoThingsOnTile.HasLootedTreasureChamber())
            {
                Factory.Console.Output("Congratulations, {0}! You have won!", playerToDoThingsOnTile.Name);
                Factory.Console.Output("Your name will be entered into the hall of heroes! Is there anything you would like your inscription to say?");
                string inscription = Factory.Console.Input();
                playerToDoThingsOnTile.CashIn();
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\..\..\HallOfHeroes.txt", true))
                {
                    file.WriteLine(DateTime.Now);
                    file.WriteLine(playerToDoThingsOnTile.Name);
                    file.WriteLine("Gold Value: {0}", playerToDoThingsOnTile.GoldValue);
                    file.WriteLine("\"{0}\"", inscription);
                    file.WriteLine();
                }
                playerToDoThingsOnTile.HasWon = true;
                playerToDoThingsOnTile.Health = 0;
            }
            else
            {
                Factory.Console.Input("You have gone back to one of the dungeon entrances.");
            }
        }
    }
}