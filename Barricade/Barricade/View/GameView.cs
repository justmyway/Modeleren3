using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barricade.Model;

namespace Barricade.View
{
    public class GameView : ViewColor
    {
    	private GameModel gameModel;
    
        private FieldView[,] fields;
        char[,] horizontalConnections;
        char[,] verticalConnections;

        public GameView(GameModel gameModel)
        {     
        	this.gameModel = gameModel;

            horizontalConnections = new char[11, 11] { 
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, 
                { ' ', '-', '-', '-', '-', '-', '-', '-', '-', ' ', ' ' }, 
                { ' ', '-', '-', '-', '-', '-', '-', '-', '-', ' ', ' ' }, 
                { ' ', ' ', '-', '-', '-', '-', '-', '-', ' ', ' ', ' ' },
                { ' ', ' ', '-', '-', '-', '-', '-', '-', ' ', ' ', ' ' }, 
                { ' ', ' ', ' ', '-', '-', '-', '-', ' ', ' ', ' ', ' ' }, 
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', ' ' }, 
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', ' ' },
                { '-', ' ', ' ', '-', ' ', ' ', '-', ' ', ' ', '-', ' ' },
                { '-', ' ', ' ', '-', ' ', ' ', '-', ' ', ' ', '-', ' ' }, };
            verticalConnections = new char[11, 11] {
                { ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ' },
                { ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ' },
                { ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ' },
                { ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ' },
                { ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ' },
                { ' ', ' ', ' ', '|', ' ', '|', ' ', '|', ' ', ' ', ' ' },
                { ' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ' },
                { '|', ' ', '|', ' ', ' ', '|', ' ', ' ', '|', ' ', '|' },
                { ' ', '|', ' ', '|', ' ', ' ', ' ', '|', ' ', '|', ' ' },
                { '|', '|', ' ', '|', '|', ' ', '|', '|', ' ', '|', '|' },
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, };

        }

        public void SetField(FieldView[,] fieldViews)
        {
            fields = fieldViews;
        }

        public void Print()
        {
            for (int y = 0; y < fields.GetLength(0); y++)
            {
                for (int x = 0; x < fields.GetLength(1); x++)
                {
                    if (fields[y,x] != null)
                    {
                        Console.Write(fields[y, x].Print());
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    Console.Write(horizontalConnections[y, x]);
                    Console.Write(horizontalConnections[y, x]);
                }
                Console.WriteLine();
                for (int x = 0; x < verticalConnections.GetLength(1); x++)
                {
                    Console.Write(verticalConnections[y,x] + "   ");
                }
                Console.WriteLine();
            }
        }
        
        public void DiceThrown()
        {
            SetConsoleColor(gameModel.CurrentPlayer.Color);
            Console.Write(gameModel.CurrentPlayer.Color.ToString());
            ResetConsoleColor();
            Console.WriteLine(" has thrown " + gameModel.Dice + ".");
        }

        public void CongratulationsMessage()
        {
            SetConsoleColor(gameModel.CurrentPlayer.Color);
            Console.WriteLine("-- Congratulations player " + gameModel.CurrentPlayer.Color.ToString() + " you have won!!! --");
            ResetConsoleColor();
        }
    }
}
