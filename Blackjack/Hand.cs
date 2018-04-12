using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    public class Hand : IHand
    {
        public List<ICard> Cards { get; private set; }
        public Hand()
        {
            Cards = new List<ICard>();
        }

        public Hand(List<ICard> cards)
        {
            Cards = cards;
        }

        public int GetTotalValue()
        {
            // set the sum to nothing
            int sum = 0;
            // make a list of integers representing the number of aces in the hand
            int Aces = 0;
            foreach(ICard card in Cards)
            {
                // set the sum of the cards without the aces
                if (card.Name != "Ace")
                    sum += card.Value;
                // and remember the number of aces 
                else
                    Aces += 1;
            }
            // set the low ace as one (these are for readabilty)
            int LowAce = 1;
            // set the high ace as 11
            int HighAce = 11;

            // if there aren't any aces, just skip everything and return the sum 
            if(Aces == 0 )
                return sum; 
            //if there's one ace, see if the high or low is better
            if(Aces == 1)
            {
                //if the high ace doesn't exceed 21, that's your winner
                if (sum + HighAce <= 21)
                    return sum + HighAce;
                //otherwise the low ace is the best we've got 
                else
                    return sum + LowAce;
            }
            //if there's more than one ace only one will ever be high (otherwise we exceed 21)
            if (Aces > 1)
            {
                // if there's a high ace the total will be the sum plus 11 plus however many aces you have left:
                int HighAceTotal = sum + HighAce + (Aces - 1);
                // so if that's less than or equal to 21 that's your best option
                if (HighAceTotal <= 21)
                    return HighAceTotal;
                //otherwise, just make them all low 
                //(this should be Aces * LowAces, but since LowAces is one it doesn't matter) 
                else
                    return sum + Aces; 

            }

            throw new ArgumentNullException();
        }
       
        // Add a card to the hand
       public void AddCard(ICard card)
        {
            //just shove it on the list and don't return anything
            Cards.Add(card);
        }
    }
}
