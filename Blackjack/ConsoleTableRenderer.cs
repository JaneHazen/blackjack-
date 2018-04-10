using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    public class ConsoleTableRenderer: ITableRenderer
    {
        public ITable Table { get; }

        public string[,] Generate(ICard card)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts a card to the extended unicode representation of the card,
        /// based on number and suit
        /// </summary>
        /// <param name="card">The card to be printed</param>
        /// <returns>The extended unicode representation of the card</returns>
        //public string ConvertToUnicode(ICard card)
        //{
        //    StringBuilder extendedUnicode = new StringBuilder("0001F0");

        //    return "\U0001F0A0";
        //}

        public string Generate(char border)
        {
            throw new NotImplementedException();
        }

        public string[,] Generate(int[][] graphic)
        {
            throw new NotImplementedException();
        }

        public ConsoleColor Paint(Color color)
        {
            switch (color)
            {
                case Color.Black:
                    return ConsoleColor.Black;
                case Color.White:
                    return ConsoleColor.White;
                case Color.Gray:
                    return ConsoleColor.Gray;
                case Color.Purple:
                    return ConsoleColor.DarkMagenta;
                case Color.Blue:
                    return ConsoleColor.Blue;
                case Color.Green:
                    return ConsoleColor.Green;
                case Color.Yellow:
                    return ConsoleColor.Yellow;
                case Color.Orange:
                    return ConsoleColor.DarkYellow;
                case Color.Red:
                    return ConsoleColor.Red;
                case Color.Transparent:
                    return Console.BackgroundColor;
                default:
                    // will never actually run, but the compiler wants it
                    throw new ArgumentException("unknown color");
            }
        }

        public void Render(string[,] graphic)
        {
            throw new NotImplementedException();
        }

        public void RenderHandAndPoints(IPlayer player)
        {
            throw new NotImplementedException();
        }
    }
}
