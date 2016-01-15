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

        public override bool MayEnter(Piece piece)
        {
            throw new NotImplementedException();
        }

        public override bool MayHist(Piece piece)
        {
            throw new NotImplementedException();
        }
    }
}