using Blackjack.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Dealer : IPlayer
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IHand> Cards { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Draw( IDeck deck , int amt ) => throw new NotImplementedException();
        public void GetAction() => throw new NotImplementedException();
    }
}
