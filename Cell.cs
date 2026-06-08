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
        private double _pokemonPower;


        private bool _potion;


        public Cell(int x, int y) 
        {
            Random random = new Random();
            this.X = x;
            this.Y = y;
            int power = random.Next(1, 10000);
            if (power % 10 == 0)
            {
                this.Potion = true;
                this.PokemonPower = 0;
            }
            else 
            { 
                this.Potion = false;
                this.PokemonPower = power;
            }
            
        }

        public int X {
            get { return _x; }
            set { _x = value; }
        }

        public int Y {
            get { return _y;  }
            set { _y = value; }
        }

        public double PokemonPower {
            get { return _pokemonPower; }
            set { _pokemonPower = value; }
        }

        public bool Potion { 
            get { return _potion; }
            set { _potion = value; }
        }


    }
}
