using Barricade.Model.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barricade.Model
{
    public class Player
    {
        public Color Color { get; }
        public List<Pawn> Pawns { set; get; }
        public Field Forest { set; get; }
        public List<Field> StartFields { set; get; }

        public Player(Color color) {
            Color = color;
            Pawns = new List<Pawn>();
        }
    }
}
