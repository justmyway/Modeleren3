using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barricade.Model
{
    public class GameModel
    {
        public List<Player> Players { get; }
        public Player CurrentPlayer { get; set; }
        public int Dice { get; set; }
        public List<Field> PosibleMoves { get; set; }

        public GameModel(List<Player> gamePlayers)
        {
            Players = gamePlayers;
        }
    }
}
