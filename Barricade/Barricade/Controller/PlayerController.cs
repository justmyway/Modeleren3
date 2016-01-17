using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Barricade.View;
using Barricade.Model;
using Barricade.Model.Pieces;

namespace Barricade.Controller
{
    public class PlayerController
    {
        private PlayerView playerView;
        private GameController game;
        private Player PlayerModel;

        public PlayerController(GameController theGame, Color color) {
            game = theGame;
            playerView = new PlayerView();

            PlayerModel = new Player(color);

            //create pawns
            List<Pawn> Pawns = new List<Pawn>();
            Pawns.Add(new Pawn(PlayerModel.Color, this));
            Pawns.Add(new Pawn(PlayerModel.Color, this));
            Pawns.Add(new Pawn(PlayerModel.Color, this));
            Pawns.Add(new Pawn(PlayerModel.Color, this));

            PlayerModel.Pawns = Pawns;
        }

        public void AddStartAndForest(List<Field> startFields, Field forest)
        {
            PlayerModel.Forest = forest;
            PlayerModel.StartFields = startFields;
            for (int i = 0; i < PlayerModel.Pawns.Count; i++)
            {
                startFields[i].Enter(PlayerModel.Pawns[i]);
                PlayerModel.Pawns[i].Field = startFields[i];
            }
        }

        public void RelocateToForest(Pawn pawn)
        {
            PlayerModel.Forest.Enter(pawn);
        }

        public void RelocateToStart(Pawn pawn)
        {
            foreach (Field field in PlayerModel.StartFields)
            {
                if (field.MayEnter(pawn))
                {
                    field.Enter(pawn);
                    break;
                }
            }
        }

        public List<Pawn> GetPawns()
        {
            return PlayerModel.Pawns;
        }

        public Color GetColor()
        {
            return PlayerModel.Color;
        }

        public void RelocateBarricade(Barricade barricade)
        {
            //start @player startField
            List<Field> posibleFields = new List<Field>();
            List<Field> toVisitFields = new List<Field>();
            List<Field> visitedFields = new List<Field>();

            Field startField = PlayerModel.StartFields[0].CorrespondingFields[0];
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