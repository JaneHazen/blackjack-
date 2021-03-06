﻿using System;
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
    public interface ITableRenderer
    {
        /// <summary>
        /// The table to be rendered
        /// </summary>
        ITable Table { get; set; }

        /// <summary>
        /// Our main rendering method, for drawing the player's cards and points
        /// </summary>
        /// <param name="player"></param>
        void RenderHandAndPoints(IPlayer player);

        /// <summary>
        /// Renders a 2-D array -- "rendering" strings or 1-D arrays is for
        /// The output provider
        /// </summary>
        /// <param name="graphic"></param>
        void Render(Graphic graphic);

        /// <summary>
        /// Renders the table base on the Table properites
        /// </summary>
        void Render();

        // Renderer helpers -- testable!

        /// <summary>
        /// A method that takes card data & uses it to generate
        /// a graphical representation of the card
        /// </summary>
        /// <param name="card">The card that will generate a graphical 
        /// representation</param>
        /// <returns>A 2-D string array representing the card</returns>
        Graphic Generate(ICard card);

        /// <summary>
        /// A method that generates a series of chars to fill a single line.
        /// Used to separate art from text in the console
        /// </summary>
        /// <param name="border">The char used to fill the line
        /// Example: 
        /// Pass in *
        /// Get out ********************************************************************
        /// </param>
        /// <returns>A string representing the separator</returns>
        String Generate(Char border);

        /// <summary>
        /// A method for rendering the whole table, with all players and the dealer
        /// </summary>
        /// <param name="players">A collection of *active* players to render</param>
        /// <param name="playerPoints">A collection listing all the player's points.
        /// *** --->>> Once hands have a points member REMOVE</param>
        /// <param name="dealer">The dealer</param>
        /// <param name="dealerPoints"> The dealer's points       
        /// *** --->>> Once hands have a points member REMOVE</param>

        void RenderWholeTable();
    }

}
