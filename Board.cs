using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace pokemonGame
{
    internal class Board
    {
        private int _rows;
        private int _cols;
        private List<List<Cell>> _cells;

        private int[,] _playersPlaces;

        public Board(int rows, int cols) 
        {   
            this.Rows = rows;
            this.Cols = cols;

            _cells = new List<List<Cell>> { };

            Random random = new Random();

            for (int i = 0; i < _rows; i++) 
            {
                _cells.Add(new List<Cell> { });

                for (int j = 0; j < _cols; j++)
                { 
                    Cell cell = new Cell(i, j);

                    _cells[i].Add(cell);
                }
            }

            _playersPlaces = new int[,] { {rows, 0 }, {0, cols } };
        }



        public int[] getPlayerPlace(int playerNum) { 
            return new int[] { _playersPlaces[playerNum,0], _playersPlaces[playerNum,1] };
        }

        public void setPlayerPlace(int playerNum, int xDiff, int yDiff)
        {
            _playersPlaces[playerNum, 0] = _playersPlaces[playerNum, 0] + xDiff;
            _playersPlaces[playerNum, 1] = _playersPlaces[playerNum, 1] + yDiff;
        }


        public Cell this[int r, int c]{
            get { return _cells[r][c]; }
            set { _cells[r][c] = value; }
                
        }


        public int Rows {
            get { return _rows; }
            set {
                if (value > 0 && value <= 1000)
                {
                    _rows = value;
                }
                else 
                {
                    throw new RwrongValueException();
                }
            }
        }

        public int Cols {
            get { return _cols; }

            set {
                if (value <= 1000 && value > 0)
                {
                    _cols = value;
                } else {
                    throw new RwrongValueException();
                }
            }
        }
    }
}
