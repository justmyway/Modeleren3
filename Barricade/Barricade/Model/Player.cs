using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Barricade.Model.Fields;
using Barricade.View;

namespace Barricade
{
    public class Player
    {
        private PlayerView playerView;
        private GameController game;
        public Color Color { get; }
        public List<Pawn> Pawns { get; }
        private Field _forest;
        private List<Field> _startFields;

        public Player(GameController theGame, Color color) {
            game = theGame;
            playerView = new PlayerView();

            Color = color;

            //create pawns
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

        public void RelocateBarricade(Barricade barricade)
        {
            //start @player startField
            List<Field> posibleFields = new List<Field>();
            List<Field> toVisitFields = new List<Field>();
            List<Field> visitedFields = new List<Field>();

            Field startField = _startFields[0].CorrespondingFields[0];
            visitedFields.Add(startField);

            while (toVisitFields.Count != 0) {
                Field visitingField = toVisitFields[0];
                foreach (Field nieghtborghfield in visitingField.CorrespondingFields) {
                    if (!visitedFields.Contains(nieghtborghfield)) {

                        //check on when able to visit
                        if (nieghtborghfield.MayEnter(barricade) && !posibleFields.Contains(nieghtborghfield))
                            posibleFields.Add(nieghtborghfield);

                        toVisitFields.Add(nieghtborghfield);
                    }
                }
                visitedFields.Add(visitingField);
            }

            //show options
            int option = 1;
            foreach (Field move in posibleFields)
            {
                move.VisitableOption = option;
                option++;
            }

            game.ShowMap();

            int numberOfTries = 0;
            int chosenMove = 0;
            while (chosenMove > 0 && chosenMove < posibleFields.Count + 1)
            {
                string chosenOne = playerView.ChosePosibleMove(numberOfTries);
                chosenMove = Int32.Parse(chosenOne);
            }

            //reset options
            foreach (Field move in posibleFields) move.VisitableOption = 0;

            //relocate to Field
            posibleFields[chosenMove--].Enter(barricade);
        }
    }
}