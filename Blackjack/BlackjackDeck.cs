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
        /// Adding 52 cards to the deck
        /// </summary>
        public BlackjackDeck()
        {
            Cards = new List<ICard>();
            AddAllCardsToDeck();
        }

        /// <summary>
        /// Constructor which adds specific cards to the deck
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

        /// <summary>
        /// Empty deck of all cards
        /// </summary>
        public void Empty()
        {
            Cards.Clear();
        }

        /// <summary>
        /// Creates 52 cards and add them to the deck
        /// </summary>
        private void AddAllCardsToDeck()
        {
            var dict = new Dictionary<CardRank , int>();
            dict.Add(CardRank.Ace , 11);
            dict.Add(CardRank.Two , 2);
            dict.Add(CardRank.Three , 3);
            dict.Add(CardRank.Four , 4);
            dict.Add(CardRank.Five , 5);
            dict.Add(CardRank.Six , 6);
            dict.Add(CardRank.Seven , 7);
            dict.Add(CardRank.Eight , 8);
            dict.Add(CardRank.Nine , 9);
            dict.Add(CardRank.Ten , 10);
            dict.Add(CardRank.Jack , 10);
            dict.Add(CardRank.Queen , 10);
            dict.Add(CardRank.King , 10);

            foreach(CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach(CardRank rank in Enum.GetValues(typeof(CardRank)))
                {
                    Card card = new Card(suit , rank , dict[rank]);
                    Cards.Add(card);
                }
            
            }   
        }

            

        /// <summary>
        /// 
        /// </summary>
        public void Shuffle() => throw new NotImplementedException();
    }
}
