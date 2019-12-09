using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    class CorpseCard : Card
    {
        public override void Draw(Player playerToDraw)
        {
            switch (Factory.RNG.DrawCorpseCard())
            {
                case 1:
                    Factory.Console.Output("The corpse was empty.");
                    break;
                case 2:
                    Factory.Console.Output("The corpse hid a nest of small scorpions! Suffer 1d6-2 wounds");
                    Factory.Console.Input();
                    int damage = Factory.RNG.RollD6();
                    Factory.Console.Output("You rolled {0}.", damage);
                    damage -= 2;
                    if (damage < 0)
                        damage = 0;
                    playerToDraw.Health -= damage;
                    break;
                case 3:
                    Factory.Console.Output("The corpse hid a nest of scorpions! Suffer 1d6-1 wounds");
                    Factory.Console.Input();
                    int damage1 = Factory.RNG.RollD6();
                    Factory.Console.Output("You rolled {0}.", damage1);
                    damage1 -= 2;
                    if (damage1 < 0)
                        damage1 = 0;
                    playerToDraw.Health -= damage1;
                    break;
                case 4:
                    Factory.Console.Output("The corpse hid a huge scorpion! Suffer 1d6 wounds");
                    Factory.Console.Input();
                    int damage2 = Factory.RNG.RollD6();
                    Factory.Console.Output("You rolled {0}.", damage2);
                    damage2 -= 2;
                    if (damage2 < 0)
                        damage2 = 0;
                    playerToDraw.Health -= damage2;
                    break;
                case 5:
                    Factory.Console.Output("You found an Unstable Potion!");
                    playerToDraw.NumberOfUnstablePotions++;
                    break;
                case 6:
                    Factory.Console.Output("You found some gold! (150 gold)");
                    playerToDraw.GoldValue += 150;
                    break;
                case 7:
                    Factory.Console.Output("You found some gold! (20 gold)");
                    playerToDraw.GoldValue += 20;
                    break;
                case 8:
                    Factory.Console.Output("You found some gold! (250 gold)");
                    playerToDraw.GoldValue += 250;
                    break;
                case 9:
                    Factory.Console.Output("You found an Unstable Potion!");
                    playerToDraw.NumberOfUnstablePotions++;
                    break;
            }
        }
    }
}
