using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barricade
{
    public abstract class Field
    {
        public abstract bool MayEnter(Piece piece);
        public abstract bool MayHist(Piece piece);
    }
}