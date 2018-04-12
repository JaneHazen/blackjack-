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
        /// The player's current set of cards
        /// </summary>
        public List<IHand> Cards { get; set; }

      
        /// <summary>
        /// Draw from the deck with specified amount 
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="amt"></param>
        public void Draw(IDeck deck, int amt)
        {
            var drawnCard = deck.Deal();
           // Cards[amt].Add(drawnCard);
        }

        /// <summary>
        /// The human player's action
        /// </summary>
        public void GetAction()
        {

        }

        /// <summary>
        /// Constructor for human player
        /// </summary>
        /// <param name="name"></param>
        /// <param name="hand"></param>
        public HumanPlayer(string name)
        {
            if (name == null || name == "")
            {
                throw new ArgumentNullException("player name");
            }
            this.Name = name;
            this.Cards = new List<IHand>();
            //Cards.Add(new Hand());
            //will need to add cards from new instance of hand concrete class
        }


    }
}
