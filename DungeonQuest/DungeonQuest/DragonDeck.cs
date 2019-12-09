using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    public sealed class DragonDeck
    {
        public static int numberOfCardsLeftInDeck = 8;

        private static DragonDeck instance = null;
        private DragonDeck()
        {
        }
        public static DragonDeck Instance
        {
            get
            {
                if (instance == null)
                    instance = new DragonDeck();
                return instance;
            }
        }
        
        public void Draw(Player playerToDraw)
        {
            switch (Factory.RNG.Next(0, numberOfCardsLeftInDeck))
            {
                case 0:
                    Factory.Console.Output("Dragon Rage! Each player in the Treasure Chamber takes 2d6 damage and loses all their treasure.");
                    Factory.Console.Input();
                    int damage = Factory.RNG.RollD6() + Factory.RNG.RollD6();
                    Factory.Console.Output("You rolled {0}", damage);
                    foreach (Player playerInTreasureChamber in Players.playerList)
                    {
                        if (playerInTreasureChamber.YPosition == 5 && (playerInTreasureChamber.XPosition == 3 || playerInTreasureChamber.XPosition == 4))
                        {
                            playerInTreasureChamber.Health -= damage;
                            int treasureCount = playerInTreasureChamber.LootList.Count();
                            for (int i = 0; i < treasureCount; i++)
                                playerInTreasureChamber.LootList.Remove(playerInTreasureChamber.LootList[0]);
                        }
                    }
                    numberOfCardsLeftInDeck = 8;
                    break;
                default:
                    Factory.Console.Output("The dragon sleeps. Draw 2 cards from the treasure deck.");
                    TreasureCard lootGot = new TreasureCard();
                    numberOfCardsLeftInDeck--;
                    lootGot.Draw(playerToDraw);
                    lootGot.Draw(playerToDraw);
                    break;
            }
        }
    }
}
