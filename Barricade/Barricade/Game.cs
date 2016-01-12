using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barricade
{
    public class Game
    {
        List<Player> players;

        public Game() {
            players = new List<Player>();

            //create Players
            Player player = new Player(Color.RED);
            Console.WriteLine(player.Name());
            Console.Read();
        }
    }
}