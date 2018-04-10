using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
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
    interface ITableRenderer
    {
        /// <summary>
        /// The table to be rendered
        /// </summary>
        ITable Table { get; }

        /// <summary>
        /// A rendering method that takes card data & uses it to generate
        /// a graphical representation of the card
        /// </summary>
        /// <param name="card">The card that will generate a graphical 
        /// representation</param>
        void Render(ICard card);

        /// <summary>
        /// A rendering method that prints a series of chars to fill a single line.
        /// Used to separate art from text in the console
        /// </summary>
        /// <param name="separator"></param>
        void Render(Char border);

        /// <summary>
        /// A method for rendering ASCII
        /// </summary>
        /// <param name="graphic"></param>
        void Render(int[,] graphic);

        /// <summary>
        /// Our main rendering method, for drawing the player's cards and points
        /// </summary>
        /// <param name="player"></param>
        void RenderHandAndPoints(IPlayer player);
    }
}
