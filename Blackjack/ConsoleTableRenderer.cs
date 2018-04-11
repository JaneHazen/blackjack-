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

        public string ConvertToUnicode(ICard card)
        {
            if (card.IsHidden)
            {
                // This hardcoded value represents a card back: 🂠
                // If the card is not visible, we don't care about the suit or name
                // We just want to render the back of the card
                return "\U0001F0A0"; 
            }

            StringBuilder extendedUnicode = new StringBuilder("0001F0");
            var nameMap = new Dictionary<String, String>();

            nameMap.Add("J", "B");
            nameMap.Add("Q", "D");
            nameMap.Add("K", "E");
            nameMap.Add("A", "1");
            nameMap.Add("10", "A");

            switch (card.Suit)
            {
                case CardSuit.Spade:
                    extendedUnicode.Append("A");
                    break;
                case CardSuit.Heart:
                    extendedUnicode.Append("B");
                    break;
                case CardSuit.Diamond:
                    extendedUnicode.Append("C");
                    break;
                case CardSuit.Club:
                    extendedUnicode.Append("D");
                    break;
                default:
                    break;
            }

            int number;
            bool result = int.TryParse(card.Name, out number);

            if (result && number < 10)
            {
                extendedUnicode.Append(card.Name);
            } else
            {
                extendedUnicode.Append(nameMap[card.Name.ToUpper()]);
            }

            return @"\U" + extendedUnicode.ToString();
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
