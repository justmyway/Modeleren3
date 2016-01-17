using Barricade.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barricade.Model.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Color color, PlayerController owner)
        {
            Color = color;
            Owner = owner;
        }

        public PlayerController Owner { get; }
    }
}