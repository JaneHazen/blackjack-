﻿using System;
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
        List<ICard> Cards { get; }
        // loops through the hand to return all cards in the hand
        int GetTotalValue();
        // adds a card to the hand
        void AddCard(ICard card);

        int GetTotalHiddenValue();

    }
}
