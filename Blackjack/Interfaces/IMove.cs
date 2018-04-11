using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    public interface IMove
    {
       //player can ask for another card
       void  Hit();
       //player can keep their current cards
       void Stand();
    }
}
