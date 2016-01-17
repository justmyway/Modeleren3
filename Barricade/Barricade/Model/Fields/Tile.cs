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

        public Tile(bool village)
        {
            Village = village;
        }

        public Tile(bool village, bool hasBarricade)
        {
            Village = village;
            Piece = new Barricade();
        }

        public Tile(bool village, bool hasBarricade, bool firstRow)
        {
            Village = village;
            if (hasBarricade) Piece = new Barricade();
            if (firstRow) FirstRow = firstRow;
        }

        public override bool MayEnter(Piece visiting_piece)
        {
            if (visiting_piece.Color == Color.WHITE)
            {
                if (FirstRow || Piece != null)
                    return false;

                return true;
            }

            if(Piece != null)
                return visiting_piece.Color != Piece.Color;

            return true;
        }

        public override bool MayPass()
        {
            if (Piece != null)
                if (Piece.Color == Color.WHITE)
                    return false;

            return true;
        }

        public override void Enter(Piece visiting_piece)
        {
            if (Piece == null)
            {
                Piece = visiting_piece;
                return;
            }
            if (visiting_piece.Color != Piece.Color)
                Console.WriteLine("/* This move is not posible */");

            Piece oldPiece = Piece;
            Piece = visiting_piece;

            //relocate Piece
            if (oldPiece.GetType() == typeof (Barricade))
            {
                Pawn pawn = (Pawn)visiting_piece;
                Barricade barricade = (Barricade)oldPiece;
                pawn.Owner.RelocateBarricade(barricade);
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
            Piece.Field.RemovePiece(Piece);
            Piece.Field = this;
        }

        public override void RemovePiece(Piece piece)
        {
            Piece = null;
        }
    }
}