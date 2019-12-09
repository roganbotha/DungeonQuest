using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    public class RandomNumberGenerator
    {
        Random singleRNG = new Random();
        public int RollD6()
        {
            return singleRNG.Next(1, 7);
        }
        public int GenerateRandomTile()
        {
            return singleRNG.Next(1, 10);
        }
        public int DrawCorpseCard()
        {
            return singleRNG.Next(1,10);
        }
        public int GenerateNewCorridor2Or3Entrances()
        {
            return singleRNG.Next(1, 5);
        }
        public int RandomDirection1To3()
        {
            return singleRNG.Next(1,4);
        }
        public int DrawCryptCard()
        {
            return singleRNG.Next(1, 7);
        }
        public int DrawDoorCard()
        {
            return singleRNG.Next(1, 8);
        }
        public int Next(int lowestValue, int highestValue)
        {
            return singleRNG.Next(lowestValue, highestValue);
        }
        public int DrawDungeonCard()
        {
            return singleRNG.Next(1, 16);
        }
        public int RandomDirection0To3()
        {
            return singleRNG.Next(0, 4);
        }
        public int RandomMonster()
        {
            return singleRNG.Next(1, 15);
        }
        public int MonsterAttack()
        {
            return singleRNG.Next(0, 3);
        }
        public int DrawTrapCard()
        {
            return singleRNG.Next(1, 10);
        }
        public int DrawTreasureCard()
        {
            return singleRNG.Next(1, 27);
        }
        public int RandomXPosition()
        {
            return singleRNG.Next(0, 8);
        }
        public int RandomYPosition()
        {
            return singleRNG.Next(0, 11);
        }
        public int MakeADoorPassageWayOrWall()
        {
            return singleRNG.Next(0, 3);
        }
        public int SearchDungeonChamber()
        {
            return singleRNG.Next(1, 8);
        }
        public int DrawCatacombCard()
        {
            return singleRNG.Next(1, 14);
        }
        public int RandomizeStats()
        {
            return RollD6() + RollD6();
        }
        public int RandomizeHealth()
        {
            return singleRNG.Next(13, 21);
        }
    }
}
