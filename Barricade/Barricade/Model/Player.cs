using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barricade
{
    public class Player
    {
        public Color Color { get; }
        public List<Pawn> Pawns { get; }

        public Player(Color color) {
            Color = color;

            //pieces maken
            Pawns = new List<Pawn>();
        }

    }
}