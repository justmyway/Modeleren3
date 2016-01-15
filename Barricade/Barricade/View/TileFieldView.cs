using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barricade.View
{
    public class TileFieldView : FieldView
    {
        public Tile Tile { get; }
        protected string value;

        public TileFieldView(Tile tile)
        {
            Tile = tile;
            value = "O";
        }

        public override string Print()
        {
            if (Tile.piece != null)
            {
                if (Tile.piece.GetType() == typeof(Barricade))
                {
                    return value + "X";
                }
                else
                {
                    return value + "P";
                }
            }
            return value + " ";
        }
    }
}
