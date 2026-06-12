using Pokemon_game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemonGame
{
    internal class Cell
    {
        private int _x;
        private int _y;

        //If there is no pokemon on this field this value will be set to 0
        private Pokemon _pokemon;


        private bool _potion;


        public Cell(int x, int y) 
        {
            this.X = x;
            this.Y = y;
            _pokemon = new Pokemon();
            if (_pokemon.Power % 10 == 0)
            {
                this.Potion = true;
                this._pokemon = null;
            }
        }

        public Pokemon Pokemon { 
            get { return _pokemon; } 
            set { _pokemon = value; }
        }

        public int X {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public bool Potion { 
            get { return _potion; }
            set { _potion = value; }
        }


    }
}
