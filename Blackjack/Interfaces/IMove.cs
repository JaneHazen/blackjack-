﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    public interface IMove
    {
      //will return player's move
      PlayerAction  GetMove();
    }
}
