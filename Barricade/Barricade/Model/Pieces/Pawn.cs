using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barricade
{
    public class Pawn : Piece
    {
        public Pawn(Color color)
        {
            Color = color;
        }

        public Color Color
        {
            get;
            set;
        }
    }
}