using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barricade
{
    public class Start : BigTile
    {
        //settings
        int amount_of_start_players = 4;


        public Start(List<Piece> pawns) {
            pieces = pawns;
        }

        public override bool MayEnter(Piece piece)
        {
            if (base.MayEnter(piece) && pieces.Count < amount_of_start_players)
                return true;

            return false;
        }

        public void Enter(Piece piece)
        {
            pieces.Add(piece);
        }
    }
}