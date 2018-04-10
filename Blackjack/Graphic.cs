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
        /// </summary>
        public int[,] Bitmap { get; }

        public Graphic(int[,] array)
        {
            Bitmap = array;
        }
    }
}
