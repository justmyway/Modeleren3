using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barricade
{
    public class FinishTile : Tile
    {
        public void Enter(Piece entering_piece)
        {
            piece = entering_piece;
        }
    }
}