using Blackjack.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class BlackjackDealer : HumanPlayer, IPlayer
    {
        
        public BlackjackDealer(): base("Adam The Dealer")
        {             
            
        }

    }
}
