using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barricade
{
    public class Tile : Field
    {
        protected Piece piece;

        public override bool MayEnter(Piece visiting_piece)
        {
            return visiting_piece.Color != piece.Color;
        }

        public override bool MayHist(Piece visiting_piece)
        {
            return visiting_piece.Color != piece.Color;
        }
    }
}