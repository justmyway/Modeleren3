using Barricade.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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

                //show map
                gameView.Print();

                //read input
                ReadMove();

                //calculate moves

                //player make chose

                //move pawn

                if(!PlayerWon())
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

        private void ReadMove()
        {
            //string input = Console.Read();
        }

        private bool PlayerWon()
        {
            return gameModel.CurrentPlayer.Pieces.Count == 0;
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