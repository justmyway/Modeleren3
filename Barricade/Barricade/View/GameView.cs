using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barricade.Model;

namespace Barricade.View
{
    class GameView : ViewColor
    {
        private GameModel gameModel;

        public GameView(GameModel gameModel)
        {
            this.gameModel = gameModel;
        }

        public void DiceThrown()
        {
            SetConsoleColor(gameModel.CurrentPlayer.Color);
            Console.Write(gameModel.CurrentPlayer.Color.ToString());
            ResetConsoleColor();
            Console.WriteLine(" has thrown " + gameModel.Dice);
        }
    }
}
