using Blackjack.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{   /// <summary>
    /// This class will manage the game from start to finish
    /// </summary>
    public class GameManager
    {
        /// <summary>
        /// This will hold the list of players
        /// </summary>
        private List<IPlayer> players;

        /// <summary>
        /// This will hold the Dealer instance
        /// </summary>
        private IPlayer dealer;

        /// <summary>
        /// This is the deck the will hold the cards for the game
        /// </summary> 
        private IDeck deck;

        /// <summary>
        /// This hold the list of players and dealer references
        /// </summary>
        private ITable table;

        /// <summary>
        /// Use for rendering the board
        /// </summary>
        private ITableRenderer tableRenderer;

        /// <summary>
        /// Output provider
        /// </summary>
        private IOutputProvider outputProvider;

        /// <summary>
        /// Input provider
        /// </summary>
        private IInputProvider inputProvider;

        /// <summary>
        /// Move provider
        /// </summary>
        private IMove moveProvider;


        /// Console Messages:
        /// 
        /// 1) Enter your name
        private const string ENTER_YOUR_NAME = "Enter Your Name";

        /// <summary>
        /// Defualt constructor
        /// </summary>
        public GameManager() :this(
                                   new BlackJackDeck(), 
                                   new Table(), 
                                   new ConsoleTableRenderer(),
                                   new ConsoleInputProvider(),
                                   new ConsoleOutputProvider(),
                                   new MoveProvider(new ConsoleInputProvider()))
        {

           
        }

        /// <summary>
        /// This is for testing only. The assumption is that players and deelers are created through table object.
        /// </summary>
        /// <param name="deckOfCards"></param>
        /// <param name="table"></param>
        /// <param name="tableRenderer"></param>
        public GameManager(
                            IDeck deckOfCards,
                            ITable table,
                            ITableRenderer tableRenderer,
                            IInputProvider inputProvider,
                            IOutputProvider outputProvider,
                            IMove moveProvider
                           )
        {

            this.table = table;
            this.players = table.Players != null ? table.Players.ToList() : null;
            this.dealer = table.Dealer != null ? table.Dealer : null;
            this.tableRenderer = tableRenderer;
            this.deck = deckOfCards;
            this.inputProvider = inputProvider;
            this.outputProvider = outputProvider;
            this.moveProvider = moveProvider;
          }     
        
        /// <summary>
        /// Create Players from input provider
        /// </summary>
        private void createPlayersForTable()
        {
            outputProvider.Write("How many players: ");
            var numsPlayer = 1;
            int.TryParse(inputProvider.Read(), out numsPlayer);

            if(numsPlayer <= 0)
            {
                numsPlayer = 1;
                outputProvider.WriteLine();
                outputProvider.WriteLine($"Defaulting to {numsPlayer} players");
            }


            this.players = new List<IPlayer>();
            for (int i = 0; i < numsPlayer; i++)
            {
                var name = GetName();
                this.players.Add(new HumanPlayer(name));
            }

            this.table.Players = this.players as IEnumerable<IPlayer>;
        }

        private string GetName()
        {          
            outputProvider.Write($"{ENTER_YOUR_NAME}: ");
            string player = inputProvider.Read();
            return player;

        }

        /// <summary>
        /// Create computer dealer
        /// 
        /// </summary>
        private void createDealerForTable()
        {
            this.dealer = new BlackjackDealer();
            this.table.Dealer =  this.dealer;
        }

        /// <summary>
        /// This funcition will start the game.
        /// </summary>
        public void StartGame()
        {
            outputProvider.WriteLine();
            welcomeMessage();
            outputProvider.WriteLine();

            for (var round = 1; round <= 2; round++)
            {
                deck = new BlackJackDeck();
                deck.Shuffle();

                createDealerForTable();

                createPlayersForTable();

                DealFristTwoCards();

                updatePlayerGameStateForTheFirstTwoCard();

                tableRenderer.Table = table;
                tableRenderer.RenderWholeTable();

                playTurn();

                showDealerHand();
                tableRenderer.RenderWholeTable();

                while (dealer.PlayerHands[0].GetTotalValue() < Constant.DEALERMINHANDVALUE)
                {
                    //TODO may need a delay
                    dealer.Draw(deck, Constant.DRAW_ONE);
                    tableRenderer.RenderWholeTable();
                }
                updatePlayerGameState(dealer);

                if (dealer.PlayerHands[0].GetTotalValue() > Constant.BLACKJACK)
                {
                    updateWinWhenDealerBusted();
                }
                else
                {
                    updateWinDealerAgainstPlayer();
                }

                tableRenderer.RenderWholeTable();

                outputProvider.WriteLine();
                outputProvider.WriteLine("Do you want to play one more round? Y/N");

                var result = inputProvider.Read();

                if(result.Contains("N") || result.Contains("n"))
                {
                    break;
                }
            }

            outputProvider.WriteLine(tableRenderer.Generate('$'));
            outputProvider.WriteLine("Thanks for Playing the Game!");

        }

        private void playTurn()
        {
            foreach (var player in players)
            {
                PlayerAction action = PlayerAction.hit;

                do
                {
                    outputProvider.WriteLine($"{player.Name}  enter one of the following options: ");

                    foreach (var actionType in Enum.GetNames(typeof(PlayerAction)))
                    {
                        outputProvider.Write(actionType);
                        outputProvider.Write(" ");
                    }

                    outputProvider.WriteLine();
                    action = player.GetAction(moveProvider);

                    if (action == PlayerAction.hit)
                    {
                        player.Draw(deck, Constant.DRAW_ONE);
                        updatePlayerGameState(player);
                        tableRenderer.RenderWholeTable();
                    }

                    if (player.gameState == GameState.GameOver)
                        break;

                } while (action == PlayerAction.hit);

                //Check BlackJack win situation
                //Start the game loop here
                //get a player from the list in round robin

                //loop till stand or loss condition state
                // Perform a PerformPlayerAction(IPlayer player) -> return the Action
                //Ask for player action hit, double, split, surrender
                //if hit - draw card from deck
                //CheckPlayerHand()

                //check the hand->split 
                //if need->check adjust for win 
                //if needed->determine loss or ask player to new move 
                //if stand return 
                // go the next player.
            }
        }

        private void showDealerHand()
        {
            foreach (var card in dealer.PlayerHands[0].Cards)
            {
                card.IsHidden = false;
            }
        }

        private void updatePlayerGameStateForTheFirstTwoCard()
        {
            foreach (var player in players)
            {
                
                if (player.PlayerHands[0].GetTotalValue() == Constant.BLACKJACK)
                {
                    player.gameState = GameState.BlackJack;
                }

                if (player.PlayerHands[0].GetTotalValue() > Constant.BLACKJACK)
                {
                    player.gameState = GameState.GameOver;
                }
            }
        }

        private void welcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            outputProvider.WriteLine(tableRenderer.Generate('$'));
            Console.ForegroundColor = ConsoleColor.White;
            outputProvider.WriteLine("Welcome to Black Jack, where you lose all your money");
            Console.ForegroundColor = ConsoleColor.Green;
            outputProvider.WriteLine(tableRenderer.Generate('$'));
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void updatePlayerGameState(IPlayer player)
        {
           
            if (player.PlayerHands[0].GetTotalValue() <= Constant.BLACKJACK)
            {
                player.gameState = GameState.InGame;
            }

            if (player.PlayerHands[0].GetTotalValue() > Constant.BLACKJACK)
            {
                player.gameState = GameState.GameOver;
            }
        }

        /// <summary>
        ///  To compare player against the dealer
        /// </summary>
        /// <param name="dealerHand"></param>
        /// <param name="playerHand"></param>
        private void updateWinDealerAgainstPlayer()
        {
            var dealHandTotal = dealer.PlayerHands[0].GetTotalValue();
            foreach(var player in players)
            {
                if (player.gameState != GameState.GameOver)
                {
                    var playerHandTotal = player.PlayerHands[0].GetTotalValue();

                    player.gameState = GameState.GameOver;

                    if (playerHandTotal > dealHandTotal)
                    {
                        player.gameState = GameState.Winner;
                    }

                    if (playerHandTotal == dealHandTotal)
                    {
                        player.gameState = GameState.Push;
                    }
                   
                }
            }
        }
        /// <summary>
        /// check if the player won the game when the dealer is out
        /// </summary>
        /// <param name="playerHand"></param>
        private void updateWinWhenDealerBusted()
        {
            foreach (var player in players)
            {
                if (player.gameState != GameState.GameOver)
                {
                    var playerHandTotal = player.PlayerHands[0].GetTotalValue();

                    if (playerHandTotal <= Constant.BLACKJACK)
                    {
                        player.gameState = GameState.Winner;
                    }                    
                    else
                    {
                        player.gameState = GameState.GameOver;
                    }
                }
            }
        }
        /// <summary>
        /// This function deals out the first two card playes and dealer
        /// </summary>
        private void DealFristTwoCards()
        {
            foreach (var player in players)
            {
                player.Draw(deck, 2);
            }
            dealer.Draw(deck, 2);
            //dealer.PlayerHands[0].Cards[1].IsHidden = true;
        }
    }
}

