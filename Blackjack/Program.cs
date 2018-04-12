﻿using Blackjack.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            var blackJackGame = new GameManager();
            blackJackGame.StartGame();
            Console.ReadLine();
        }
    }
}
