using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeNS;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Snake snake = new Snake();
            Assert.AreEqual(true, snake.Equals);
        }
    }
}
