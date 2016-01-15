using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barricade.View
{
    public class GameView
    {
        FieldView[,] fields;
        char[,] horizontalConnections;
        char[,] verticalConnections;

        public GameView()
        {
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
                    Console.Write(fields[x, y].Value);
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
    }
}
