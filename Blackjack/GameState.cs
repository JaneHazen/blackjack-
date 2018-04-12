using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public enum GameState
    {
        WaitingToStart,
        Started,
        WaitingForUserInput,
        PerformingMove,
        GameOver,
        InGame,
        Push,
        Winner,
        BlackJack
    }
}
