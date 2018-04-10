using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    interface ITableRenderer
    {
        /// Renders the current table in front of the player
        /// 
        /// This includes:
        ///     The cards in the player's hand
        ///     The visible cards in the dealer's hand
        ///     The player's points
        ///     The dealer's points
        ///     
        /// And also any other ASCII art, such as:
        ///     Greeting art
        ///     Win art
        ///     Loss art
        ///     Goodbye art
        ///     Separators between text
        ///     

        void Render(ITable table);
    }
}
