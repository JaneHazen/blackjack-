﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    interface IInputProvider
    {
        /// <summary>
        /// Reads string input from the user
        /// </summary>
        /// <param name="text">The </param>
        void Read(String text);
    }
}
