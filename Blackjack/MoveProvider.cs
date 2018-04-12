using Blackjack.Exceptions;
using Blackjack.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class MoveProvider : IMove
    {
        private IInputProvider consoleInputProvider;
        /// <summary>
        /// Constructor that constructs the move provider
        /// </summary>
        /// <param name="consoleInputProvider"></param>
        public MoveProvider(IInputProvider consoleInputProvider)
        {
            this.consoleInputProvider = consoleInputProvider;
        }

        /// <summary>
        /// Implements the IMove interface, returns the player's action
        /// also throws invalid exception if the move cannot be parsed
        /// </summary>
        /// <returns>player's action - hit or stand</returns>
        public PlayerAction GetMove()
        {
            PlayerAction playerAction;
            var userInput = consoleInputProvider.Read();
            if (Enum.TryParse(userInput, true, out playerAction))
                return playerAction;
            else
                throw new InvalidInputException();
        }
    }
}
