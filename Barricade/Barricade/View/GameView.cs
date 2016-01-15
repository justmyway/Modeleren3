﻿using System;
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
    
        FieldView[,] fields;
        char[,] horizontalConnections;
        char[,] verticalConnections;

        public GameView(GameModel gameModel)
        {
        
        	this.gameModel = gameModel;
        
            fields = new FieldView[11,11];
            for (int x = 0; x < fields.GetLength(0); x ++)
            {
                for (int y = 0; y < fields.GetLength(1); y++)
                {
                    fields[x, y] = new FieldView();
                }
            }
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

        public void Print()
        {
            for (int x = 0; x < fields.GetLength(0); x++)
            {
                for (int y = 0; y < fields.GetLength(1); y++)
                {
                    if (fields[x,y] != null)
                    {
                        Console.Write(fields[x, y].Value);
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    Console.Write(horizontalConnections[x, y]);
                    Console.Write(horizontalConnections[x, y]);
                }
                Console.WriteLine();
                for (int y = 0; y < verticalConnections.GetLength(1); y++)
                {
                    Console.Write(verticalConnections[x,y] + "   ");
                }
                Console.WriteLine();
            }
        }
        
        public void DiceThrown()
        {
            Console.Write("-- Next round --");
            SetConsoleColor(gameModel.CurrentPlayer.Color);
            Console.Write(gameModel.CurrentPlayer.Color.ToString());
            ResetConsoleColor();
            Console.WriteLine(" has thrown " + gameModel.Dice + ".");
        }

        public string ChosePosibleMove(int numberOfTries)
        {
            if (numberOfTries > 0)
            {
                SetConsoleColor(Color.RED);
                Console.WriteLine("Is it realy that hard?....");
                ResetConsoleColor();
            }
            Console.WriteLine("Inset a number of the field you would like to move to:");
            return Console.ReadLine();
        }

        public void CongratulationsMessage()
        {
            SetConsoleColor(gameModel.CurrentPlayer.Color);
            Console.WriteLine("-- Congratulations player " + gameModel.CurrentPlayer.Color.ToString() + " you have won!!! --");
            ResetConsoleColor();
        }
    }
}
