using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barricade.View
{
    public class FinishFieldView : TileFieldView
    {
        public FinishFieldView(Tile field) :base(field)
        {
            value = "E";
        }
    }
}
