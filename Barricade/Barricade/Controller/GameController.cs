using Barricade.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Barricade.Controller;
using Barricade.Model;
using Barricade.View;

namespace Barricade
{
    public class GameController
    {
        private GameModel gameModel;
        private GameView gameView;

        public GameController()
        {
            //create Players 
            List<Player> players = new List<Player>();
            
            foreach (Color color in Enum.GetValues(typeof(Color)))
            {
                if(color == Color.NONE)
                    continue;
                
                players.Add(new Player(color));
            }

            gameModel = new GameModel(players);

            //current player
            gameModel.CurrentPlayer = gameModel.Players.First();

            CreateField();

            //create view
            gameView = new GameView(gameModel);
        }

        public void CreateField()
        {

        }

        public void Play()
        {
            while (!PlayerWon())
            {
                //throw dice
                ThrowDice();

                //calculate moves
                CalculateMoves();

                //set numbers to visitable fields
                GiveVisitableFieldsNumbers();

                //show map
                gameView.Print();

                //player make chose en relocate pawn
                ChoseMove();

                //reset numbers to visitable fields
                ResetVisitableFieldsNumbers();

                if (!PlayerWon())
                    NextPlayer();
            }

            CongratulationsMessage();
        }

        private void ThrowDice()
        {
            Random rnd = new Random();
            gameModel.Dice = rnd.Next(1, 7);
            gameView.DiceThrown();
        }

        private void CalculateMoves()
        {
            List<PosibleMove> posibleFields = new List<PosibleMove>();

            foreach (Pawn pawn in gameModel.CurrentPlayer.Pawns)
            {
                FieldController controller = new FieldController();
                posibleFields.AddRange(controller.CheckMoveOptions(pawn.Field, gameModel.Dice, null, pawn));
            }

            gameModel.PosibleMoves = posibleFields;
        }

        private void GiveVisitableFieldsNumbers()
        {
            int option = 1;
            foreach (PosibleMove move in gameModel.PosibleMoves)
            {
                move.Field.VisitableOption = option;
                option++;
            }
        }

        private void ChoseMove()
        {
            int numberOfTries = 0;
            int chosenMove = 0;
            while (chosenMove > 0 && chosenMove < gameModel.PosibleMoves.Count + 1)
            {
                string chosenOne = gameView.ChosePosibleMove(numberOfTries);
                chosenMove = Int32.Parse(chosenOne);
            }

            //relocate to Field
           RelocatePawn(gameModel.PosibleMoves[chosenMove--]);
        }

        private void RelocatePawn(PosibleMove move)
        {
            move.Field.Enter(move.Pawn);
        }

        private void ResetVisitableFieldsNumbers()
        {
            foreach (PosibleMove move in gameModel.PosibleMoves) move.Field.VisitableOption = 0;
        }

        private bool PlayerWon()
        {
            return gameModel.CurrentPlayer.Pawns.Count == 0;
        }

        private void NextPlayer()
        {
            gameModel.CurrentPlayer = gameModel.Players.Count >= gameModel.Players.IndexOf(gameModel.CurrentPlayer) + 1 ? gameModel.Players.First() : gameModel.Players[gameModel.Players.IndexOf(gameModel.CurrentPlayer) + 1];
        }

        private void CongratulationsMessage()
        {
            gameView.CongratulationsMessage();
        }
    }
}