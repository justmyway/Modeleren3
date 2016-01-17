using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barricade.View
{
    public abstract class FieldView : ViewColor
    {
        public FieldView()
        {
        }

        public abstract void Print(bool showVisitable);
    }
}
