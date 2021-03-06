﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Exceptions
{
    /// <summary>
    /// Exception representing an invalid move
    /// </summary>
    public class InvalidMoveException : Exception
    {
        public InvalidMoveException()
        {
        }

        public InvalidMoveException(string message)
        : base(message)
        {
        }

        public InvalidMoveException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
