using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    public class Player
    {
        public int GoldValue;
        public int XPosition;
        public int YPosition;
        public int Agility;
        public int Strength;
        public int Luck;
        public int Armour;
        public int Determination;
        public int StartingHealth;
        public bool isInCatacombs = false;
        public int NumberOfCatacombsCards;
        public int Health;
        public string Name;
        public int NumberOfUnstablePotions;
        public bool HasWon = false;
        public List<Treasure> LootList = new List<Treasure>();
        public List<Rune> RuneList = new List<Rune>();
        public bool BittenByVamp;

        public Player()
        {
            XPosition = 0;
            YPosition = 0;
            Players.Instance.AddPlayer(this);
        }
        public Player(string name)
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
            Agility = Factory.RNG.RandomizeStats();
            Strength = Factory.RNG.RandomizeStats();
            Luck = Factory.RNG.RandomizeStats();
            Armour = Factory.RNG.RandomizeStats();
            StartingHealth = Factory.RNG.RandomizeHealth();
            Health = StartingHealth;
        Players.Instance.AddPlayer(this);
        }
        public void AddRune(Rune runeToAdd)
        {
            RuneList.Add(runeToAdd);
        }
        public void RemoveRune(Type typeOfRune)
        {
            for (int i = 0; i < RuneList.Count; i++)
            {
                if (RuneList[i].GetType().Equals(typeOfRune))
                {
                    RuneList.Remove(RuneList[i]);
                    break;
                }
            }
        }
        public bool PlayerHasRune(Type typeOfRune)
        {
            bool hasRune = false;
            foreach (Rune thisRune in RuneList)
            {
                if (thisRune.GetType().Equals(typeOfRune))
                    hasRune = true;
            }
            return hasRune;
        }
        public void AddLoot(Treasure newLoot)
        {
            LootList.Add(newLoot);
        }
        public bool HasLootedTreasureChamber()
        {
            if (LootList.Count() > 0)
            {
                return true;
            }
            else
                return false;
        }
        public void CashIn()
        {
            foreach (Treasure treasure in LootList)
            {
                GoldValue += treasure.GoldValue;
            }
        }

        public bool GoInDirection(int directionToTravel_0To3)
        {
            int[] directionArray = new int[4] { 0, 0, 0, 0 };
            directionArray[directionToTravel_0To3] = 1;
            if (CanGoInThisDirection(directionToTravel_0To3))
            {
                int xBeforeDoor = XPosition;
                int yBeforeDoor = YPosition;
                if (Board.Instance.Tiles[XPosition, YPosition].entrances[directionToTravel_0To3] == 2)
                {
                    DoorCard openingDoor = new DoorCard();
                    openingDoor.Draw(this);
                    Board.Instance.Tiles[XPosition, YPosition].entrances[directionToTravel_0To3] = 1;
                }
                
                if (xBeforeDoor == XPosition && yBeforeDoor == YPosition && !isInCatacombs)
                {
                    if (Board.Instance.Tiles[XPosition + directionArray[1] - directionArray[3], YPosition + directionArray[0] - directionArray[2]] == null)
                    {
                        XPosition += directionArray[1] - directionArray[3];
                        YPosition += directionArray[0] - directionArray[2];
                        Board.Instance.MakeNewRandomTile(XPosition, YPosition, (directionToTravel_0To3 + 2) % 4);
                    }
                    else
                    {
                        XPosition += directionArray[1] - directionArray[3];
                        YPosition += directionArray[0] - directionArray[2];
                    }
                    if (Health > 0)
                        Board.Instance.Tiles[XPosition, YPosition].TileDoThings(this);
                }
                return true;
            }
            else
                return false;
        }
        public bool GoNorth()
        {
            return GoInDirection(0);
        }
        public bool GoEast()
        {
            return GoInDirection(1);
        }
        public bool GoSouth()
        {
            return GoInDirection(2);
        }
        public bool GoWest()
        {
            return GoInDirection(3);
        }
        public void PrintPlayerStats()
        {
            Factory.Console.Output("Player name: " + Name);
            Factory.Console.Output("Health:" + Health);
            Factory.Console.Output("Position: (" + XPosition+"," +YPosition+")");

            Factory.Console.Output("=================================");
            Factory.Console.Output("Agility: " + Agility);
            Factory.Console.Output("Strength: " + Strength);
            Factory.Console.Output("Armour: " + Armour);
            Factory.Console.Output("Luck: " + Luck);
            Factory.Console.Output("=================================");
            Factory.Console.Output("Potions: " + NumberOfUnstablePotions);
            Factory.Console.Output("Treasure:");
            Factory.Console.Output("Gold: " + GoldValue);
            for (int i = 0; i < LootList.Count(); i++)
            {
                Factory.Console.Output(LootList[i].Name +": " +LootList[i].GoldValue);
            }
            Factory.Console.Output("Runes:");
            for (int i = 0 ; i < RuneList.Count();i++)
            {
                if (RuneList[i].GetType().Equals(typeof(LightningRune)))
                    Factory.Console.Output("Rune of Lightning");
                else if (RuneList[i].GetType().Equals(typeof(HealingRune)))
                    Factory.Console.Output("Rune of Healing");
                else if (RuneList[i].GetType().Equals(typeof(ProtectionRune)))
                    Factory.Console.Output("Rune of Protection");
                else if (RuneList[i].GetType().Equals(typeof(TeleportationRune)))
                    Factory.Console.Output("Rune of Teleportation");
            }

        }
        public bool CanGoInThisDirection(int directionTravelling)
        {
            bool canGo = true;
            if (XPosition == 7 && directionTravelling == 1)
                canGo = false;
            else if (XPosition == 0 && directionTravelling == 3)
                canGo = false;
            else if (YPosition == 0 && directionTravelling == 2)
                canGo = false;
            else if (YPosition == 10 && directionTravelling == 0)
                canGo = false;
            else if (Board.Instance.Tiles[XPosition, YPosition].entrances[directionTravelling] == 0)
                canGo = false;
            else
            {
                int[] directionArray = new int[4];
                directionArray[directionTravelling] = 1;
                if (Board.Instance.Tiles[XPosition + directionArray[1] - directionArray[3], YPosition + directionArray[0] - directionArray[2]] != null)
                {
                    //if the tile in the direction you are travelling exists and has a wall in your direction
                    if (Board.Instance.Tiles[XPosition + directionArray[1] - directionArray[3], YPosition + directionArray[0] - directionArray[2]].entrances[(directionTravelling + 2) % 4] == 0)
                        canGo = false;
                }
            }
            return canGo;
        }
        public int[] CheckOptions()
        {
            Tile currentTile = Board.Instance.Tiles[XPosition, YPosition];
            int[] availableEntrances = currentTile.entrances;
            if (XPosition == 0)
            {
                availableEntrances[3] = 0;
            }
            else
            {
                if (Board.Instance.Tiles[XPosition - 1, YPosition] != null && Board.Instance.Tiles[XPosition - 1, YPosition].entrances[1] == 0)
                    availableEntrances[3] = 0;
            }
            if (XPosition == 7)
            {
                availableEntrances[1] = 0;
            }
            else
            {
                if (Board.Instance.Tiles[XPosition + 1, YPosition] != null && Board.Instance.Tiles[XPosition + 1, YPosition].entrances[3] == 0)
                    availableEntrances[1] = 0;
            }
            if (YPosition == 0)
            {
                availableEntrances[2] = 0;
            }
            else
            {
                if (Board.Instance.Tiles[XPosition, YPosition-1] != null && Board.Instance.Tiles[XPosition, YPosition - 1].entrances[0] == 0)
                    availableEntrances[2] = 0;
            }
            if (YPosition == 10)
            {
                availableEntrances[0] = 0;
            }
            else
            {
                if (Board.Instance.Tiles[XPosition, YPosition+1] != null && Board.Instance.Tiles[XPosition, YPosition + 1].entrances[2] == 0)
                    availableEntrances[0] = 0;
            }

            return availableEntrances;
        }
        public virtual string PrintOptions()
        {
            string optionsInString = "Available options are: ";
            if (!isInCatacombs)
            {
                int[] availableOptions = CheckOptions();
                if (availableOptions[0] == 1)
                    optionsInString += "North [N] ";
                else if (availableOptions[0] == 2)
                    optionsInString += "North [N] (Door) ";
                if (availableOptions[1] == 1)
                    optionsInString += "East [E] ";
                else if (availableOptions[1] == 2)
                    optionsInString += "East [E] (Door) ";
                if (availableOptions[2] == 1)
                    optionsInString += "South [S] ";
                else if (availableOptions[2] == 2)
                    optionsInString += "South [S] (Door) ";
                if (availableOptions[3] == 1)
                    optionsInString += "West [W] ";
                else if (availableOptions[3] == 2)
                    optionsInString += "Weth [W] (Door) ";
                if (YPosition == 5 && (XPosition == 3 || XPosition == 4))
                    optionsInString += "Loot [L] ";
                if (!Board.Instance.Tiles[XPosition, YPosition].HasBeenSearched())
                    optionsInString += "Search the room [F] ";
                if (Board.Instance.Tiles[XPosition, YPosition].isCatacombEntrance)
                    optionsInString += "Enter the catacombs [C] ";
            }
            else
            {
                optionsInString += "Explore the Catacombs [C] ";
            }
            if (NumberOfUnstablePotions > 0)
                optionsInString += "Drink Unstable Potion [D] ";
            if (PlayerHasRune(typeof(TeleportationRune)))
                optionsInString += "Use Teleportation Rune [T] ";
            if (PlayerHasRune(typeof(HealingRune)))
                optionsInString += "Use Rune of Healing [H] ";
            return optionsInString;
        }
        public bool PlayerHasOptions()
        {
            if (PrintOptions().Equals("Available options are: "))
                return false;
            else
                return true;
        }
        public void PlayerTakeTurn()
        {
            if (Board.Instance.Tiles[XPosition, YPosition].CanLeave(this))
            {
                Factory.Console.Output("You are at ({0}, {1}).", XPosition, YPosition);
                if (PlayerHasOptions())
                {
                    while (Health >0)
                    {
                        Factory.Console.Output("{0}", PrintOptions());
                        string playerSelection = Factory.Console.Input().ToUpper();
                        if (isInCatacombs)
                        {
                            if (playerSelection.Equals("C"))
                            {
                                CatacombCard catacombCard = new CatacombCard();
                                catacombCard.Draw(this);
                                break;
                            }
                        }
                        else
                        {
                            if (playerSelection.Equals("N") && CanGoInThisDirection(0))
                            {
                                GoNorth();
                                break;
                            }
                            else if (playerSelection.Equals("E") && CanGoInThisDirection(1))
                            {
                                GoEast();
                                break;
                            }
                            else if (playerSelection.Equals("S") && CanGoInThisDirection(2))
                            {
                                GoSouth();
                                break;
                            }
                            else if (playerSelection.Equals("W") && CanGoInThisDirection(3))
                            {
                                GoWest();
                                break;
                            }
                            else if (playerSelection.Equals("L") && Board.Instance.Tiles[XPosition, YPosition].GetType().Equals(typeof(TreasureChamber)))
                            {
                                Board.Instance.Tiles[XPosition, YPosition].Search(this);
                                break;
                            }
                            else if (playerSelection.Equals("F") && !Board.Instance.Tiles[XPosition, YPosition].HasBeenSearched())
                            {
                                Board.Instance.Tiles[XPosition, YPosition].Search(this);
                                break;
                            }
                            else if (playerSelection.Equals("C") && Board.Instance.Tiles[XPosition, YPosition].isCatacombEntrance)
                            {
                                Factory.Console.Output("You entered the catacombs.");
                                isInCatacombs = true;
                                break;
                            }
                        }
                        if (playerSelection.Equals("D") && NumberOfUnstablePotions > 0)
                        {
                            DrinkUnstablePotion();
                        }
                        if (playerSelection.Equals("G") && GetType().Equals(typeof(BrotherGherkin)))
                        {
                            Factory.Console.Output("You take 1 damage and gain a Determination.");
                        }
                        else if (playerSelection.Equals("T") && PlayerHasRune(typeof(TeleportationRune)))
                        {
                            XPosition = Factory.RNG.RandomXPosition();
                            YPosition = Factory.RNG.RandomYPosition();
                            Factory.Console.Output("You warped to: ({0}, {1})", XPosition, YPosition);
                            if (Board.Instance.Tiles[XPosition, YPosition] == null)
                            {
                                Board.Instance.MakeNewRandomTile(XPosition, YPosition, Factory.RNG.RandomDirection0To3());
                            }
                            Board.Instance.Tiles[XPosition, YPosition].TileDoThings(this);
                            isInCatacombs = false;
                            RemoveRune(typeof(TeleportationRune));
                            break;
                        }
                        else if (playerSelection.Equals("H") && PlayerHasRune(typeof(HealingRune)))
                        {
                            Factory.Console.Output("You healed 6 wounds.");
                            Health += 6;
                            if (Health >= StartingHealth)
                                Health = StartingHealth;
                            RemoveRune(typeof(HealingRune));
                        }
                        else if (playerSelection.Equals("P"))
                        {
                            PrintPlayerStats();
                        }
                        else
                            Factory.Console.Output("Invalid input.");
                    }
                }
                else
                {
                    Factory.Console.Input("You have no options. You died of starvation.");
                    Health = 0;
                }
                if (BittenByVamp)
                {
                    Health--;
                }
            }
        }

        public void DrinkUnstablePotion()
        {
            int numberRolled = Factory.RNG.RollD6() + Factory.RNG.RollD6();
            Factory.Console.Output("You rolled: {0}", numberRolled);
            switch (numberRolled)
            {
                case 2:
                    Factory.Console.Output("You died.");
                    Health = 0;
                    break;
                case 3:
                    Factory.Console.Output("Suffer 4 wounds.");
                    Health -= 4;
                    break;
                case 4:
                    Factory.Console.Output("Suffer 4 wounds.");
                    Health -= 4;
                    break;
                case 5:
                    Factory.Console.Output("Suffer 4 wounds.");
                    Health -= 4;
                    break;
                case 6:
                    Factory.Console.Output("Nothing happens.");
                    break;
                case 7:
                    Factory.Console.Output("Nothing happens.");
                    break;
                case 8:
                    Factory.Console.Output("Heal 3 wounds.");
                    Health += 3;
                    if (Health > StartingHealth)
                    {
                        Health = StartingHealth;
                    }
                    break;
                case 9:
                    Factory.Console.Output("Heal 3 wounds.");
                    Health += 3;
                    if (Health > StartingHealth)
                    {
                        Health = StartingHealth;
                    }
                    break;
                case 10:
                    Factory.Console.Output("Heal 3 wounds.");
                    Health += 3;
                    if (Health > StartingHealth)
                    {
                        Health = StartingHealth;
                    }
                    break;
                case 11:
                    Factory.Console.Output("Heal all wounds.");
                    Health = StartingHealth;
                    break;
                case 12:
                    Factory.Console.Output("Heal all wounds.");
                    Health = StartingHealth;
                    break;
            }
            NumberOfUnstablePotions--;
        }
        public void ExitCatacombs()
        {
            bool flag = true;
            Factory.Console.Output("You move in a direction equal to the number of catacomb cards you have drawn, then turn, and move 1d6 tiles in another direction.");
            string playerInput = "";
            Factory.Console.Output("Please enter the first direction you would like to travel in: [N/E/S/W]");
            while (flag)
            {
                playerInput = Factory.Console.Input().ToUpper();
                switch (playerInput)
                {
                    case "N":
                        YPosition += NumberOfCatacombsCards;
                        if (YPosition > 10)
                        {
                            Health -= YPosition - 10;
                            Factory.Console.Input("You sprinted head first into a wall.");
                            YPosition = 10;
                        }
                        flag = false;
                        break;
                    case "E":
                        XPosition += NumberOfCatacombsCards;
                        if (XPosition > 7)
                        {
                            Health -= XPosition - 7;
                            Factory.Console.Input("You sprinted head first into a wall.");
                            XPosition = 7;
                        }
                        flag = false;
                        break;
                    case "S":
                        YPosition -= NumberOfCatacombsCards;
                        if (YPosition < 0)
                        {
                            Health += YPosition;
                            Factory.Console.Input("You sprinted head first into a wall.");
                            YPosition = 0;
                        }
                        flag = false;
                        break;
                    case "W":
                        XPosition -= NumberOfCatacombsCards;
                        if (XPosition < 0)
                        {
                            Health += XPosition;
                            Factory.Console.Input("You sprinted head first into a wall.");
                            XPosition = 0;
                        }
                        flag = false;
                        break;
                    default:
                        Factory.Console.Output("Invalid input.");
                        break;
                }
            }
            Factory.Console.Input("Roll a d6 to see how many squares you moved:");
            int numRolled = Factory.RNG.RollD6();
            Factory.Console.Output("You rolled a " + numRolled);
            string playerInput2 = Factory.Console.Input("Please enter the direction you would like to turn: [L/R]").ToUpper();
            while (true)
            {
                if ((playerInput.Equals("N") && playerInput2.Equals("L")) || (playerInput.Equals("S") && playerInput2.Equals("R")))
                {
                    XPosition -= numRolled;
                    if (XPosition < 0)
                    {
                        Health += XPosition;
                        Factory.Console.Input("You sprinted head first into a wall.");
                        XPosition = 0;
                    }
                    break;
                }
                else if ((playerInput.Equals("S") && playerInput2.Equals("L")) || (playerInput.Equals("N") && playerInput2.Equals("R")))
                {
                    XPosition += numRolled;
                    if (XPosition > 7)
                    {
                        Health -= XPosition - 7;
                        Factory.Console.Input("You sprinted head first into a wall.");
                        XPosition = 7;
                    }
                    break;
                }
                else if ((playerInput.Equals("W") && playerInput2.Equals("R")) || (playerInput.Equals("E") && playerInput2.Equals("L")))
                {
                    YPosition += numRolled;
                    if (YPosition > 10)
                    {
                        Health -= YPosition - 10;
                        Factory.Console.Input("You sprinted head first into a wall.");
                        YPosition = 10;
                    }
                    break;
                }
                else if ((playerInput.Equals("W") && playerInput2.Equals("L")) || (playerInput.Equals("E") && playerInput2.Equals("R")))
                {
                    YPosition -= numRolled;
                    if (YPosition < 0)
                    {
                        Health += YPosition;
                        Factory.Console.Input("You sprinted head first into a wall.");
                        YPosition = 0;
                    }
                    break;
                }
                else
                    playerInput2 = Factory.Console.Input("Invalid Input.");
            }
            if (Board.Instance.Tiles[XPosition, YPosition] == null)
                Board.Instance.MakeNewRandomTile(XPosition, YPosition, Factory.RNG.RandomDirection0To3());
            isInCatacombs = false;
            NumberOfCatacombsCards = 0;
            BittenByVamp = false;
            Board.Instance.Tiles[XPosition, YPosition].TileDoThings(this);
        }
        public virtual void Fight()
        {
            string monster="";
            int monsterHealth = Factory.RNG.Next(2,5);
            switch (Factory.RNG.RandomMonster())
            {
                case 1:
                    monster = "Viscous Chicken of Bristol";
                    monsterHealth -= 2;
                    break;
                case 2:
                    monster = "Skeleton";
                    monsterHealth -= 1;
                    break;
                case 3:
                    monster = "Tarrasque";
                    monsterHealth += 100;
                    break;
                case 4:
                    monster = "Sorcerer";
                    break;
                case 5:
                    monster = "Hobgoblin";
                    break;
                case 6:
                    monster = "Mind Flayer";
                    monsterHealth += 1;
                    break;
                case 7:
                    monster = "Beholder";
                    monsterHealth += 2;
                    break;
                case 8:
                    monster = "Troll";
                    monsterHealth += 1;
                    break;
                case 9:
                    monster = "Demon";
                    monsterHealth += 2;
                    break;
                case 10:
                    monster = "Chaos Elemental";
                    monsterHealth = Factory.RNG.Next(-5,10);
                    break;
                case 11:
                    monster = "Deep Elf";
                    monsterHealth = 4;
                    break;
                case 12:
                    monster = "Naga Witch";
                    monsterHealth += 1;
                    break;
                case 13:
                    monster = "Shade";
                    break;
                case 14:
                    monster = "Ferrox";
                    break;

            }
            Factory.Console.Output("You encounter a {0}", monster);
            if (PlayerHasRune(typeof(LightningRune)))
            {
                string choice = Factory.Console.Input("Would you like to use your Rune of Lightning on the "+monster+"? [Y/N]").ToUpper();
                if (choice.Equals("Y") && monster.Equals("Tarrasque"))
                {
                    Factory.Console.Output("The Tarrasque uses you to scratch the itch you gave it.");
                }
                else if (choice.Equals("Y"))
                {
                    monsterHealth = 0;
                    RemoveRune(typeof(LightningRune));
                }
            }
            while (monsterHealth > 0 && Health > 0)
            {
                Factory.Console.Output("Make a choice! Would you like to fight with a Weapon[W], Magic[M] or Ranged[R]?");
                string playerChoice = Factory.Console.Input().ToUpper();
                int monsterChoice = Factory.RNG.MonsterAttack();
                int monsterDamage=0;
                int playerDamage=0;
                if (monster.Equals("Tarrasque"))
                {
                    Factory.Console.Output("RIP, lol.");
                    Health = 0;
                    break;
                }
                switch (playerChoice)
                {
                    case "W":
                        switch (monsterChoice)
                        {
                            case 0:
                                monsterDamage = 2;
                                playerDamage = 2;
                                break;
                            case 1:
                                monsterDamage = 1;
                                playerDamage = 0;
                                break;
                            case 2:
                                monsterDamage = 0;
                                playerDamage = 1;
                                break;
                        }
                        break;
                    case "M":
                        switch (monsterChoice)
                        {
                            case 0:
                                monsterDamage = 0;
                                playerDamage = 1;
                                break;
                            case 1:
                                monsterDamage = 1;
                                playerDamage = 1;
                                break;
                            case 2:
                                monsterDamage = 1;
                                playerDamage = 0;
                                break;
                        }
                        break;
                    case "R":
                        switch (monsterChoice)
                        {
                            case 0:
                                monsterDamage = 1;
                                playerDamage = 0;
                                break;
                            case 1:
                                monsterDamage = 0;
                                playerDamage = 1;
                                break;
                            case 2:
                                monsterDamage = 1;
                                playerDamage = 1;
                                break;
                        }
                        break;
                    default:
                        Factory.Console.Output("Invalid input.");
                        continue;
                }
                Console.Write("The {0} chose to use ", monster);
                switch (monsterChoice)
                {
                    case 0:
                        Factory.Console.Output("a melee weapon.");
                        break;
                    case 1:
                        Factory.Console.Output("magic.");
                        break;
                    case 2:
                        Factory.Console.Output("a ranged weapon.");
                        break;
                }
                Factory.Console.Output("You suffer {0} wounds.", playerDamage);
                Health -= playerDamage;
                Factory.Console.Output("The monster takes {0} damage.", monsterDamage);
                monsterHealth -= monsterDamage;
            }
            if (Health > 0)
            {
                Factory.Console.Output("You defeated the {0}!", monster);
            }
            else
            {
                Factory.Console.Output("You were slain by the {0}.", monster);
            }
        }
    }
}
