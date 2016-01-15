using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Barricade.Controller;
using Barricade.Model;
using Barricade.Model.Fields;
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

            //create view
            gameView = new GameView(gameModel);

            //Create the field
            CreateField();
            gameView.Print();
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

        private void CreateField()
        {
            FieldView[,] fieldViews = new FieldView[11, 11];
            FinishTile finishTile = new FinishTile();
            fieldViews[0, 5] = new FinishFieldView(finishTile);

            Tile tile11 = new Tile(true);
            fieldViews[1, 1] = new TileFieldView(tile11);
            Tile tile12 = new Tile(true);
            fieldViews[1, 2] = new TileFieldView(tile12);
            Tile tile13 = new Tile(true);
            fieldViews[1, 3] = new TileFieldView(tile13);
            Tile tile14 = new Tile(true);
            fieldViews[1, 4] = new TileFieldView(tile14);
            Tile tile15 = new Tile(true);
            fieldViews[1, 5] = new TileFieldView(tile15);
            Tile tile16 = new Tile();
            fieldViews[1, 6] = new TileFieldView(tile16);
            Tile tile17 = new Tile();
            fieldViews[1, 7] = new TileFieldView(tile17);
            Tile tile18 = new Tile();
            fieldViews[1, 8] = new TileFieldView(tile18);
            Tile tile19 = new Tile();
            fieldViews[1, 9] = new TileFieldView(tile19);

            Tile tile21 = new Tile();
            fieldViews[2, 1] = new TileFieldView(tile21);
            Tile tile22 = new Tile();
            fieldViews[2, 2] = new TileFieldView(tile22);
            Tile tile23 = new Tile();
            fieldViews[2, 3] = new TileFieldView(tile23);
            Tile tile24 = new RestTile();
            fieldViews[2, 4] = new RestFieldView(tile24);
            Tile tile25 = new Tile(true);
            fieldViews[2, 5] = new TileFieldView(tile25);
            Tile tile26 = new RestTile();
            fieldViews[2, 6] = new RestFieldView(tile26);
            Tile tile27 = new Tile();
            fieldViews[2, 7] = new TileFieldView(tile27);
            Tile tile28 = new Tile();
            fieldViews[2, 8] = new TileFieldView(tile28);
            Tile tile29 = new Tile();
            fieldViews[2, 9] = new TileFieldView(tile29);

            Tile tile32 = new Tile();
            fieldViews[3, 2] = new TileFieldView(tile32);
            Tile tile33 = new Tile();
            fieldViews[3, 3] = new TileFieldView(tile33);
            Tile tile34 = new Tile(true);
            fieldViews[3, 4] = new TileFieldView(tile34);
            Tile tile35 = new Tile();
            fieldViews[3, 5] = new TileFieldView(tile35);
            Tile tile36 = new Tile(true);
            fieldViews[3, 6] = new TileFieldView(tile36);
            Tile tile37 = new Tile();
            fieldViews[3, 7] = new TileFieldView(tile37);
            Tile tile38 = new Tile();
            fieldViews[3, 8] = new TileFieldView(tile38);

            Tile tile42 = new RestTile();
            fieldViews[4, 2] = new RestFieldView(tile42);
            Tile tile43 = new Tile(true);
            fieldViews[4, 3] = new TileFieldView(tile43);
            Tile tile44 = new Tile();
            fieldViews[4, 4] = new TileFieldView(tile44);
            Tile tile45 = new Tile();
            fieldViews[4, 5] = new TileFieldView(tile45);
            Tile tile46 = new Tile();
            fieldViews[4, 6] = new TileFieldView(tile46);
            Tile tile47 = new Tile(true);
            fieldViews[4, 7] = new TileFieldView(tile47);
            Tile tile48 = new RestTile();
            fieldViews[4, 8] = new RestFieldView(tile48);

            Tile tile53 = new Tile();
            fieldViews[5, 3] = new TileFieldView(tile53);
            Tile tile54 = new Tile();
            fieldViews[5, 4] = new TileFieldView(tile54);
            Tile tile55 = new RestTile();
            fieldViews[5, 5] = new RestFieldView(tile55);
            Tile tile56 = new Tile();
            fieldViews[5, 6] = new TileFieldView(tile56);
            Tile tile57 = new Tile();
            fieldViews[5, 7] = new TileFieldView(tile57);

            Field forest = new Forest();
            fieldViews[6, 5] = new ForestFieldView(forest);
            fieldViews[6, 4] = new ForestFieldView(forest);
            fieldViews[6, 6] = new ForestFieldView(forest);

            Tile tile70 = new RestTile();
            fieldViews[7, 0] = new RestFieldView(tile70);
            Tile tile71 = new Tile();
            fieldViews[7, 1] = new TileFieldView(tile71);
            Tile tile72 = new RestTile();
            fieldViews[7, 2] = new RestFieldView(tile72);
            Tile tile73 = new Tile();
            fieldViews[7, 3] = new TileFieldView(tile73);
            Tile tile74 = new Tile();
            fieldViews[7, 4] = new TileFieldView(tile74);
            Tile tile75 = new RestTile();
            fieldViews[7, 5] = new RestFieldView(tile75);
            Tile tile76 = new Tile();
            fieldViews[7, 6] = new TileFieldView(tile76);
            Tile tile77 = new Tile();
            fieldViews[7, 7] = new TileFieldView(tile77);
            Tile tile78 = new RestTile();
            fieldViews[7, 8] = new RestFieldView(tile78);
            Tile tile79 = new Tile();
            fieldViews[7, 9] = new TileFieldView(tile79);
            Tile tile710 = new RestTile();
            fieldViews[7, 10] = new RestFieldView(tile710);

            Tile tile80 = new Tile();
            fieldViews[8, 0] = new TileFieldView(tile80);
            Tile tile81 = new Tile();
            fieldViews[8, 1] = new TileFieldView(tile81);
            Tile tile82 = new Tile();
            fieldViews[8, 2] = new TileFieldView(tile82);
            Tile tile83 = new Tile();
            fieldViews[8, 3] = new TileFieldView(tile83);
            Tile tile84 = new Tile();
            fieldViews[8, 4] = new TileFieldView(tile84);
            Tile tile85 = new Tile();
            fieldViews[8, 5] = new TileFieldView(tile85);
            Tile tile86 = new Tile();
            fieldViews[8, 6] = new TileFieldView(tile86);
            Tile tile87 = new Tile();
            fieldViews[8, 7] = new TileFieldView(tile87);
            Tile tile88 = new Tile();
            fieldViews[8, 8] = new TileFieldView(tile88);
            Tile tile89 = new Tile();
            fieldViews[8, 9] = new TileFieldView(tile89);
            Tile tile810 = new Tile();
            fieldViews[8, 10] = new TileFieldView(tile810);

            Tile tile90 = new Tile();
            fieldViews[9, 0] = new TileFieldView(tile90);
            Tile tile91 = new Tile();
            fieldViews[9, 1] = new TileFieldView(tile91);
            Tile tile93 = new Tile();
            fieldViews[9, 3] = new TileFieldView(tile93);
            Tile tile94 = new Tile();
            fieldViews[9, 4] = new TileFieldView(tile94);
            Tile tile96 = new Tile();
            fieldViews[9, 6] = new TileFieldView(tile96);
            Tile tile97 = new Tile();
            fieldViews[9, 7] = new TileFieldView(tile97);
            Tile tile99 = new Tile();
            fieldViews[9, 9] = new TileFieldView(tile99);
            Tile tile910 = new Tile();
            fieldViews[9, 10] = new TileFieldView(tile910);

            Tile tile100 = new Tile();
            fieldViews[10, 0] = new TileFieldView(tile100);
            Tile tile101 = new Tile();
            fieldViews[10, 1] = new TileFieldView(tile101);
            Tile tile103 = new Tile();
            fieldViews[10, 3] = new TileFieldView(tile103);
            Tile tile104 = new Tile();
            fieldViews[10, 4] = new TileFieldView(tile104);
            Tile tile106 = new Tile();
            fieldViews[10, 6] = new TileFieldView(tile106);
            Tile tile107 = new Tile();
            fieldViews[10, 7] = new TileFieldView(tile107);
            Tile tile109 = new Tile();
            fieldViews[10, 9] = new TileFieldView(tile109);
            Tile tile1010 = new Tile();
            fieldViews[10, 10] = new TileFieldView(tile1010);
            gameView.SetField(fieldViews);
        }
    }
}