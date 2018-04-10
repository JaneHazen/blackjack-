using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    public interface IOutputProvider
    {
        /// <summary>
        /// Writes the given string, without a new line
        /// </summary>
        /// <param name="text"></param>
        void Write(String text);

        /// <summary>
        /// Write the output with a new line
        /// </summary>
        /// <param name="output"></param>
        void WriteLine(String text);

        /// <summary>
        /// Write an empty new line
        /// </summary>
        void WriteLine();

        /// <summary>
        /// Clear the output
        /// </summary>
        void Clear();
    }
}
