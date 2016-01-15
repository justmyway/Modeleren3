using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barricade
{
    public class Forest : BigTile
    {
        public Forest()
        {
            pieces = new List<Piece>();
        }

        public void Enter(Piece piece)
        {
            pieces.Add(piece);
        }


    }
}