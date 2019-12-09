using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    public class Timer
    {
        public int turn = 0;
        public bool IncrementTimer()
        {
            bool haveDisplayedMessage = false;
            turn++;
            if (turn > 40 && turn <= 45)
            {
                Factory.Console.Output("The sun's getting low.");
                haveDisplayedMessage = true;
            }
            else if (turn > 45 && Factory.RNG.RollD6()>= turn - 45)
            {
                Factory.Console.Output("The sun's getting real low.");
                haveDisplayedMessage = true;
            }
            else if (turn > 45)
            {
                Factory.Console.Output("The doors to the dungeon have shut! Dragon Lord Kallandra stalks the night.");
                Players.Instance.EndGame();
                haveDisplayedMessage = true;
            }
            return haveDisplayedMessage;
        }
    }
}
