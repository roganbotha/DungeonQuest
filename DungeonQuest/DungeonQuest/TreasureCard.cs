using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    class TreasureCard : Card
    {
        public override void Draw(Player playerToDraw)
        {

            string treasureName;
            int treasureValue;
            switch (Factory.RNG.DrawTreasureCard())
            {
                case 1:
                    treasureName = "Large Ruby";
                    treasureValue = 800;
                    break;
                case 2:
                    treasureName = "The Harp of Nantukamun";
                    treasureValue = 2000;
                    break;
                case 3:
                    treasureName = "Blackstaff's Black Staff";
                    treasureValue = 1500;
                    break;
                case 4:
                    treasureName = "The Jewled Necklace of Svordell";
                    treasureValue = 1200;
                    break;
                case 5:
                    treasureName = "Emerald Scarab";
                    treasureValue = 700;
                    break;
                case 6:
                    treasureName = "The Ring of Avyanna";
                    treasureValue = 1700;
                    break;
                case 7:
                    treasureName = "The Golden Panther";
                    treasureValue = 1300;
                    break;
                case 8:
                    treasureName = "The Wand of Lost Wishes";
                    treasureValue = 400;
                    break;
                case 9:
                    treasureName = "Mana Star of Locus Magia";
                    treasureValue = 3000;
                    break;
                case 10:
                    treasureName = "Eldred's Cloak";
                    treasureValue = 1999;
                    break;
                case 11:
                    treasureName = "Sapphire Dragon Claw";
                    treasureValue = 650;
                    break;
                case 12:
                    treasureName = "Small Ruby";
                    treasureValue = 50;
                    break;
                case 13:
                    treasureName = "Cup of Eternal Youth (Just add water!)";
                    treasureValue = 5;
                    break;
                case 14:
                    treasureName = "Eye of the Millaj";
                    treasureValue = 1111;
                    break;
                case 15:
                    treasureName = "Blade of Black Alvor";
                    treasureValue = 1550;
                    break;
                case 16:
                    treasureName = "Crystal dagger";
                    treasureValue = 500;
                    break;
                case 17:
                    treasureName = "Bag of jewels";
                    treasureValue = 300;
                    break;
                case 18:
                    treasureName = "Crown of the First Emperor";
                    treasureValue = 900;
                    break;
                case 19:
                    treasureName = "Golden Glaives of Luna.";
                    treasureValue = 1200;
                    break;
                case 20:
                    treasureName = "Headress of the Sun";
                    treasureValue = 750;
                    break;
                case 21:
                    treasureName = "Purse of Gold";
                    treasureValue = 100;
                    break;
                case 22:
                    treasureName = "Bag of Gold";
                    treasureValue = 200;
                    break;
                case 23:
                    treasureName = "Sack of Gold";
                    treasureValue = 450;
                    break;
                case 24:
                    treasureName = "Daemon Blade of Malice";
                    treasureValue = 3500;
                    playerToDraw.Health -= 5;
                    break;
                case 25:
                    treasureName = "Particularly Large Golden Monkey";
                    treasureValue = 2500;
                    playerToDraw.Agility -= 1;
                    break;
                default:
                    treasureName = "Lodestone";
                    treasureValue = 1;
                    break;
            }
            Factory.Console.Output(treasureName + ": " + treasureValue + "GP");
            Treasure treasureGot = new Treasure(treasureName, treasureValue);
            playerToDraw.AddLoot(treasureGot);
        }
    }
}
