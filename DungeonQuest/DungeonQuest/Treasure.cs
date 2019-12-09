using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    public class Treasure
    {
        public string Name;
        public int GoldValue;
        public Treasure(string name, int goldValue)
        {
            Name = name;
            GoldValue = goldValue;
        }
    }
}
