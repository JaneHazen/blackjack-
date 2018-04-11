using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    /// <summary>
    ///  The human player
    /// </summary>
    public class HumanPlayer : IPlayer
    {
        /// <summary>
        /// The player's name 
        /// </summary>
        public string Name { get; set; }
      

        /// <summary>
        /// the hand interface, used to get the player's hand
        /// </summary>
        private IHand hand;

        /// <summary>
        /// The player's hand
        /// </summary>
        public IHand Cards()
        {
            return this.hand;
        }

        /// <summary>
        /// Draw from the deck
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="amt"></param>
        public void Draw(IDeck deck, int amt)
        {

        }

        /// <summary>
        /// The human player's action
        /// </summary>
        public void GetAction()
        {

        }

        public HumanPlayer(string name, IHand hand)
        {
            this.Name = name;
            this.hand = hand;
        }


    }
}
