using Barricade.Model.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barricade.Model
{
    public class PossibleMove
    {
        public Field Field { set; get; }
        public Pawn Pawn { set; get; }

        public PossibleMove(Field newField, Pawn newPawn)
        {
            Field = newField;
            Pawn = newPawn;
        }
    }
}
