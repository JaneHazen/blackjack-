using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{

    public enum CardSuit
    {
        Heart,
        Diamond,
        Club, 
        Spade
    }

    public enum CardRank
    {
        AceLow = 1,
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
        King,
        AceHigh
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
        int Value { get; set; }

        /// <summary>
        /// Reveals if the card is face Up or Down
        /// </summary>
        bool IsHidden { get; set; }

        /// <summary>
        /// It Override the ToSting() and returns the value and suit of each card
        /// </summary>
        /// <returns></returns>
        string ToString();


    }
   

}


