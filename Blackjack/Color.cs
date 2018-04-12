using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    /// <summary>
    /// A way of representing colors in our graphics, using ints 0 to 9.
    /// 
    /// We cannot use ConsoleColor directly, even though it is also an enum,
    /// because some of the console colors we want to use are represented by
    /// multiple digits (ConsoleColor.Yellow = 14), or have names that differ
    /// from common English usage (ConsoleColor.DarkMagenta is purple; 
    /// ConsoleColor.DarkYellow is orange).
    /// </summary>
    public enum Color
    {
        Black = 0,
        White = 1,
        Purple = 2,
        Blue = 3,
        Green = 4,
        Yellow = 5,
        Orange = 6,
        Red = 7,
        Gray = 8,
        Transparent = 9
    }
}
