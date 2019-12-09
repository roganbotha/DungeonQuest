using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    public sealed class Players
    {
        private static Players instance = null;
        public static List<Player> playerList = new List<Player>();

        private Players()
        {
            
        }
        public static Players Instance
        {
            get
            {
                if (instance == null)
                    instance = new Players();
                return instance;
            }
        }
        public void AddPlayer(Player playerToAdd)
        {
            playerList.Add(playerToAdd);
        }
        public void RemovePlayer(Player playerToRemove)
        {
            playerList.Remove(playerToRemove);
        }
        public int GetPlayerCount()
        {
            return playerList.Count();
        }
        public void EndGame()
        {
            for (int i = 0; i< playerList.Count();i++)
                playerList[i].Health = 0;
        }
        public bool KillPlayersWith0Health()
        {
            int i = 0;
            bool hasKilledPlayer = false;
            while (i < playerList.Count())
            {
                Player thisPlayer = playerList[i];
                if (thisPlayer.Health <= 0)
                {
                    if (!thisPlayer.HasWon)
                    {
                        Factory.Console.Output("{0} has died this turn.", thisPlayer.Name);
                        hasKilledPlayer = true;
                    }
                    playerList.Remove(thisPlayer);
                }
                else
                {
                    i++;
                }
            }
            return hasKilledPlayer;
        }
        public void TakeATurn()
        {
            foreach(Player playerWhosTurnItIs in playerList)
            {
                Console.Clear();
                Factory.Console.Output("It's {0}'s turn. Press [ENTER] to continue.", playerWhosTurnItIs.Name);
                Factory.Console.Input();
                playerWhosTurnItIs.PlayerTakeTurn();
                Factory.Console.Input();

            }
            if(KillPlayersWith0Health())
                Factory.Console.Input();
            if (Factory.GameTimer.IncrementTimer())
                Factory.Console.Input();         
        }
    }
}
