using Blackjack.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    /// <summary>
    /// The deck of cards
    /// </summary>
    public class BlackjackDeck : IDeck
    {
        /// <summary>
        /// The available cards 
        /// </summary>
        public List<ICard> Cards { get; private set; }

        /// <summary>
        /// Constructor which adds cards to deck
        /// </summary>
        /// <param name="cards"></param>
        public BlackjackDeck(List<ICard> cards)
        {
            this.Cards = cards;
        }

        /// <summary>
        /// Adding cards to the deck
        /// </summary>
        /// <param name="card"></param>
        public void Add( ICard card )
        {
            Cards.Add(card);
        }

        /// <summary>
        /// Action to get the last card from the deck
        /// </summary>
        /// <returns></returns>
        public ICard Deal()
        {
            ICard dealtCard = Cards.Last();
            Cards.Remove(dealtCard);
            return dealtCard;
        }

        /// <summary>
        /// Check that deck is empty of cards 
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            return Cards.Count == 0;
        }

        private void AddAllCardsToDeck()
        {
            foreach(CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                //foreach()
            
            }
        }
            

        /// <summary>
        /// 
        /// </summary>
        public void Shuffle() => throw new NotImplementedException();
    }
}
