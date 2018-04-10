using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    class ConsoleOutputProvider : IOutputProvider
    {
        /// <summary>
        /// Clear the console of text
        /// </summary>
        public void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// Print a string
        /// </summary>
        /// <param name="text"></param>
        public void Write(string text)
        {
            Console.Write(text);
        }

        /// <summary>
        /// Print a string and then go to the next line
        /// </summary>
        /// <param name="text"></param>
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// 'Print' a blank line
        /// </summary>
        public void WriteLine()
        {
            Console.WriteLine();
        }
    }
}
