using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barricade
{
    public class RestTile : Tile
    {
        public override bool MayEnter(Piece visiting_piece) {
            if (base.MayEnter(visiting_piece) && piece == null)
                return true;

            return false;
        }

        public void Enter(Piece piece) {
            this.piece = piece; 
        }
    }
}