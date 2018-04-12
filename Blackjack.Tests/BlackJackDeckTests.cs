using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blackjack.Tests
{
    [TestClass]
    public class BlackJackDeckTests
    {
        [TestMethod]
        public void TestBasicDeckConstructor()
        {
            //arrange
            //A new deck should have 52 cards
            var expectedCardsNum = 52;
            var wrongNumberOfCards = 50;

            //act
            var deck = new BlackjackDeck();
            var deck2 = new BlackjackDeck();
            var actualCardsNum = deck.Cards.Count();
            var deck2ActualCardsNum = deck2.Cards.Count();

            //assert 
            Assert.AreEqual(expectedCardsNum , actualCardsNum);
            Assert.AreNotEqual(wrongNumberOfCards , deck2ActualCardsNum);
        }
    }
}
