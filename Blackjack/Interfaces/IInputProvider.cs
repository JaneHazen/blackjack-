using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    public interface IInputProvider
    {
        /// <summary>
        /// Reads string input from the user
        /// </summary>
        /// <returns>Returns the input</returns>
        String Read();
    }
}
