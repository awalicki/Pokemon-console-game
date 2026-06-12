using pokemonGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_game
{
    internal class Game
    {
        private Board _board;
        private PokemonCollection _player1;
        private PokemonCollection _player2;

        public Game ()
        {
            int[] ar = TUI.askForBoardSize();
            _board = new Board(ar[1], ar[2]);

            _player1 = new PokemonCollection();
            _player2 = new PokemonCollection();

        }

        public void movePlayers(Board board) {
            int player1AvailableDistance = DIce.rollTheDice();
            int player2availableDistance = DIce.rollTheDice();

            //List<string> p1Move = TUI.askForDirection(player1AvailableDistance);
            //List<string> p2Move = TUI.askForDirection(player2availableDistance);

            List<List<string>> pMoves = new List<List<string>>() { 
                TUI.askForDirection(player1AvailableDistance),
                TUI.askForDirection(player2availableDistance)
            };

            for (int i = 0; i < pMoves.Count; i++)
            {
                if (pMoves[i][1] == "n")
                    _board.setPlayerPlace(0, 0, int.Parse(pMoves[i][0]));

                if (pMoves[i][1] == "s")
                    _board.setPlayerPlace(0, 0, (int.Parse(pMoves[i][0]) * -1));

                if (pMoves[i][1] == "e")
                    _board.setPlayerPlace(0, int.Parse(pMoves[i][0]), 0);

                if (pMoves[i][1] == "w")
                    _board.setPlayerPlace(0, (int.Parse(pMoves[i][0]) * -1), 0);

                _player1.addPokemon( _board[ _board.getPlayerPlace(i)[0], _board.getPlayerPlace(i)[1]].Pokemon);
            }



        }


    }
}
