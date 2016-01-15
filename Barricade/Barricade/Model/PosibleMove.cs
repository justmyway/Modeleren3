﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barricade.Model
{
    public class PosibleMove
    {
        public Field Field { set; get; }
        public Pawn Pawn { set; get; }

        public PosibleMove(Field newField, Pawn newPawn)
        {
            Field = newField;
            Pawn = newPawn;
        }
    }
}
