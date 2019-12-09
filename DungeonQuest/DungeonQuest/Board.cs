using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    public sealed class Board
    {
        private static Board instance = null;
        public Tile[,] Tiles = new Tile[8, 11];

        private Board()
        {
            Tiles[7, 10] = new TowerTile();
            Tiles[0, 0] = new TowerTile();
            Tiles[0, 10] = new TowerTile();
            Tiles[7, 0] = new TowerTile();
            Tiles[3, 5] = new TreasureChamber();
            Tiles[4, 5] = new TreasureChamber();
        }

        public static Board Instance
        {
            get
            {
                if (instance == null)
                    instance = new Board();
                return instance;
            }
        }
        public void MakeNewRandomTile(int xPosition, int yPosition, int directionEnteredFrom0to3)
        {
            Tile newTile;
            switch (Factory.RNG.GenerateRandomTile())
            {
                case 1:
                    newTile = new DungeonTile(directionEnteredFrom0to3);
                    break;
                case 2:
                    newTile = new Corridor(directionEnteredFrom0to3);
                    break;
                case 3:
                    newTile = new Corridor(directionEnteredFrom0to3);
                    break;
                case 4:
                    newTile = new TrapTile(directionEnteredFrom0to3);
                    break;
                case 5:
                    newTile = new WebTile(directionEnteredFrom0to3);
                    break;
                case 6:
                    newTile = new CaveInTile(directionEnteredFrom0to3);
                    break;
                case 7:
                    newTile = new ChamberOfDarkness(directionEnteredFrom0to3);
                    break;
                default:
                    newTile = new DungeonTile(directionEnteredFrom0to3);
                    break;
            }
            Board.Instance.Tiles[xPosition, yPosition] = newTile;
        }
    }
}
