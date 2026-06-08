using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_game
{
    internal class Move
    {
        private int _maxTiles;
        private int _tiles;
        private char _dimension;

        public int MaxTiles {
            get { return _maxTiles; }
            set { _maxTiles = value; }
        }

        public int Tiles {
            get { return _tiles; }
            set { _tiles = value; }
        }

        public char Dimension { 
            get { return _dimension; }
            set { 
                char[] possibleValues = new char[] { 'n', 's', 'e', 'w' };
                if (possibleValues.Contains(value)) { 
                    _dimension = value;
                }
            }
        }
    }
}
