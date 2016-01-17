using Barricade.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barricade.Model
{
    public class GameModel
    {
        public List<PlayerController> Players { get; }
        public PlayerController CurrentPlayer { get; set; }
        public int Dice { get; set; }
        public List<PossibleMove> PossibleMoves { get; set; }

        public GameModel(List<PlayerController> gamePlayers)
        {
            Players = new List<PlayerController>();
            Players = gamePlayers;
            PossibleMoves = new List<PossibleMove>();
        }
    }
}
