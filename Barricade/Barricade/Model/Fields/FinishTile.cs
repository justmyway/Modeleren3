using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Barricade.Model.Pieces;

namespace Barricade.Model.Fields
{
    public class FinishTile : Tile
    {
        public FinishTile() :base(false)
        {

        }
        public override void Enter(Piece entering_piece)
        {
            Pawn pawn = (Pawn)entering_piece;
            pawn.Owner.FinishPawn(pawn);
        }

        public override bool MayEnter(Piece piece)
        {
            return (piece.Color != Color.WHITE);
        }
    }
}