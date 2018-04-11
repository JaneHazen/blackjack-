using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{   /// <summary>
    /// This class will manage the game from start to finish
    /// </summary>
    class GameManager
    {
        /// <summary>
        /// This will hold the list of players
        /// </summary>
        private IEnumerable<IPlayer> players;

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
        /// Defualt constructor
        /// </summary>
        public GameManager() :this(
                                   new BlackJackDeck(), 
                                   new Table(), 
                                   new ConsoleTableRenderer(),
                                   new ConsoleInputProvider(),
                                   new ConsoleOutputProvider())
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
                            IOutputProvider outputProvider
                           )
        {

            this.table = table;
            this.players = table.Players;
            this.dealer = table.Dealer;
            this.tableRenderer = tableRenderer;
            this.deck = deckOfCards;
            this.inputProvider = inputProvider;
            this.outputProvider = outputProvider;
          }     
        
        /// <summary>
        /// Create Players from input provider
        /// </summary>
        private void createPlayersForTable()
        {
            
        }

        /// <summary>
        /// Create computer dealer
        /// 
        /// </summary>
        private void createDealerForTable()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This funcition will start the game.
        /// </summary>
        public void StartGame()
        {
            welcomeMessage();

            createDealerForTable();

            createPlayersForTable();

            DealFristTwoCards();

            tableRenderer.Table = table;
            tableRenderer.Render();
           
            foreach(var player in players)  
            {
            
              
                outputProvider.WriteLine($"{player.Name}")


                

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

        private void welcomeMessage()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This function deals out the first two card playes and dealer
        /// </summary>
        private void DealFristTwoCards()
        {
            throw new NotImplementedException();
        }
    }
}
