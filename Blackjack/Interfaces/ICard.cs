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

    public enum CardRank
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public interface ICard

    {
       /// <summary>
       /// The suit of the card
       /// </summary>
       CardSuit Suit { get; set; }

       /// <summary>
       /// The rank of the cards, from ace to king
       /// </summary>
       CardRank Rank { get; set; }
      
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


