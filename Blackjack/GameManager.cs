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
        /// This will hold the list of players including dealer as player
        /// </summary>
        private List<IPlayer> player;

        /// <summary>
        /// This is the deck the will hold the cards for the game
        /// </summary>
        private IDeck deck;


        /// <summary>
        /// Defualt constructor
        /// </summary>
        public GameManager()
        {
            
        }

        /// <summary>
        /// This funcition will start the game.
        /// </summary>
        public void StartGame()
        {
            throw new NotImplementedException();
        }
    }
}
