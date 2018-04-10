using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    public interface IGraphic
    {
        /// <summary>
        /// A 2-D array showing which colors/chars go where
        /// Limited to 10 distinct values
        /// In practice, will use Color enum
        /// 
        /// Example:
        /// 
        /// 000000
        /// 011110
        /// 011110
        /// 011110
        /// 011110
        /// 000000
        /// 
        /// A white 6x6 square with a black border
        /// </summary>
        int[][] Bitmap { get; }
    }
}
