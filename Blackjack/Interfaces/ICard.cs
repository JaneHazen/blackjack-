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


