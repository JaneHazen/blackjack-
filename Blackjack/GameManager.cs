using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{    /// <summary>
    /// 
    /// </summary>
    class GameManager
    {
        /// <summary>
        /// 
        /// </summary>
        private List<IPlayer> player;

        /// <summary>
        /// 
        /// </summary>
        private IDeck deck;


        /// <summary>
        /// 
        /// </summary>
        public GameManager()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartGame()
        {
            throw new NotImplementedException();
        }
    }
}
