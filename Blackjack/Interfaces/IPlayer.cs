using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
      /// <summary>
      ///  Represents a player or other participant
      /// </summary>
    public interface IPlayer
    {   
        /// <summary>
        ///  The player's name
        /// </summary>
        string Name { get; set; }

       /// <summary>
       ///  The player's hand
       /// </summary>
        List<IHand> Cards { get; set; }

        /// <summary>
        ///  The player's draw method to take cards from deck
        /// </summary>
        void Draw(IDeck deck, int amt);//draw from Ideck)

        /// <summary>
        /// Defines the actions(hit, stand) taken on by the player 
        /// </summary>
        void GetAction(); 

    }
}
