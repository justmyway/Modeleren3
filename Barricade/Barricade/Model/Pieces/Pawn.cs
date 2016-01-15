using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Barricade.Model.Pieces;

namespace Barricade
{
    public class Pawn : Piece
    {
        public Pawn(Color color)
        {
            Color = color;
        }
    }
}