using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Barricade.Model.Pieces;

namespace Barricade.Model.Fields
{
    public class RestTile : Tile
    {
        public RestTile(bool village) : base(village)
        {
        }
        public RestTile(bool hasBarricade, bool village) : base(hasBarricade, village)
        {
        }
        
        public override bool MayEnter(Piece visiting_piece) {
            if (visiting_piece.Color == Color.WHITE)
                return false;

            return Piece == null;
        }

        public override void Enter(Piece piece) {
            if(Piece != null)
                Console.WriteLine("/* This move is not posible */");

            Piece = piece;
            Piece.Field = this;
        }

        
    }
}