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
        private Field _forest;
        private List<Field> _startFields;

        public Player(Color color) {
            Color = color;
            

            //pieces maken
            //todo
            Pawns = new List<Pawn>();
            Pawns.Add(new Pawn(Color, this));
            Pawns.Add(new Pawn(Color, this));
            Pawns.Add(new Pawn(Color, this));
            Pawns.Add(new Pawn(Color, this));
        }

        public void AddStartAndForest(List<Field> startFields, Field forest)
        {
            _forest = forest;
            _startFields = startFields;
            for (int i = 0; i < Pawns.Count; i++)
            {
                startFields[i].Enter(Pawns[i]);
            }
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