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

        public override void Print()
        {
            Console.Write(value);
            if (Tile.Piece != null)
            {
                SetConsoleColor(Tile.Piece.Color);
                if (Tile.Piece.GetType() == typeof(Barricade))
                {
                    Console.Write("X");
                }
                else
                {                    
                    Console.Write("P");
                }
                ResetConsoleColor();
                if (Tile.VisitableOption == 0)
                    return;
            }
            if (Tile.VisitableOption != 0)
            {
                SetConsoleColor(ConsoleColor.Magenta);
                Console.Write(Tile.VisitableOption);
                ResetConsoleColor();
                return;
            }
            else
            {
                Console.Write(" ");
            }
            
        }
    }
}
