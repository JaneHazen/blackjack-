﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    public class ConsoleInputProvider : IInputProvider
    {

        public String Read()
        {
            var input = Console.ReadLine();

            return input;
        }
    }
}
