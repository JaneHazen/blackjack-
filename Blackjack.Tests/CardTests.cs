using System;
using Blackjack.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blackjack.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void TestCardConstructor()
        {
            //Arrange 
            var expectedSuit = CardSuit.Club;
            var expectedRank = CardRank.King;
            var expectedValue = 10;
            var expectedIsHidden = true;
            var value = 10;

            //Act 
            Card myCard = new Card(CardSuit.Club, CardRank.King, value);

            //Arrange 
            Assert.AreEqual(expectedSuit, myCard.Suit);
            Assert.AreEqual(expectedRank, myCard.Rank);
            Assert.AreEqual(expectedValue, myCard.Value);
            Assert.AreEqual(expectedIsHidden, myCard.IsHidden);
            
        }
    }
}
