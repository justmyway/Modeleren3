﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Barricade
{
    public class GameController
    {
        List<Player> players;
        private Player currentPlayer;
        private int dice;

        public GameController() {
            players = new List<Player>();

            //create Players
            foreach (Color color in Enum.GetValues(typeof(Color)))
            {
                if(color == Color.NONE)
                    continue;
                
                Player player = new Player(color);
                players.Add(player);
            }

            CreateField();
        }

        public void CreateField()
        {

        }

        public void Play()
        {
            //show map

            //throw dice

            //read input

            //calculate moves

            //player make chose

            //move pawn


            NextPlayer();
        }

        private void NextPlayer()
        {
            currentPlayer = players.Count >= players.IndexOf(currentPlayer) + 1 ? players.First() : players[players.IndexOf(currentPlayer) + 1];
        }
    }
}