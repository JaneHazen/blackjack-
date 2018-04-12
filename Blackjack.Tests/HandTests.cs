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
            //arrange a full deck 
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

            var two = new Mock<ICard>(MockBehavior.Strict);
            two.Setup(x => x.Value).Returns(2);
            two.Setup(x => x.Name).Returns("Diamonds");

            // test a return for a hand with zero aces
            var listOfNoAces = new List<ICard> { king.Object, queen.Object };
            var noAcesHand = new Hand(listOfNoAces);
            var noAcesHandExpected = 20;

            // test a return for a hand with one ace that doesn't exceed 21
            var listOfOneAceHighInstance = new List<ICard> { ace1.Object, two.Object};
            var OneAceHighInstance = new Hand(listOfOneAceHighInstance);
            var OneAceHighInstanceExpected = 13;

            //test a return for a hand with one ace that does exceed 21
            var listOfOneAceLowinstance = new List<ICard> { ace1.Object, king.Object, queen.Object };
            var OneAceLowInstance = new Hand(listOfOneAceLowinstance);
            var OneAceLowInstanceExpected = 21;

            //test a return for a hand with two aces that doesn't exceed 21
            var listOfTwoAcesHighInstance = new List<ICard> { ace1.Object, ace2.Object, two.Object};
            var TwoAcesHighInstance = new Hand(listOfTwoAcesHighInstance);
            var TwoAcesHighInstanceExpected = 14;

            //test a return for a hand with two aces that does exceed 21
            var listOfTwoAcesLowInstance = new List<ICard> { ace1.Object, ace2.Object, queen.Object };
            var TwoAcesLowInstance = new Hand(listOfTwoAcesLowInstance);
            var TwoAcesLowInstanceExpected = 12;


            //act
            var noAcesHandActual = noAcesHand.GetTotalValue();
            var OneAceHighInstanceActual = OneAceHighInstance.GetTotalValue();
            var OneAceLowInstanceActual = OneAceLowInstance.GetTotalValue();
            var TwoAcesHighInstanceActual = TwoAcesHighInstance.GetTotalValue();
            var TwoAcesLowInstanceActual = TwoAcesLowInstance.GetTotalValue();

            //assert
            Assert.AreEqual(noAcesHandExpected, noAcesHandActual);
            Assert.AreEqual(OneAceHighInstanceExpected, OneAceHighInstanceActual);
            Assert.AreEqual(OneAceLowInstanceExpected, OneAceLowInstanceActual);
            Assert.AreEqual(TwoAcesHighInstanceExpected, TwoAcesHighInstanceActual);
            Assert.AreEqual(TwoAcesLowInstanceExpected, TwoAcesLowInstanceActual);

        }
    }
}
