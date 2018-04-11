using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    /// <summary>
    /// Suit Enum for card suits 
    /// </summary>
    public enum CardSuit
    {
        Heart,
        Diamond,
        Club, 
        Spade
    }

    /// <summary>
    /// This interface set fields to generate cards
    /// </summary>
    public interface ICard

    {
       /// <summary>
       /// The suit of the card
       /// </summary>
        CardSuit Suit { get; set; }
      
        /// <summary>
        /// The Name of the Class
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// The Value of the card
        /// </summary>
        int Value { get;}

        /// <summary>
        /// Reveals if the card is face Up or Down
        /// </summary>
        bool IsHidden { get; set; }

    }
   

}


