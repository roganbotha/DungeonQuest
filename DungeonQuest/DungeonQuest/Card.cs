using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    abstract public class Card
    {
        public abstract void Draw(Player playerToDraw);
    }
}
