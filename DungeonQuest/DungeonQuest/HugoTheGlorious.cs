using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    public class HugoTheGlorious : Player
    {
        public override void Fight()
        {
            base.Fight();
            if (Health > 0)
            {
                RuneList.Add(Factory.GenerateRandomRune());
            }
        }
        public HugoTheGlorious(string name)
        {
            Name = name;
            switch (Factory.RNG.RandomDirection0To3())
            {
                case 0:
                    XPosition = 0;
                    YPosition = 0;
                    break;
                case 1:
                    XPosition = 7;
                    YPosition = 0;
                    break;
                case 2:
                    XPosition = 7;
                    YPosition = 10;
                    break;
                case 3:
                    XPosition = 0;
                    YPosition = 10;
                    break;

            }
            RuneList.Add(Factory.GenerateRandomRune());
            RuneList.Add(Factory.GenerateRandomRune());
            RuneList.Add(Factory.GenerateRandomRune());
            Agility = 6;
            Strength = 10;
            Luck = 5;
            Armour = 8;
            StartingHealth = 17;
            Health = StartingHealth;
            Players.Instance.AddPlayer(this);
        }
    }
}
