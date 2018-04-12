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
        /// <summary>
        /// A bag containing a collection of players and a dealer.
        /// That's all it does.
        /// No game functionality in there.
        /// </summary>
        public ITable Table { get; }

        /// <summary>
        /// A method for generating graphic objects from cards.
        /// A graphic is, basically, a jagged int array (the property Bitmap
        /// on it is the actual jagged array int[][]).
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public Graphic Generate(ICard card)
        {
            // we're making an empty graphic just to shut up the compiler. 
            // please remove 
            Graphic cardGraphic = new Graphic(new int[0][]);

            if (card.IsHidden)
            {
                //  cardGraphic = new Graphic();
            }

            int number;

            var results = int.TryParse(card.Name, out number);

            if (results)
            {
                //  cardGraphic = new Graphic();
            }
            else
            {
                //  cardGraphic = new Graphic();
            }

            return cardGraphic;
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

        /// <summary>
        /// A method for rendering each hand and the points on it
        /// </summary>
        /// <param name="player">The player of the hand being rendered</param>
        /// <param name="points">The points on the hand
        /// ***! ----->>> Once we have the full code
        /// for IHand, we won't need this argument bc hands will have 
        /// points associated with them!</param>
        public void RenderHandAndPoints(IPlayer player, int points)
        {
            var hand = player.Cards;
            var name = player.Name.ToUpper();

            IOutputProvider outputProvider = new ConsoleOutputProvider();

            var border = Generate('*');

            outputProvider.WriteLine(border);
            outputProvider.WriteLine();
            outputProvider.WriteLine($"{name}'s Hand");

            foreach (ICard card in hand)
            {
                var cardGraphic = Generate(card);
                Render(cardGraphic);
                outputProvider.Write("  ");
            }

            outputProvider.WriteLine();
            outputProvider.Write($"{name}'s Points: {points}");
            outputProvider.WriteLine();
            outputProvider.WriteLine(border);
        }

        /// <summary>
        /// A method for rendering the whole table, with all players and the dealer
        /// </summary>
        /// <param name="players">A collection of *active* players to render</param>
        /// <param name="playerPoints">A collection listing all the player's points.
        /// *** --->>> Once hands have a points member REMOVE</param>
        /// <param name="dealer">The dealer</param>
        /// <param name="dealerPoints"> The dealer's points       
        /// *** --->>> Once hands have a points member REMOVE</param>

        public void RenderWholeTable(IEnumerable<IPlayer> players, IEnumerable<int> playerPoints, IPlayer dealer, int dealerPoints)
        {
            List<IPlayer> allTogetherNow = new List<IPlayer>();

            allTogetherNow = players.Select(x => x).ToList();
            allTogetherNow.Add(dealer);

            List<int> allThePoints = new List<int>();

            allThePoints = playerPoints.Select(x => x).ToList();
            allThePoints.Add(dealerPoints);

            for (int i = 0; i < allTogetherNow.Count; i++)
            {
                var player = allTogetherNow[i];
                var points = allThePoints[i];

                RenderHandAndPoints(player, points);
            }
        }
    }
}
