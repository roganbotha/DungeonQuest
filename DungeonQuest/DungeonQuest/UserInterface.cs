using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    public class UserInterface
    {
        public void Output(string thingToPrint, params object[] otherThings)
        {
            Console.WriteLine(thingToPrint, otherThings);
        }
        public string Input(object message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        public string Input()
        {
            return Console.ReadLine();
        }
    }
}
