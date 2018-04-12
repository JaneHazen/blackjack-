using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blackjack.Interfaces;
using Moq;
using System.Collections.Generic;

namespace Blackjack.Tests
{
    [TestClass]
    public class HandTests
    {


        [TestMethod]
        public void AddCardTest()
        {
            //arrange
            var King = new Mock<ICard>(MockBehavior.Strict);
            var listOfCards = new List<ICard> { King.Object};
            var actual = new Hand();
            var expected = new Hand(listOfCards);

            //act
            actual.AddCard(King.Object);
            
            //assert
            CollectionAssert.AreEqual(expected.Cards, actual.Cards);
        }
        

        [TestMethod]
        public void GetTotalValueTest()
        {
            //arrange
            var ace1 = new Mock<ICard>(MockBehavior.Strict);
            ace1.Setup(x => x.Name).Returns("Ace");

            var ace2 = new Mock<ICard>(MockBehavior.Strict);
            ace2.Setup(x => x.Name).Returns("Ace");


            var king = new Mock<ICard>(MockBehavior.Strict);
            king.Setup(x => x.Value).Returns(10);
            king.Setup(x => x.Name).Returns("King");

            var queen = new Mock<ICard>(MockBehavior.Strict);
            queen.Setup(x => x.Value).Returns(10);
            queen.Setup(x => x.Name).Returns("Queen");

            var listOfNoAces = new List<ICard> { king.Object, queen.Object };
            var noAcesHand = new Hand(listOfNoAces);
            var noAcesHandExpected = 20;


            //act
            var noAcesHandExpected = noAcesHand.GetTotalValue();

            //assert
            Assert.AreEqual();
        }
    }
}
