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

        public List<PosibleMove> CheckMoveOptions(Field newField, int movesLeft, List<Field> previousFields, Pawn visitingPawn)
        {
            field = newField;
            List<PosibleMove> fields = new List<PosibleMove>();
            previousFields.Add(field);
            int movesleft = movesLeft--;

            //Barricade
            if (!field.MayPass()) {
                return fields;
            }

            //End field
            if (movesLeft == 0)
            {
                if (field.MayEnter(visitingPawn))
                {
                    fields.Add(new PosibleMove(field, visitingPawn));
                }
                return fields;
            }

            //Nieghbour fields
            foreach (Field visitingfield in field.CorrespondingFields)
            {
                Console.WriteLine(visitingfield);
                if (!previousFields.Contains(visitingfield))
                {
                    FieldController visitingController = new FieldController();
                    fields.AddRange(visitingController.CheckMoveOptions(visitingfield, movesLeft--, previousFields, visitingPawn));
                }
            }

            return fields;
        }
    }
}