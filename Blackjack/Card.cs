using Blackjack.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Card: ICard
    {
        /// <summary>
        /// Suit of the card
        /// </summary>
        public CardSuit Suit { get; set; }
        /// <summary>
        /// Name of the Card e: King
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// VAlue of the Card
        /// </summary>
        public int Value { get; protected set; }

        /// <summary>
        /// Reveals if the card is face Up or Down
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// Card Cosntructor sets suit, name, value and isHidden
        /// </summary>
        /// <param name="suit"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public Card(CardSuit suit, string name, int value)
        {
            Suit = suit;
            Name = name;
            Value = value;
            IsHidden = true;
        }

    }
}
