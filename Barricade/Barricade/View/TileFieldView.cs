using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barricade.Model.Fields;

namespace Barricade.View
{
    public class TileFieldView : FieldView
    {
        public Tile Tile { get; set; }
        protected string value;

        public TileFieldView(Tile tile)
        {
            Tile = tile;
            value = "O";
        }

        public TileFieldView() : base()
        {
        }

        public override string Print()
        {
            if (Tile.Piece != null)
            {
                if (Tile.Piece.GetType() == typeof(Barricade))
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
