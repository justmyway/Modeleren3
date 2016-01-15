using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barricade.View
{
    public class ForestFieldView : FieldView
    {
        public Field Field { get; }
        public ForestFieldView(Field field)
        {
            Field = field;
        }

        public override string Print()
        {
            return "F ";
        }
    }
}
