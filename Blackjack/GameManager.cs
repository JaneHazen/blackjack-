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
        /// This will hold the list of player
        /// </summary>
        private List<IPlayer> players;

        /// <summary>
        /// 
        /// </summary>
        private IPlayer dealer;

        /// <summary>
        /// This is the deck the will hold the cards for the game
        /// </summary> 
        private IDeck deck;

        /// <summary>
        ///
        /// </summary>
        private ITable table;

        /// <summary>
        /// 
        /// </summary>
        private ITableRenderer tableRenderer;

        /// <summary>
        /// Defualt constructor
        /// </summary>
        public GameManager()
        {
          

        }

        public GameManager(
                            IDeck deckOfCards,
                            ITable table,
                            ITableRenderer tableRenderer,
                            IPlayer Dealer = null,
                            List<IPlayer> players = null)
        {
            //Create Dealer if not supplied
            //Create Player if not supplied 
        }

        /// <summary>
        /// This funcition will start the game.
        /// </summary>
        public void StartGame()
        {
            //
            throw new NotImplementedException();
        }

        public void CheckIfWin(IHand dealerHand, IHand playerHand )
        {
            
        }
    }
}
