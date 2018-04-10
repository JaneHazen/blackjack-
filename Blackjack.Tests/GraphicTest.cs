using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blackjack.Interfaces;


namespace Blackjack.Tests
{
    [TestClass]
    public class GraphicTest
    {
        Graphic Pic;

        [TestInitialize]
        public void Init()
        {
            var line = new int[] { 7, 4, 3 };
            var map = new int[3][];

            map[0] = line;
            map[1] = line;
            map[2] = line;

            Pic = new Graphic(map);
        }

        [TestMethod]
        public void TestColorMap() 
        {
            // arrange
            var expected = new Color[3][]; 
            var colors = new Color[] { Color.Red, Color.Green, Color.Blue };
            expected[0] = colors;
            expected[1] = colors;
            expected[2] = colors;

            // act
            var actual = Pic.ColorMap();

            // assert
            CollectionAssert.AreEqual(expected[0], actual[0]);
            CollectionAssert.AreEqual(expected[1], actual[1]);
            CollectionAssert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected.Length, actual.Length);
        }
    }
}
