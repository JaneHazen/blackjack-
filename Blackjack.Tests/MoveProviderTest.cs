using System;
using Blackjack.Exceptions;
using Blackjack.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Blackjack.Tests
{
    [TestClass]
    public class MoveProviderTest
    {
        [TestMethod]
        public void TestMoveProviderHit()
        {
            // mock input provider implements console input provider Read() method
            // returns "hit" as if user typed "hit" into console
            var mockInputProvider = new Mock<IInputProvider>(MockBehavior.Strict);
            mockInputProvider.Setup(x => x.Read()).Returns("hit");

            //the mocked input is passed to the move provider, which implements the GetMove()
            //method of the MoveProvider class and returns the move because "hit" is a valid move
            //from the PlayerAction enum
            var moveProvider = new MoveProvider(mockInputProvider.Object);
            var move = moveProvider.GetMove();

            Assert.AreEqual(PlayerAction.hit, move);
        }

        [TestMethod]
        public void TestMoveProviderHitWithNumber()
        {
            // mock input provider implements console input provider Read() method
            // returns "hit" as if user typed "0" into console
            var mockInputProvider = new Mock<IInputProvider>(MockBehavior.Strict);
            mockInputProvider.Setup(x => x.Read()).Returns("0");

            //the mocked input is passed to the move provider, which implements the GetMove()
            //method of the MoveProvider class and returns the move because "0" is a valid move
            //from the PlayerAction enum if the user chooses to hit
            var moveProvider = new MoveProvider(mockInputProvider.Object);
            var move = moveProvider.GetMove();

            Assert.AreEqual(PlayerAction.hit, move);
        }

        [TestMethod]
        public void TestMoveProviderStand()
        {
            // mock input provider implements console input provider Read() method
            // returns "stand" as if user typed "stand" into console
            var mockInputProvider = new Mock<IInputProvider>(MockBehavior.Strict);
            mockInputProvider.Setup(x => x.Read()).Returns("stand");

            //the mocked input is passed to the move provider, which implements the GetMove()
            //method of the MoveProvider class and returns the move because "stand" is a valid move
            //from the PlayerAction enum
            var moveProvider = new MoveProvider(mockInputProvider.Object);
            var move = moveProvider.GetMove();

            Assert.AreEqual(PlayerAction.stand, move);
        }

        [TestMethod]
        public void TestMoveProviderStandWithNumber()
        {
            // mock input provider implements console input provider Read() method
            // returns "hit" as if user typed "0" into console
            var mockInputProvider = new Mock<IInputProvider>(MockBehavior.Strict);
            mockInputProvider.Setup(x => x.Read()).Returns("1");

            //the mocked input is passed to the move provider, which implements the GetMove()
            //method of the MoveProvider class and returns the move because "1" is a valid move
            //from the PlayerAction enum if user chooses to stand
            var moveProvider = new MoveProvider(mockInputProvider.Object);
            var move = moveProvider.GetMove();

            Assert.AreEqual(PlayerAction.stand, move);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void TestGetMoveInvalidInput()
        {
            // create a MockInputProvider that implements IInputProvider
            // Have Read() return something that CAN'T be parsed into the
            // PlayerAction enum
            var mockInputProvider = new Mock<IInputProvider>(MockBehavior.Strict);
            mockInputProvider.Setup(x => x.Read()).Returns("R");

            // Create a MoveProvider, passing in the MockInputProvider
            var moveProvider = new MoveProvider(mockInputProvider.Object);
            moveProvider.GetMove();
            // Call GetMove() and verify that an InvalidInputException is thrown
            // using ExpectedException
        }

    }
}
