using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Barricade.Model.Fields;

namespace Barricade
{
    public class Player
    {
        public Color Color { get; }
        public List<Pawn> Pawns { get; }
        private Forest _forest;
        private List<Field> _startFields;

        public Player(Color color, List<Field> startFields, Forest forest) {
            Color = color;
            _forest = forest;
            _startFields = startFields;

            //pieces maken
            //todo
            Pawns = new List<Pawn>();
        }

        public void RelocateToForest(Pawn pawn)
        {
            _forest.Enter(pawn);
        }

        public void RelocateToStart(Pawn pawn)
        {
            foreach (Field field in _startFields)
            {
                if (field.MayEnter(pawn))
                {
                    field.Enter(pawn);
                    break;
                }
            }
        }
    }
}