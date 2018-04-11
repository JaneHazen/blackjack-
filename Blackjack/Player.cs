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
    public class Player : IPlayer
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
        //public IHand Cards()
        //{
        //    return this.hand.Cards();
        //}
      

        public void Draw()
        {

        }

        public Player()
        {
            
        }


    }
}
