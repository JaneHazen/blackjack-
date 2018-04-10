using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    //contains the player(or dealer)s' cards
    public interface IHand
    {
        // initiates a list of cards (preferably two?) that will compromise the player's hand
        List<ICard> Hand { get; }
        // loops through the hand to return all cards in the hand
        List<ICard> GetFullHand();
        // adds a card to the hand
        void AddCard(ICard card);

    }
}
