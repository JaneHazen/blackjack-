using System;
using System.Collections.Generic;
using System.Linq;
using Blackjack.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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

        [TestMethod]
        public void TestDeckConstructorWithListPassedIn()
        {
            //arrange
            var cardToAdd = new Mock<ICard>(MockBehavior.Strict);
            var expectedCard = cardToAdd.Object;

            //act
            var deck = new BlackjackDeck(new List<ICard> { expectedCard });
            var actualCard = deck.Cards.Last();

            //assert
            Assert.AreEqual(expectedCard , actualCard);
        }

        [TestMethod]
        public void TestBlackjackDeckDeal()
        {
            //arrange
            var deck = new BlackjackDeck();
            var expectedCard = deck.Cards.Last();
            var expectedNumberOfCards = deck.Cards.Count() -1;

            //act
            var actualCard = deck.Deal();
            var actualNumberOfCards = deck.Cards.Count();

            //assert
            Assert.AreEqual(expectedCard , actualCard);
            Assert.AreEqual(expectedNumberOfCards, actualNumberOfCards);
        }

        [TestMethod]
        public void TestBlackjackDeckEmpty()
        {
            //arrange
            var deck = new BlackjackDeck();
            var expectedCount = 0;

            //act
            deck.Empty();
            var actualCount = deck.Cards.Count();

            //assert
            Assert.AreEqual(expectedCount , actualCount);            
        }

        [TestMethod]
        public void TestBlackjackDeckShuffle()
        {
            //arrange
            var deck = new BlackjackDeck();
            var deck2 = new BlackjackDeck();
            
            //act
            
            deck.Shuffle();
         
            //assert
            Assert.AreNotEqual(deck , deck2);
        }
    }
}
