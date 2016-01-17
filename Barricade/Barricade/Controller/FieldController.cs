using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barricade.Model;
using Barricade.Model.Pieces;

namespace Barricade.Controller
{
    public class FieldController
    {
        private Field field;

        public List<PossibleMove> CheckMoveOptions(Field newField, int movesLeft, List<Field> previousFields, Pawn visitingPawn)
        {
            field = newField;
            List<PossibleMove> fields = new List<PossibleMove>();
            previousFields.Clear();
            previousFields.Add(field);

            //End field
            if (movesLeft == 0)
            {
                if (field.MayEnter(visitingPawn))
                {
                    fields.Add(new PossibleMove(field, visitingPawn));
                }
                return fields;
            }
            movesLeft--;
            //Neighbour fields
            foreach (Field visitingfield in field.CorrespondingFields)
            {
                if (!visitingfield.MayPass())
                {
                    previousFields.Add(visitingfield);
                    continue;
                }
                if (!previousFields.Contains(visitingfield))
                {
                    FieldController visitingController = new FieldController();
                    fields.AddRange(visitingController.CheckMoveOptions(visitingfield, movesLeft, previousFields, visitingPawn));
                }
            }

            return fields;
        }
    }
}