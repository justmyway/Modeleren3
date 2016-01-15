using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barricade.Model.Fields;

namespace Barricade.View
{
    public class RestFieldView : TileFieldView
    {
        public RestFieldView(Tile field) :base(field)
        {
            value = "R";
        }
    }
}
