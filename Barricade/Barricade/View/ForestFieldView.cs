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

        public override void Print()
        {
            Console.Write("F");
            if (Field.VisitableOption != 0)
            {
                Console.Write(Field.VisitableOption);
            }
        }
    }
}
