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
        public ITable Table { get; set; }

        /// <summary>
        /// A method for generating graphic objects from cards.
        /// A graphic is, basically, a jagged int array (the property Bitmap
        /// on it is the actual jagged array int[][]).
        /// </summary>
        /// <param name="card"></param>
        /// <returns>A graphic of the card represented in code</returns>
        public Graphic Generate(ICard card)
        {
            Graphic cardGraphic;

            var bitmap = Graphic.CardTemplate;

            // If the card is hidden/flipped over, just make a big red rectangle
            // and return it immediately

            if (card.IsHidden)
            {
                for (int i = 0; i <= 9; i++)
                {
                    bitmap[i] = new int[] { 7,7,7,7,7,7,7,7,7 };
                }

                cardGraphic = new Graphic(bitmap);

                return cardGraphic;
            }

            // If the card is face up, find out its color...

            int c; // c is for color

            if (card.Suit == CardSuit.Club || card.Suit == CardSuit.Spade)
            {
                c = 0; // 0 is black
            }
            else
            {
                c = 7; // 7 is red
            }

            // ...create the top and bottom row of spots, displaying the suit and number...
            // (1's represent white, c's represent the color -- black or red -- of the
            // card)

            bitmap[0] = new int[] { c,c,1,1,1,1,1,1,1 };
            bitmap[9] = new int[] { 1,1,1,1,1,1,1,c,c };

            // ...and figure out where the rest of the spots go...

            var array1 = new int[] { 1,1,1,1,c,1,1,1,1 };
            var array2 = new int[] { 1,1,c,1,1,1,c,1,1 };
            var array3 = new int[] { 1,1,1,c,1,c,1,1,1 };
            var array4 = new int[] { 1,1,c,1,c,1,c,1,1 };

            switch (card.Rank)
            {
                case CardRank.Ten:
                    bitmap[3] = array4;
                    bitmap[4] = array4;
                    bitmap[5] = array4;
                    bitmap[6] = array1;
                    break;
                case CardRank.Nine:
                    bitmap[3] = array4;
                    bitmap[4] = array4;
                    bitmap[5] = array4;
                    break;
                case CardRank.Eight:
                    bitmap[3] = array4;
                    bitmap[4] = array2;
                    bitmap[5] = array4;
                    break;
                case CardRank.Seven:
                    bitmap[3] = array2;
                    bitmap[4] = array4;
                    bitmap[5] = array2;
                    break;
                case CardRank.Six:
                    bitmap[3] = array2;
                    bitmap[4] = array3;
                    bitmap[5] = array2;
                    break;
                case CardRank.Five:
                    bitmap[3] = array2;
                    bitmap[4] = array1;
                    bitmap[5] = array2;
                    break;
                case CardRank.Four:
                    bitmap[3] = array2;
                    bitmap[5] = array2;
                    break;
                case CardRank.Three:
                    bitmap[3] = array1;
                    bitmap[4] = array1;
                    bitmap[5] = array1;
                    break;
                case CardRank.Two:
                    bitmap[3] = array1;
                    bitmap[5] = array1;
                    break;
                // if we have an ace or a face card, put only one spot in the center
                default:
                    bitmap[4] = array1;
                    break;
            }

            // Now we fill out the white rows on the card

            for (int i = 0; i < bitmap.Length; i++)
            {
                if (bitmap[i].Length == 0) {
                    bitmap[i] = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, };
                }
            }

            cardGraphic = new Graphic(bitmap);

            return cardGraphic;
        }

        /// <summary>
        /// Generates an ASCII border of characters when given a char input 
        /// </summary>
        /// <param name="border"> The character to make the border</param>
        /// <returns>The character string</returns>
        public string Generate(char border)
        {
            var length = Console.WindowWidth;
            var horizontalRule = String.Concat(Enumerable.Repeat(border, length));

            return horizontalRule;
        }

        /// <summary>
        /// Generates a graphic from a 2D array. Really just a wrapper for the
        /// graphic constructer
        /// </summary>
        /// <param name="graphic"></param>
        public Graphic Generate(int[][] graphic)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gives you ConsoleColors based on BlackJack Colors.
        /// We couldn't use ConsoleColors in out graphics directly, because some of
        /// them have confusing names, or raw enum values that contain multiple digits
        /// </summary>
        /// <param name="color">The color to display in console</param>
        /// <returns></returns>
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

        /// <summary>
        /// Renders a graphic.
        /// </summary>
        /// <param name="graphic">An object containing a map of colors</param>
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
            // This complicated bullshit is just capitalizing the first letter of the player's name
            var name = $"{player.Name.Substring(0, 1).ToUpper()}{player.Name.Substring(1, player.Name.Length - 1).ToLower()}";

            IOutputProvider outputProvider = new ConsoleOutputProvider();

            var border = Generate('*');

            outputProvider.WriteLine(border);
            outputProvider.WriteLine();
            outputProvider.WriteLine($"{name}'s Hand");

            foreach (ICard card in hand)
            {
                var cardGraphic = Generate(card);
                Render(cardGraphic);
                // This creates a 2 character-wide space between cards in the hand
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
            // This holds all the players, including the dealer, for the caller's
            // convenience
            List<IPlayer> allTogetherNow = new List<IPlayer>();

            allTogetherNow = players.Select(x => x).ToList();
            allTogetherNow.Add(dealer);

            // This holds all the points. We only only only have it because we're
            // waiting on IHand to have a points member added. Once we get that,
            // we can call the points from the player's hand
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
