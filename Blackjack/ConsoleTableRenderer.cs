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

            int c = 0; // c is for color

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

            var array0 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            var array1 = new int[] { 1,1,1,1,c,1,1,1,1 };
            var array2 = new int[] { 1,1,c,1,1,1,c,1,1 };
            var array3 = new int[] { 1,1,1,c,1,c,1,1,1 };
            var array4 = new int[] { 1,1,c,1,c,1,c,1,1 };

            switch (card.Rank)
            {
                case CardRank.Ace:
                    bitmap[2] = array0;
                    bitmap[4] = array1;
                    bitmap[5] = array0;
                    bitmap[6] = array0;
                    break;
                case CardRank.Jack:
                    bitmap[3] = array0;
                    bitmap[4] = array1;
                    bitmap[5] = array0;
                    bitmap[6] = array0;
                    break;
                case CardRank.Queen:
                    bitmap[3] = array0;
                    bitmap[4] = array1;
                    bitmap[5] = array0;
                    bitmap[6] = array0;
                    break;
                case CardRank.King:
                    bitmap[3] = array0;
                    bitmap[4] = array1;
                    bitmap[5] = array0;
                    bitmap[6] = array0;
                    break;
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
                    bitmap[6] = array0;
                    break;
                case CardRank.Eight:
                    bitmap[3] = array4;
                    bitmap[4] = array2;
                    bitmap[5] = array4;
                    bitmap[6] = array0;
                    break;
                case CardRank.Seven:
                    bitmap[3] = array2;
                    bitmap[4] = array4;
                    bitmap[5] = array2;
                    bitmap[6] = array0;
                    break;
                case CardRank.Six:
                    bitmap[3] = array2;
                    bitmap[4] = array3;
                    bitmap[5] = array2;
                    bitmap[6] = array0;
                    break;
                case CardRank.Five:
                    bitmap[3] = array2;
                    bitmap[4] = array1;
                    bitmap[5] = array2;
                    bitmap[6] = array0;
                    break;
                case CardRank.Four:
                    bitmap[3] = array2;
                    bitmap[4] = array0;
                    bitmap[5] = array2;
                    bitmap[6] = array0;
                    break;
                case CardRank.Three:
                    bitmap[3] = array1;
                    bitmap[4] = array1;
                    bitmap[5] = array1;
                    bitmap[6] = array0;
                    break;
                case CardRank.Two:
                    bitmap[3] = array1;
                    bitmap[4] = array0;
                    bitmap[5] = array1;
                    bitmap[6] = array0;
                    break;
                default:
                    bitmap[4] = array1;
                    break;
            }

            // Now we fill out the white rows on the card

            for (int i = 0; i < bitmap.Length; i++)
            {
                if (bitmap[i] == null || bitmap[i].Length == 0) {
                    bitmap[i] = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
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

        public void Render(ICard card)
        {
            // we are going to be hacky to get this done on time
            // many sins will be committed
            // please don't smite me bill

            var graphic = Generate(card);

            Console.BackgroundColor = ConsoleColor.White;

            var pic = graphic.Bitmap;

            for (int i = 0; i < pic.Length; i++)
            {
                var row = pic[i];

                if (card.Suit == CardSuit.Heart || card.Suit == CardSuit.Diamond)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                char suitSymbol;

                switch (card.Suit)
                {
                    case CardSuit.Spade:
                        suitSymbol = '\u2660';
                        break;
                    case CardSuit.Club:
                        suitSymbol = '\u2663';
                        break;
                    case CardSuit.Heart:
                        suitSymbol = '\u2665';
                        break;
                    case CardSuit.Diamond:
                        suitSymbol = '\u2666';
                        break;
                    default:
                        suitSymbol = ' ';
                        break;
                }

                if (i == 0)
                {
                    var digit = card.Rank;

                    if ((int)digit == 1)
                    {
                        Console.Write("A");
                    }
                    else if ((int)digit <= 9)
                    {
                        Console.Write((int)digit);
                    }
                    else
                    {
                       if (digit == CardRank.Ten)
                        {
                            Console.Write(10);
                        }
                       else
                        {
                            Console.Write(digit.ToString().Substring(0, 1).ToUpper());
                        }
                    }

                    if (digit != CardRank.Ten)
                    {
                        Console.Write(suitSymbol);
                    }

                    Console.WriteLine("       ");
                } 
                else if (i == 9)
                {
                    Console.Write("       ");

                    var digit = card.Rank;

                    if ((int)digit == 1)
                    {
                        Console.Write("A");
                    }
                    else if ((int)digit <= 9)
                    {
                        Console.Write((int)digit);
                    }

                    else
                    {
                        if (digit == CardRank.Ten)
                        {
                            Console.WriteLine(10);
                        }
                        else
                        {
                            Console.Write(digit.ToString().Substring(0, 1).ToUpper());
                        }
                    }

                    if (digit != CardRank.Ten)
                    {
                        Console.WriteLine(suitSymbol);
                    }
                }
                else
                {
                    foreach (int element in row)
                    {
                       if (element == 0 || element == 7)
                        {
                            Console.Write(suitSymbol);
                        }
                       else
                        {
                            Console.Write(" ");
                        }
                    }

                    Console.WriteLine();
                }
            }
        }

        public void Render()
        {

            TempRenderDealerTable();
            TimeDelay();



            //TODO replace later with graphic version

            //RenderHandAndPoints(this.Table.Dealer, dealerPoint);
        }

        /// <summary>
        /// A method for rendering each hand and the points on it
        /// </summary>
        /// <param name="player">The player of the hand being rendered</param>
        /// <param name="points">The points on the hand
        /// ***! ----->>> Once we have the full code
        /// for IHand, we won't need this argument bc hands will have 
        /// points associated with them!</param>
        /// 

        public void TimeDelay()
        {
            var t = Task.Run(async delegate
            {
                await Task.Delay(TimeSpan.FromSeconds(3));
            });
            t.Wait();
        }

        public void TempRenderPlayerHands()
        {

            Console.WriteLine("--------------------------------Player Details-------------------------------------------");
          
            Console.WriteLine();
            var players = this.Table.Players;

            foreach (var player in players)
            {
                var playerPoint = player.PlayerHands[0].GetTotalValue();
                var playerCards = player.PlayerHands[0].Cards;

                Console.WriteLine("----- Player Hand -------");
                Console.WriteLine($"Player: {player}");
                Console.WriteLine($"Player Points: {playerPoint}");
               
                foreach (ICard card in playerCards)
                {
                    Console.WriteLine(card);
                }
              
                Console.WriteLine();
                
            }
        }
        public void TempRenderDealerTable()
        {
            var t = Task.Run(async delegate
            {
                var dealer = this.Table.Dealer;
                //Dealer points only show the value of one
                //var dealerPoint = dealer.PlayerHands[0].GetTotalValue();
                

                bool showOneCard = true;                
                foreach (var card in dealer.PlayerHands[0].Cards)
                {
                    if (!card.IsHidden)
                    {
                        showOneCard = false;
                        break;

                    }
                    
                }

                int dealerPoint = dealer.PlayerHands[0].Cards[0].Value;
                var dealerCards = dealer.PlayerHands[0].Cards;

                await Task.Delay(TimeSpan.FromSeconds(1));
                Console.WriteLine();
                Console.WriteLine("----- Dealer Hand -------");
                Console.WriteLine($"Dealer Name: {dealer.Name}");
                if (showOneCard)
                {
                    Console.WriteLine($"Dealer Points: {dealerPoint}");
                    Console.WriteLine(dealerCards[0]);
                }
                else
                {
                    dealerPoint = dealer.PlayerHands[0].GetTotalValue();
                    Console.WriteLine($"Dealer Points: {dealerPoint}");
                    foreach (ICard card in dealerCards)
                    {
                        Console.WriteLine(card);
                    }
                }


                Console.WriteLine();


                //Rendering dealer card

                return; 
            });
            t.Wait();
        }

        public void RenderHandAndPoints(IPlayer player)
        {
            var hand = player.PlayerHands[0];
            // This complicated bullshit is just capitalizing the first letter of the player's name

            var name = $"{player.Name.Substring(0, 1).ToUpper()}{player.Name.Substring(1, player.Name.Length - 1).ToLower()}";

            IOutputProvider outputProvider = new ConsoleOutputProvider();

            outputProvider.WriteLine();

            var border = Generate('*');

            outputProvider.WriteLine(border);
            outputProvider.WriteLine();
            outputProvider.WriteLine($"{name}'s Hand");

            foreach (ICard card in hand.Cards)
            {
                Render(card);
                Console.WriteLine();
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            outputProvider.WriteLine();
            outputProvider.Write($"{name}'s Points: {player.PlayerHands[0].GetTotalValue()}");
            outputProvider.WriteLine();
            outputProvider.WriteLine(border);
        }

        /// <summary>
        /// A method for rendering the whole table, with all players and the dealer
        /// </summary>
        /// <param name="players">A collection of *active* players to render</param>
        /// <param name="dealer">The dealer</param>
        public void RenderWholeTable()
        {
            if (Console.OutputEncoding != Encoding.Unicode)
            {
                Console.OutputEncoding = Encoding.Unicode;
            }

            // This holds all the players, including the dealer, for the caller's
            // convenience
            List<IPlayer> allTogetherNow = new List<IPlayer>();

            allTogetherNow = Table.Players.Select(x => x).ToList();
            allTogetherNow.Add(Table.Dealer);

            for (int i = 0; i < allTogetherNow.Count; i++)
            {
                var player = allTogetherNow[i];

                RenderHandAndPoints(player);
                TimeDelay();
            }
        }
    }
}
