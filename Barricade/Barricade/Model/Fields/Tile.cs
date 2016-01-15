using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Barricade.Model.Pieces;

namespace Barricade.Model.Fields
{
    public class Tile : Field
    {
        protected Piece piece;

        public override void Enter(Piece piece)
        {
            throw new NotImplementedException();
        }

        public override bool MayEnter(Piece visiting_piece)
        {
            return visiting_piece.Color != piece.Color;
        }
    }
}