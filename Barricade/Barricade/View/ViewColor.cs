using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barricade.View
{
    public class ViewColor
    {
        private Dictionary<Color, ConsoleColor> ConsoleColors;

        public ViewColor()
        {
            ConsoleColors = new Dictionary<Color, ConsoleColor>();

            ConsoleColors.Add(Color.RED, ConsoleColor.Red);
            ConsoleColors.Add(Color.GREEN, ConsoleColor.Green);
            ConsoleColors.Add(Color.YELLOW, ConsoleColor.Yellow);
            ConsoleColors.Add(Color.BLUE, ConsoleColor.Blue);
        }

        public void SetConsoleColor(Color color)
        {
            Console.ForegroundColor = ConsoleColors[color];
        }

        public void ResetConsoleColor()
        {
            Console.ResetColor();
        }
    }
}
