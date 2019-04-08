using NUnit.Framework;
using GameServer;
using System.Drawing;

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
            var res = game.GetBlocks();
            Assert.AreEqual(5, res.Count);
        }

        [Test]
        public void EachElementofTheBlockListShouldHaveCoodinateWithingTheBoardGame()
        {
            var listOfBlocks = game.GetBlocks();

            foreach (Point p in listOfBlocks)
            {
                Assert.IsTrue(p.X > 0);
                Assert.IsTrue(p.X < game.Width - game.BlocSize);
                Assert.IsTrue(p.Y > 0);
                Assert.IsTrue(p.Y < game.Width - game.BlocSize);
            }
        }

    }
}