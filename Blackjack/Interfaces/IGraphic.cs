using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    interface IGraphic
    {
        /// <summary>
        /// A 2-D array showing which colors/chars go where
        /// Limited to 10 distinct values
        /// </summary>
        int[,] Bitmap { get; }
    }
}
