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
        /// Rank of the cars, from ace to king
        /// </summary>
        public CardRank Rank { get; set; }

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
        public Card(CardSuit suit, CardRank rank, int value)
        {
            Suit = suit;
            Rank = rank;
            Value = value;
            IsHidden = true;
        }
        /// <summary>
        /// Just for testing purpose
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var stringCard = new StringBuilder();
            stringCard.Append(this.Suit + "|" + this.Rank + " " + this.Value);
            return stringCard.ToString();
        }


    }
}
