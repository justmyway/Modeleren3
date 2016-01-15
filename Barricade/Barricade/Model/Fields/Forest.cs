using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barricade
{
    public class Forest : Field
    {
        private List<Piece> pieces;

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