using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    interface ITable
    {
        /// <summary>
        /// The human or AI players in the current round 
        /// For MVP, there is only one player in this list.
        /// We get the hands to display from Players.
        /// </summary>
        IEnumerable<IPlayer> Players { get; } 

        /// <summary>
        /// The dealer in the current round to be rendered.
        /// We get the dealer's hand to display from Dealer 
        /// </summary>
        IPlayer Dealer { get; } 
    }
}
