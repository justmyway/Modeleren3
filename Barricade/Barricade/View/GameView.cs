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
                        fields[y, x].Print();
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
            Console.WriteLine("-- Next round --");
            SetConsoleColor(gameModel.CurrentPlayer.GetColor());
            Console.Write(gameModel.CurrentPlayer.GetColor().ToString());
            ResetConsoleColor();
            Console.WriteLine(" has thrown " + gameModel.Dice + ".");
        }

        public string ChosePosibleMove(int numberOfTries, int posibilities = 0)
        {
            if (numberOfTries > 0)
            {
                SetConsoleColor(Color.RED);
                Console.WriteLine("Is it realy that hard?....");
                ResetConsoleColor();
            }
            Console.WriteLine("Inset a number of the field you would like to move to:");
            if(posibilities != 0)
                Console.WriteLine("  --> Posibilities: " + posibilities);
            Console.Out.Flush();
            return Console.ReadLine();
        }

        public void NoPosibleMove()
        {
            Console.WriteLine("Sorry there where no valid moves to make, we will now continue.");
        }

        public void CongratulationsMessage()
        {
            SetConsoleColor(gameModel.CurrentPlayer.GetColor());
            Console.WriteLine("-- Congratulations player " + gameModel.CurrentPlayer.GetColor().ToString() + " you have won!!! --");
            ResetConsoleColor();
        }
    }
}
