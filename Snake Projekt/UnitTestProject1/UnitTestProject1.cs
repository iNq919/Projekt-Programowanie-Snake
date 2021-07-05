using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SnakeNS;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsGameOver()
        {
            Snake snake = new Snake();
            bool isgame_over = snake.game_over(1001, 501);
            Assert.AreEqual(true, isgame_over);
        }
        [TestMethod]
        public void IsSnakeHittingCollision()
        {
            Snake snake = new Snake();
            snake.randomFood();
            snake.visit[20, 20] = true;
            Assert.AreEqual(true, snake.hits(20, 20));
        }
        [TestMethod]
        public void IsNotGameOver()
        {
            Snake snake = new Snake();
            bool isgame_over = snake.game_over(900, 400);
            Assert.AreEqual(false, isgame_over);
        }
        [TestMethod]
        public void IsSnakeNotHittingCollision()
        {
            Snake snake = new Snake();
            snake.randomFood();
            snake.visit[20, 20] = true;
            Assert.AreEqual(false, snake.hits(17, 17));
        }
    }
}
