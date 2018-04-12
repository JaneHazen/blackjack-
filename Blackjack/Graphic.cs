using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    /// <summary>
    /// A representation of an image
    /// </summary>
    public class Graphic : IGraphic
    {
        /// <summary>
        /// A 'map' of the colors and/or characters in the image.
        /// Limited to 10 distinct values.
        /// Can use the Color enum if you cast the Color to an int (see Example 3).
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
        /// A 10 x 10 square with a rainbow and black checkerboard.
        /// The 0's are black spots.
        /// From top to bottom: transparent(9), gray(8), red(7), orange(6), 
        /// yellow(5), green(4), blue(3), purple(2), white(1).
        /// 
        /// Example 3:
        /// 
        /// { (int)Color.Red, (int)Color.Green, (int)Color.Blue }
        /// 
        /// An array containing Color enums, each of which is cast to an int.
        /// Because enums have a number value, after the cast, the array contains
        /// the ints 7, 4, 3...which represent the colors red, green, and blue.
        /// </summary>
        public int[][] Bitmap { get; }

        /// <summary>
        /// Go through the graphic's bitmap and convert everything to colors
        /// </summary>
        /// <returns>An array of arrays containing colors</returns>
        public Color[][] ColorMap
        {
            get
            {
                var map = this.Bitmap;
                var coloredMap = new Color[map.Length][];

                for (int index = 0; index < map.Length; index++)
                {
                    var array = map[index];
                    var coloredLine = array.Select(colorValue => (Color)colorValue);

                    coloredMap[index] = coloredLine.ToArray();
                }

                return coloredMap;
            }
        }

        /// <summary>
        /// Speeds up generating cards a little by providing a template of the proper size
        /// </summary>
        public static int[][] CardTemplate = new int[10][];

        public Graphic(int[][] bitmap)
        {
            Bitmap = bitmap;
        }
    }
}
