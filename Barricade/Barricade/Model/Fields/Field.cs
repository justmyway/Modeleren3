using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Barricade.Model.Pieces;

namespace Barricade
{
    public abstract class Field
    {
        protected Field()
        {
            VisitableOption = 0;
        }

        public List<Field> CorrespondingFields { get; set; }
        public int VisitableOption { get; set; }
        public abstract bool MayEnter(Piece piece);
        public abstract void Enter(Piece piece);
    }
}