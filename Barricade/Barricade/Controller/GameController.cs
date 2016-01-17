using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Barricade.Controller;
using Barricade.Model;
using Barricade.Model.Fields;
using Barricade.View;
using Barricade.Model.Pieces;

namespace Barricade.Controller
{
    public class GameController
    {
        private GameModel gameModel;
        private GameView gameView;

        //setup variables
        private Field forest;

        public GameController()
        {
            //create Players 
            List<PlayerController> players = new List<PlayerController>();
            
            foreach (Color color in Enum.GetValues(typeof(Color)))
            {
                if(color == Color.WHITE)
                    continue;
                
                players.Add(new PlayerController(this, color));
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
                ShowMap();

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
            gameModel.PosibleMoves.Clear();

            List<PosibleMove> posibleFields = new List<PosibleMove>();

            foreach (Pawn pawn in gameModel.CurrentPlayer.GetPawns())
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

        public void ShowMap()
        {
            gameView.Print();
        }

        private void ChoseMove()
        {
            int numberOfTries = 0;
            int chosenMove = 0;
            while (true)
            {
                string chosenOne = gameView.ChosePosibleMove(numberOfTries);
                chosenMove = Int32.Parse(chosenOne);
                if (chosenMove > 0 && chosenMove < gameModel.PosibleMoves.Count + 1)
                    break;                    
            }

            //relocate to Field
            chosenMove--;
            RelocatePawn(gameModel.PosibleMoves[chosenMove]);
        }

        private void RelocatePawn(PosibleMove move)
        {
            move.Pawn.Field.RemovePiece(move.Pawn);
            move.Field.Enter(move.Pawn);
            move.Pawn.Field = move.Pawn.Field;
        }

        private void ResetVisitableFieldsNumbers()
        {
            foreach (PosibleMove move in gameModel.PosibleMoves) move.Field.VisitableOption = 0;
        }

        private bool PlayerWon()
        {
            return gameModel.CurrentPlayer.GetPawns().Count == 0;
        }

        private void NextPlayer()
        {
            gameModel.CurrentPlayer = gameModel.Players.Count == gameModel.Players.IndexOf(gameModel.CurrentPlayer) + 1 ? gameModel.Players.First() : gameModel.Players[gameModel.Players.IndexOf(gameModel.CurrentPlayer) + 1];
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
            Tile tile15 = new Tile(true, true);
            fieldViews[1, 5] = new TileFieldView(tile15);
            Tile tile16 = new Tile(true);
            fieldViews[1, 6] = new TileFieldView(tile16);
            Tile tile17 = new Tile(true);
            fieldViews[1, 7] = new TileFieldView(tile17);
            Tile tile18 = new Tile(true);
            fieldViews[1, 8] = new TileFieldView(tile18);
            Tile tile19 = new Tile(true);
            fieldViews[1, 9] = new TileFieldView(tile19);

            Tile tile21 = new Tile(true);
            fieldViews[2, 1] = new TileFieldView(tile21);
            Tile tile22 = new Tile(true);
            fieldViews[2, 2] = new TileFieldView(tile22);
            Tile tile23 = new Tile(true);
            fieldViews[2, 3] = new TileFieldView(tile23);
            Tile tile24 = new RestTile(true);
            fieldViews[2, 4] = new RestFieldView(tile24);
            Tile tile25 = new Tile(true,true);
            fieldViews[2, 5] = new TileFieldView(tile25);
            Tile tile26 = new RestTile(true);
            fieldViews[2, 6] = new RestFieldView(tile26);
            Tile tile27 = new Tile(true);
            fieldViews[2, 7] = new TileFieldView(tile27);
            Tile tile28 = new Tile(true);
            fieldViews[2, 8] = new TileFieldView(tile28);
            Tile tile29 = new Tile(true);
            fieldViews[2, 9] = new TileFieldView(tile29);

            Tile tile32 = new Tile(true);
            fieldViews[3, 2] = new TileFieldView(tile32);
            Tile tile33 = new Tile(true);
            fieldViews[3, 3] = new TileFieldView(tile33);
            Tile tile34 = new Tile(true,true);
            fieldViews[3, 4] = new TileFieldView(tile34);
            Tile tile35 = new Tile(true);
            fieldViews[3, 5] = new TileFieldView(tile35);
            Tile tile36 = new Tile(true,true);
            fieldViews[3, 6] = new TileFieldView(tile36);
            Tile tile37 = new Tile(true);
            fieldViews[3, 7] = new TileFieldView(tile37);
            Tile tile38 = new Tile(true);
            fieldViews[3, 8] = new TileFieldView(tile38);

            Tile tile42 = new RestTile(false);
            fieldViews[4, 2] = new RestFieldView(tile42);
            Tile tile43 = new Tile(true,true);
            fieldViews[4, 3] = new TileFieldView(tile43);
            Tile tile44 = new Tile(true);
            fieldViews[4, 4] = new TileFieldView(tile44);
            Tile tile45 = new Tile(true);
            fieldViews[4, 5] = new TileFieldView(tile45);
            Tile tile46 = new Tile(true);
            fieldViews[4, 6] = new TileFieldView(tile46);
            Tile tile47 = new Tile(true,true);
            fieldViews[4, 7] = new TileFieldView(tile47);
            Tile tile48 = new RestTile(false);
            fieldViews[4, 8] = new RestFieldView(tile48);

            Tile tile53 = new Tile(false);
            fieldViews[5, 3] = new TileFieldView(tile53);
            Tile tile54 = new Tile(false);
            fieldViews[5, 4] = new TileFieldView(tile54);
            Tile tile55 = new RestTile(false);
            fieldViews[5, 5] = new RestFieldView(tile55);
            Tile tile56 = new Tile(false);
            fieldViews[5, 6] = new TileFieldView(tile56);
            Tile tile57 = new Tile(false);
            fieldViews[5, 7] = new TileFieldView(tile57);

            forest = new Forest();
            fieldViews[6, 5] = new ForestFieldView(forest);
            fieldViews[6, 4] = new ForestFieldView(forest);
            fieldViews[6, 6] = new ForestFieldView(forest);

            Tile tile70 = new RestTile(false);
            fieldViews[7, 0] = new RestFieldView(tile70);
            Tile tile71 = new Tile(false);
            fieldViews[7, 1] = new TileFieldView(tile71);
            Tile tile72 = new RestTile(false);
            fieldViews[7, 2] = new RestFieldView(tile72);
            Tile tile73 = new Tile(false);
            fieldViews[7, 3] = new TileFieldView(tile73);
            Tile tile74 = new Tile(false);
            fieldViews[7, 4] = new TileFieldView(tile74);
            Tile tile75 = new RestTile(false);
            fieldViews[7, 5] = new RestFieldView(tile75);
            Tile tile76 = new Tile(false);
            fieldViews[7, 6] = new TileFieldView(tile76);
            Tile tile77 = new Tile(false);
            fieldViews[7, 7] = new TileFieldView(tile77);
            Tile tile78 = new RestTile(false);
            fieldViews[7, 8] = new RestFieldView(tile78);
            Tile tile79 = new Tile(false);
            fieldViews[7, 9] = new TileFieldView(tile79);
            Tile tile710 = new RestTile(false);
            fieldViews[7, 10] = new RestFieldView(tile710);

            Tile tile80 = new Tile(false, false, true);
            fieldViews[8, 0] = new TileFieldView(tile80);
            Tile tile81 = new Tile(false, false, true);
            fieldViews[8, 1] = new TileFieldView(tile81);
            Tile tile82 = new Tile(false, false, true);
            fieldViews[8, 2] = new TileFieldView(tile82);
            Tile tile83 = new Tile(false, false, true);
            fieldViews[8, 3] = new TileFieldView(tile83);
            Tile tile84 = new Tile(false, false, true);
            fieldViews[8, 4] = new TileFieldView(tile84);
            Tile tile85 = new Tile(false, false, true);
            fieldViews[8, 5] = new TileFieldView(tile85);
            Tile tile86 = new Tile(false, false, true);
            fieldViews[8, 6] = new TileFieldView(tile86);
            Tile tile87 = new Tile(false, false, true);
            fieldViews[8, 7] = new TileFieldView(tile87);
            Tile tile88 = new Tile(false, false, true);
            fieldViews[8, 8] = new TileFieldView(tile88);
            Tile tile89 = new Tile(false, false, true);
            fieldViews[8, 9] = new TileFieldView(tile89);
            Tile tile810 = new Tile(false, false, true);
            fieldViews[8, 10] = new TileFieldView(tile810);

            Tile tile90 = new Tile(false);
            fieldViews[9, 0] = new TileFieldView(tile90);
            Tile tile91 = new Tile(false);
            fieldViews[9, 1] = new TileFieldView(tile91);
            Tile tile93 = new Tile(false);
            fieldViews[9, 3] = new TileFieldView(tile93);
            Tile tile94 = new Tile(false);
            fieldViews[9, 4] = new TileFieldView(tile94);
            Tile tile96 = new Tile(false);
            fieldViews[9, 6] = new TileFieldView(tile96);
            Tile tile97 = new Tile(false);
            fieldViews[9, 7] = new TileFieldView(tile97);
            Tile tile99 = new Tile(false);
            fieldViews[9, 9] = new TileFieldView(tile99);
            Tile tile910 = new Tile(false);
            fieldViews[9, 10] = new TileFieldView(tile910);

            Tile tile100 = new Tile(false);
            fieldViews[10, 0] = new TileFieldView(tile100);
            Tile tile101 = new Tile(false);
            fieldViews[10, 1] = new TileFieldView(tile101);
            Tile tile103 = new Tile(false);
            fieldViews[10, 3] = new TileFieldView(tile103);
            Tile tile104 = new Tile(false);
            fieldViews[10, 4] = new TileFieldView(tile104);
            Tile tile106 = new Tile(false);
            fieldViews[10, 6] = new TileFieldView(tile106);
            Tile tile107 = new Tile(false);
            fieldViews[10, 7] = new TileFieldView(tile107);
            Tile tile109 = new Tile(false);
            fieldViews[10, 9] = new TileFieldView(tile109);
            Tile tile1010 = new Tile(false);
            fieldViews[10, 10] = new TileFieldView(tile1010);
            gameView.SetField(fieldViews);

            tile11.CorrespondingFields.Add(tile21);
            tile11.CorrespondingFields.Add(tile12);
            tile12.CorrespondingFields.Add(tile11);
            tile12.CorrespondingFields.Add(tile13);
            tile13.CorrespondingFields.Add(tile12);
            tile13.CorrespondingFields.Add(tile14);
            tile14.CorrespondingFields.Add(tile13);
            tile14.CorrespondingFields.Add(tile15);
            tile15.CorrespondingFields.Add(finishTile);
            tile15.CorrespondingFields.Add(tile14);
            tile15.CorrespondingFields.Add(tile16);
            tile16.CorrespondingFields.Add(tile15);
            tile16.CorrespondingFields.Add(tile17);
            tile17.CorrespondingFields.Add(tile16);
            tile17.CorrespondingFields.Add(tile18);
            tile18.CorrespondingFields.Add(tile17);
            tile18.CorrespondingFields.Add(tile19);
            tile19.CorrespondingFields.Add(tile18);
            tile19.CorrespondingFields.Add(tile29);

            tile21.CorrespondingFields.Add(tile11);
            tile21.CorrespondingFields.Add(tile22);
            tile22.CorrespondingFields.Add(tile21);
            tile22.CorrespondingFields.Add(tile23);
            tile23.CorrespondingFields.Add(tile22);
            tile23.CorrespondingFields.Add(tile24);
            tile24.CorrespondingFields.Add(tile23);
            tile24.CorrespondingFields.Add(tile25);
            tile25.CorrespondingFields.Add(tile35);
            tile25.CorrespondingFields.Add(tile24);
            tile25.CorrespondingFields.Add(tile26);
            tile26.CorrespondingFields.Add(tile25);
            tile26.CorrespondingFields.Add(tile27);
            tile27.CorrespondingFields.Add(tile26);
            tile27.CorrespondingFields.Add(tile28);
            tile28.CorrespondingFields.Add(tile27);
            tile28.CorrespondingFields.Add(tile29);
            tile29.CorrespondingFields.Add(tile28);
            tile29.CorrespondingFields.Add(tile19);

            tile32.CorrespondingFields.Add(tile42);
            tile32.CorrespondingFields.Add(tile33);
            tile33.CorrespondingFields.Add(tile32);
            tile33.CorrespondingFields.Add(tile34);
            tile34.CorrespondingFields.Add(tile33);
            tile34.CorrespondingFields.Add(tile35);
            tile35.CorrespondingFields.Add(tile25);
            tile35.CorrespondingFields.Add(tile34);
            tile35.CorrespondingFields.Add(tile36);
            tile36.CorrespondingFields.Add(tile35);
            tile36.CorrespondingFields.Add(tile37);
            tile37.CorrespondingFields.Add(tile36);
            tile37.CorrespondingFields.Add(tile38);
            tile38.CorrespondingFields.Add(tile37);
            tile38.CorrespondingFields.Add(tile48);

            tile42.CorrespondingFields.Add(tile32);
            tile42.CorrespondingFields.Add(tile43);
            tile43.CorrespondingFields.Add(tile42);
            tile43.CorrespondingFields.Add(tile44);
            tile44.CorrespondingFields.Add(tile43);
            tile44.CorrespondingFields.Add(tile45);
            tile45.CorrespondingFields.Add(tile55);
            tile45.CorrespondingFields.Add(tile44);
            tile45.CorrespondingFields.Add(tile46);
            tile46.CorrespondingFields.Add(tile45);
            tile46.CorrespondingFields.Add(tile47);
            tile47.CorrespondingFields.Add(tile46);
            tile47.CorrespondingFields.Add(tile48);
            tile48.CorrespondingFields.Add(tile47);
            tile48.CorrespondingFields.Add(tile38);

            tile53.CorrespondingFields.Add(tile73);
            tile53.CorrespondingFields.Add(tile54);
            tile54.CorrespondingFields.Add(tile53);
            tile54.CorrespondingFields.Add(tile55);
            tile55.CorrespondingFields.Add(tile45);
            tile55.CorrespondingFields.Add(tile54);
            tile55.CorrespondingFields.Add(tile56);
            tile56.CorrespondingFields.Add(tile55);
            tile56.CorrespondingFields.Add(tile57);
            tile57.CorrespondingFields.Add(tile56);
            tile57.CorrespondingFields.Add(tile77);

            forest.CorrespondingFields.Add(tile55);

            tile70.CorrespondingFields.Add(tile80);
            tile70.CorrespondingFields.Add(tile71);
            tile71.CorrespondingFields.Add(tile70);
            tile71.CorrespondingFields.Add(tile72);
            tile72.CorrespondingFields.Add(tile82);
            tile72.CorrespondingFields.Add(tile71);
            tile72.CorrespondingFields.Add(tile73);
            tile73.CorrespondingFields.Add(tile53);
            tile73.CorrespondingFields.Add(tile72);
            tile73.CorrespondingFields.Add(tile74);
            tile74.CorrespondingFields.Add(tile73);
            tile74.CorrespondingFields.Add(tile75);
            tile75.CorrespondingFields.Add(tile85);
            tile75.CorrespondingFields.Add(tile74);
            tile75.CorrespondingFields.Add(tile76);
            tile76.CorrespondingFields.Add(tile75);
            tile76.CorrespondingFields.Add(tile77);
            tile77.CorrespondingFields.Add(tile57);
            tile77.CorrespondingFields.Add(tile76);
            tile77.CorrespondingFields.Add(tile78);
            tile78.CorrespondingFields.Add(tile88);
            tile78.CorrespondingFields.Add(tile77);
            tile78.CorrespondingFields.Add(tile79);
            tile79.CorrespondingFields.Add(tile78);
            tile79.CorrespondingFields.Add(tile710);
            tile710.CorrespondingFields.Add(tile79);
            tile710.CorrespondingFields.Add(tile810);

            tile80.CorrespondingFields.Add(tile70);
            tile80.CorrespondingFields.Add(tile81);
            tile81.CorrespondingFields.Add(tile80);
            tile81.CorrespondingFields.Add(tile82);
            tile82.CorrespondingFields.Add(tile72);
            tile82.CorrespondingFields.Add(tile81);
            tile82.CorrespondingFields.Add(tile83);
            tile83.CorrespondingFields.Add(tile53);
            tile83.CorrespondingFields.Add(tile82);
            tile83.CorrespondingFields.Add(tile84);
            tile84.CorrespondingFields.Add(tile83);
            tile84.CorrespondingFields.Add(tile85);
            tile85.CorrespondingFields.Add(tile75);
            tile85.CorrespondingFields.Add(tile84);
            tile85.CorrespondingFields.Add(tile86);
            tile86.CorrespondingFields.Add(tile85);
            tile86.CorrespondingFields.Add(tile87);
            tile87.CorrespondingFields.Add(tile57);
            tile87.CorrespondingFields.Add(tile86);
            tile87.CorrespondingFields.Add(tile88);
            tile88.CorrespondingFields.Add(tile88);
            tile88.CorrespondingFields.Add(tile87);
            tile88.CorrespondingFields.Add(tile89);
            tile89.CorrespondingFields.Add(tile78);
            tile89.CorrespondingFields.Add(tile810);
            tile810.CorrespondingFields.Add(tile89);
            tile810.CorrespondingFields.Add(tile710);

            tile100.CorrespondingFields.Add(tile81);
            tile101.CorrespondingFields.Add(tile81);
            tile90.CorrespondingFields.Add(tile81);
            tile91.CorrespondingFields.Add(tile81);

            tile103.CorrespondingFields.Add(tile83);
            tile104.CorrespondingFields.Add(tile83);
            tile93.CorrespondingFields.Add(tile83);
            tile94.CorrespondingFields.Add(tile83);

            tile106.CorrespondingFields.Add(tile76);
            tile107.CorrespondingFields.Add(tile76);
            tile96.CorrespondingFields.Add(tile76);
            tile97.CorrespondingFields.Add(tile76);

            tile109.CorrespondingFields.Add(tile79);
            tile1010.CorrespondingFields.Add(tile79);
            tile99.CorrespondingFields.Add(tile79);
            tile910.CorrespondingFields.Add(tile79);

            gameModel.Players[0].AddStartAndForest(new List<Field>() { tile100, tile101, tile90, tile91 }, forest);
            gameModel.Players[1].AddStartAndForest(new List<Field>() { tile103, tile104, tile93, tile94 }, forest);
            gameModel.Players[2].AddStartAndForest(new List<Field>() { tile106, tile107, tile96, tile97 }, forest);
            gameModel.Players[3].AddStartAndForest(new List<Field>() { tile109, tile1010, tile99, tile910 }, forest);
        }
    }
}