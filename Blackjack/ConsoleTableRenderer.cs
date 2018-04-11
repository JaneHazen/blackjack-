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

        public Graphic Generate(ICard card)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generated ASCII border of 80 characters when given a char input 
        /// </summary>
        /// <param name="border"> The character to make the border</param>
        /// <returns>The 80 character string</returns>
        public string Generate(char border)
        {
            var length = Console.WindowWidth;
            var horizontalRule = String.Concat(Enumerable.Repeat(border, length));

            return horizontalRule;
        }

        public Graphic Generate(int[][] graphic)
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

        public void Render(Graphic graphic)
        {
            throw new NotImplementedException();
        }

        public void RenderHandAndPoints(IPlayer player)
        {
            throw new NotImplementedException();
        }
    }
}
