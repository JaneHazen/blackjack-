using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    public class Table : ITable
    {
        /// <summary>
        /// A list (or array (or listarray)) of the players
        /// </summary>
        public IEnumerable<IPlayer> Players { get; set; }

        /// <summary>
        /// The dealer. The one to beat.
        /// </summary>
        public IPlayer Dealer { get; set; }

        public Table(IEnumerable<IPlayer> players, IPlayer dealer)
        {
            Players = players;
            Dealer = dealer;
        }
    }
}
