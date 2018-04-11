using Blackjack.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class BlackJackDeck : IDeck
    {
        public List<ICard> Cards => throw new NotImplementedException();

        public void Add(ICard card)
        {
            throw new NotImplementedException();
        }

        public ICard Deal()
        {
            throw new NotImplementedException();
        }

        public void Empty()
        {
            throw new NotImplementedException();
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }
    }
}
