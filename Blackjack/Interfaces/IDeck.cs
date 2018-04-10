using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    /// <summary>
    ///  A 52-card deck
    /// </summary>
    interface IDeck
    {
       /// <summary>
       ///  All the cards in the deck
       /// </summary>
       List<ICard> Cards { get; }
       

        /// <summary>
       ///  Deal out the cards
       /// </summary>
       //ICard Deal();

        /// <summary>
       ///  Check if card deck has cards
       /// </summary>

        /// <summary>
       /// Shuffle the deck
       /// </summary>

        /// <summary>
       ///  Hand 
       /// </summary>
    }
}
