using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Barricade.Model.Pieces;

namespace Barricade.Model.Fields
{
    public class Tile : Field
    {
        public Piece Piece { get; set; }

        public override bool MayEnter(Piece visiting_piece)
        {
            return visiting_piece.Color != Piece.Color;
        }

        public override void Enter(Piece visiting_piece)
        {
            if (visiting_piece.Color != Piece.Color)
                Console.WriteLine("/* This move is not posible */");

            Piece oldPiece = Piece;
            Piece = visiting_piece;

            //relocate Piece
            if (oldPiece.GetType() == typeof (Barricade))
            {
                //relocate barricade
                //todo
            }
            else
            {
                Pawn pawn = (Pawn)oldPiece;
                if (Village)
                {
                    pawn.Owner.RelocateToForest(pawn);
                }
                else
                {
                    pawn.Owner.RelocateToStart(pawn);
                }
            }
        }

        public override void RemovePiece(Piece piece)
        {
            Piece = null;
        }

        public Tile(bool village)
        {
            Village = village;
        }

        public Tile(bool hasBarricade, bool village)
        {
            Village = village;
            Piece = new Barricade();
        }
    }
}