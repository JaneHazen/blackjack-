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
        IHand noAcesHand;
        [TestInitialize]
        public void Init()
        {
            var ace1 = new Mock<ICard>(MockBehavior.Strict);
            var ace2 = new Mock<ICard>(MockBehavior.Strict);
            var King = new Mock<ICard>(MockBehavior.Strict);
            var Queen = new Mock<ICard>(MockBehavior.Strict);

            var noAcesHand = new Mock<IHand>(MockBehavior.Strict);
            noAcesHand.Object.AddCard(King.Object);
            noAcesHand.Object.AddCard(Queen.Object);
        }


        [TestMethod]
        public void AddCardTest()
        {
            //arrange
            var King = new Mock<ICard>(MockBehavior.Strict);
            var Queen = new Mock<ICard>(MockBehavior.Strict);
            var noAcesHand = new Mock<IHand>(MockBehavior.Strict);
            var expected = new List<ICard>() { Queen.Object, King.Object};
            //act
            noAcesHand.Object.AddCard(King.Object);
            noAcesHand.Object.AddCard(Queen.Object);

            //assert
            CollectionAssert.AreEqual(expected, noAcesHand.Object.FullHand);
        }


        [TestMethod]
        public void GetTotalValueTest()
        {
            //arrange

            var ace1 = new Mock<ICard>(MockBehavior.Strict);
            var ace2 = new Mock<ICard>(MockBehavior.Strict);
            var king = new Mock<ICard>(MockBehavior.Strict);
            var queen = new Mock<ICard>(MockBehavior.Strict);

            var noAcesHand = new Mock<IHand>()(MockBehavior.Strict);
            //act

            //assert
        }
    }
}
