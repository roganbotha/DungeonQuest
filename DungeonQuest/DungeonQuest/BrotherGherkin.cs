using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    public class BrotherGherkin : Player
    {
        public BrotherGherkin(string name)
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
            Agility = 7;
            Strength = 8;
            Luck = 11;
            Armour = 9;
            StartingHealth = 15;
            Health = StartingHealth;
            Players.Instance.AddPlayer(this);
        }
        public override string PrintOptions()
        {
            return base.PrintOptions() + "Gain Determination [G] ";
        }
    }
}
