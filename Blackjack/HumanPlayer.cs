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
        public List<IHand> PlayerHands { get;}
        public GameState gameState { get; set; }
    


        public HumanPlayer()
        {
            PlayerHands = new List<IHand>();
        }

        /// <summary>
        /// Draw from the deck with specified amount . Added only to the first hand
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="amt"></param>
        public void Draw(IDeck deck, int amt)
        {
         
            for(var i = 0; i < amt; i++)
            {
                var drawnCard = deck.Deal();
                
                if(PlayerHands.Count == 0)
                {
                   
                    var hand = new Hand();
                    PlayerHands.Add(hand);
                }

                PlayerHands[0].AddCard(deck.Deal());
            }
         
        }

        /// <summary>
        /// The human player's action
        /// </summary>
        public PlayerAction GetAction(IMove moveProvider)
        {
            return moveProvider.GetMove();
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
            this.PlayerHands = new List<IHand>();
            //will need to add cards from new instance of hand concrete class
        }


    }
}
