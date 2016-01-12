using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barricade
{
    public class BigTile : Field
    {
        protected List<Piece> pieces;

        public override bool MayEnter(Piece piece)
        {
            if (piece.GetType() == typeof(Pawn))
                return true;

            return false;
        }

        public override bool MayHist(Piece piece)
        {
            return false;
        }
    }
}