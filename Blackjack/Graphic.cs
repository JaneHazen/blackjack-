using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    public class Graphic : IGraphic
    {
        /// <summary>
        /// A 'map' of the colors and/or characters in the image
        /// Limited to 10 distinct values
        /// In practice, will use Color enum
        /// 
        /// Example 1:
        /// 
        /// 000000
        /// 011110
        /// 011110
        /// 011110
        /// 011110
        /// 000000
        /// 
        /// A white 6x6 square with a black border
        /// 
        /// Example 2:
        /// 
        /// 0909090909
        /// 8080808080
        /// 0707070707
        /// 6060606060
        /// 0505050505
        /// 4040404040
        /// 3030303030
        /// 0202020202
        /// 1010101010
        /// 
        /// A 10 x 10 square with a rainbow checkerboard
        /// From top to bottom: red(9), orange(8), yellow(7), green(6), 
        /// cyan/turquoise(5), blue(4), red(3), white(2), gray(1)
        /// </summary>
        public int[,] Bitmap { get; }

        public Graphic(int[,] array)
        {
            Bitmap = array;
        }
    }
}
