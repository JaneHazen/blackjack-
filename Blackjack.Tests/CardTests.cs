﻿using System;
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
            var expectedName = "King";
            var expectedValue = 10;
            var expectedIsHidden = true;

            var name = "King";
            var value = 10;

            //Act 
            Card myCard = new Card(CardSuit.Club, name, value);

            //Arrange 
            Assert.AreEqual(expectedSuit, myCard.Suit);
            Assert.AreEqual(expectedName, myCard.Name);
            Assert.AreEqual(expectedValue, myCard.Value);
            Assert.AreEqual(expectedIsHidden, myCard.IsHidden);
            
        }
    }
}