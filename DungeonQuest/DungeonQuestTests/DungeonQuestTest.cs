using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DungeonQuest;
using Moq;

namespace DungeonQuestTests
{
    [TestFixture]
    public class DungeonQuestTest
    {
        DungeonQuest.Player rogan = new DungeonQuest.Player();

        [Test]
        public void GoNorth10Times_AndCheckIfICanGoNorthAgain()
        {
            rogan.GoNorth();
            rogan.GoNorth();
            rogan.GoNorth();
            rogan.GoNorth();
            rogan.GoNorth();
            rogan.GoNorth();
            rogan.GoNorth();
            rogan.GoNorth();
            rogan.GoNorth();
            rogan.GoNorth();
            //Assert.That(rogan.YPosition, Is.EqualTo(10));
            Assert.That(rogan.CanGoInThisDirection(0), Is.EqualTo(false));
        }

        [Test]
        public void AssertThatTheTileDirectlyToTheNorthHasNotBeenCreatedYet_GoNorth_AndThenCreateIt()
        {
            
            Assert.That(Board.Instance.Tiles[0, 1], Is.Null);
            rogan.GoNorth();
            Assert.That(Board.Instance.Tiles[0, 1], Is.Not.Null);
        }

        [Test]
        public void MakeAPlayerDrawATrapCard_AndAssertThatTheirLifeTotalHasChanged()
        {
            TrapCard trap = new TrapCard();
            int healthBefore = rogan.Health;
            trap.Draw(rogan);
            Assert.That(healthBefore, Is.Not.EqualTo(rogan.Health));
        }

        [Test]
        public void MakeAGameWithOnlyEmptyDungeonRooms_RunToTheDragonChamber_LootIt_RunBackToTheStartingArea_AssertThatThePlayerHasWon()
        {
            Player testPlayer = new Player();
            
            Mock<RandomNumberGenerator> rngMock = new Mock<RandomNumberGenerator>();
            Mock<UserInterface> mockUI = new Mock<UserInterface>();
            rngMock.Setup(m => m.GenerateRandomTile()).Returns(1);
            rngMock.Setup(m => m.DrawDungeonCard()).Returns(1);
            rngMock.Setup(m => m.MakeADoorPassageWayOrWall()).Returns(1);
            //act
            mockUI.Setup(m => m.Input()).Returns("E");
            testPlayer.PlayerTakeTurn();
            testPlayer.PlayerTakeTurn();
            testPlayer.PlayerTakeTurn();
            mockUI.Setup(m => m.Input()).Returns("N");
            testPlayer.PlayerTakeTurn();
            testPlayer.PlayerTakeTurn();
            testPlayer.PlayerTakeTurn();
            testPlayer.PlayerTakeTurn();
            testPlayer.PlayerTakeTurn();
            rngMock.Setup(m => m.Next(0, It.IsAny<Int32>())).Returns(1);
            mockUI.Setup(m => m.Input()).Returns("L");
            testPlayer.PlayerTakeTurn();
            mockUI.Setup(m => m.Input()).Returns("S");
            testPlayer.PlayerTakeTurn();
            testPlayer.PlayerTakeTurn();
            testPlayer.PlayerTakeTurn();
            testPlayer.PlayerTakeTurn();
            testPlayer.PlayerTakeTurn();
            mockUI.Setup(m => m.Input()).Returns("W");
            testPlayer.PlayerTakeTurn();
            testPlayer.PlayerTakeTurn();
            testPlayer.PlayerTakeTurn();
            //assert
            Assert.That(testPlayer.HasWon);

        }
    }
}
