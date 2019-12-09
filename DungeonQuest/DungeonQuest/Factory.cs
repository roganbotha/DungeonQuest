using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    static class Factory
    {
        public static RandomNumberGenerator RNG = new RandomNumberGenerator();
        public static UserInterface Console = new UserInterface();
        public static Timer GameTimer = new Timer();
        public static Rune GenerateRandomRune()
        {
            switch (RNG.Next(0, 4))
            {
                case 0:
                    return new TeleportationRune();
                case 1:
                    return new HealingRune();
                case 2:
                    return new LightningRune();
                default:
                    return new ProtectionRune();
            }
        }
    }
}
