using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barricade.Model;

namespace Barricade.Controller
{
    public class FieldController
    {
        private Field field;

        public List<PosibleMove> CheckMoveOptions(Field newField, int movesLeft, Field previousField, Pawn visitingPawn)
        {
            Console.WriteLine("Checkfield");

            field = newField;
            List<PosibleMove> fields = new List<PosibleMove>();

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
                if (previousField != visitingfield)
                {
                    FieldController visitingController = new FieldController();
                    fields.AddRange(visitingController.CheckMoveOptions(visitingfield, movesLeft--, field, visitingPawn));
                }
            }

            return fields;
        }
    }
}
