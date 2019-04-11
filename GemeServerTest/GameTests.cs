using NUnit.Framework;
using GameServer;
using System.Drawing;
using System.Collections.Generic;

namespace Tests
{
    public class GameTests
    {
        private Game game;
        [SetUp]
        public void Setup()
        {
            game = new Game();
        }

        [Test]
        public void GameGetBlocksShouldReturnaListofFiveElements()
        {
            var res = game.BlockEdges;
            Assert.AreEqual(5, res.Count);
        }

        [Test]
        public void EachElementofTheBlockListShouldHaveCoodinateWithingTheBoardGame()
        {
            var listOfBlocks = game.BlockEdges;

            foreach (Point p in listOfBlocks)
            {
                Assert.IsTrue(p.X > 0);
                Assert.IsTrue(p.X < game.Width - game.BlockSize);
                Assert.IsTrue(p.Y > 0);
                Assert.IsTrue(p.Y < game.Width - game.BlockSize);
            }
        }

        [Test]
        public void TargetCoordinateShouldbeOusidetheSquareDefinebyBlockEdgeAndBlockSize()
        {


            var bSet = new HashSet<Point>();

           foreach (var block in game.BlockEdges)
            {
                bSet.Add(block);
            }
            foreach (var t in game.Targets)
            {
                Assert.IsFalse(bSet.Contains(t));
            }


        }

        //[Test]
        //public void PlayersShouldBeOusideBockSquare

    }
}