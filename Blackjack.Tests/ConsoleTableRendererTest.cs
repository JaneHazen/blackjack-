using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blackjack.Interfaces;

namespace Blackjack.Tests
{
    [TestClass]
    public class ConsoleTableRendererTest
    {
        ConsoleTableRenderer tableRenderer;

        [TestInitialize]
        public void Init()
        {
            tableRenderer = new ConsoleTableRenderer();
        }

        [TestMethod]
        public void TestPaint()
        {
            // arrange
            var expected0 = ConsoleColor.Black;
            var expected1 = ConsoleColor.White;
            var expected2 = ConsoleColor.DarkMagenta;
            var expected3 = ConsoleColor.Blue;
            var expected4 = ConsoleColor.Green;
            var expected5 = ConsoleColor.Yellow;
            var expected6 = ConsoleColor.DarkYellow;
            var expected7 = ConsoleColor.Red;
            var expected8 = ConsoleColor.Gray;
            var expected9 = Console.BackgroundColor;

            // act
            var actual0 = tableRenderer.Paint(Color.Black);
            var actual1 = tableRenderer.Paint(Color.White);
            var actual2 = tableRenderer.Paint(Color.Purple);
            var actual3 = tableRenderer.Paint(Color.Blue);
            var actual4 = tableRenderer.Paint(Color.Green);
            var actual5 = tableRenderer.Paint(Color.Yellow);
            var actual6 = tableRenderer.Paint(Color.Orange);
            var actual7 = tableRenderer.Paint(Color.Red);
            var actual8 = tableRenderer.Paint(Color.Gray);
            var actual9 = tableRenderer.Paint(Color.Transparent);

            // assert
            Assert.AreEqual(expected0, actual0);
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
            Assert.AreEqual(expected4, actual4);
            Assert.AreEqual(expected5, actual5);
            Assert.AreEqual(expected6, actual6);
            Assert.AreEqual(expected7, actual7);
            Assert.AreEqual(expected8, actual8);
            Assert.AreEqual(expected9, actual9);

        }
    }
}
