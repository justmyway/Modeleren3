using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barricade
{
    public class Player
    {
        private Color color;

        public Player(Color color) {
            this.color = color;
        }

        public string Name() {
            return color.ToString();
        }
    }
}