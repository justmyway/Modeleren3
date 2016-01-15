using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Barricade.Model.Pieces;

namespace Barricade.Model.Fields
{
    public class Forest : Field
    {
        private List<Piece> pieces;

        public Forest()
        {
            pieces = new List<Piece>();
        }

        public override void Enter(Piece piece)
        {
            pieces.Add(piece);
        }
        
        public override bool MayEnter(Piece piece)
        {
            throw new NotImplementedException();
        }
    }
}