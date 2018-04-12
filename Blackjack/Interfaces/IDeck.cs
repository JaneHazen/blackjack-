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
    public interface IDeck
    {
       /// <summary>
       ///  All the cards in the deck
       /// </summary>
       List<ICard> Cards { get; }
       

        /// <summary>
       ///  Deal out the cards
       /// </summary>
       ICard Deal();

       /// <summary>
       ///  Check if card deck has cards
       /// </summary>
       bool isEmpty();

        /// <summary>
        /// Method to empty deck of cards 
        /// </summary>
        void Empty(); 
    
        /// <summary>
       /// Shuffle the deck
       /// </summary>
       void Shuffle();

       /// <summary>
       ///  Add a card to the deck
       /// </summary>
       void Add(ICard card);
    }
}
