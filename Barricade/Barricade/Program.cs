using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barricade
{
    class Program
    {

        static void Main(string[] args)
        {
            GameController game = new GameController();

            game.Play();

            Console.ReadLine();
        }
    }
}
