using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Barricade.Model.Pieces;

namespace Barricade.Model.Fields
{
    public class FinishTile : Tile
    {
        public void Enter(Piece entering_piece)
        {
            piece = entering_piece;
        }
    }
}