using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barricade.View
{
    class PlayerView : ViewColor
    {
        public string ChosePosibleMove(int numberOfTries)
        {
            if (numberOfTries > 0)
            {
                SetConsoleColor(Color.RED);
                Console.WriteLine("Is it realy that hard?....");
                ResetConsoleColor();
            }
            Console.WriteLine("Inset a number of the field you would like to move the Barricade to:");
            return Console.ReadLine();
        }
    }
}
