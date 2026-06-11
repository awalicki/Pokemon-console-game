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

            _player1 = new PokemonCollection(new int[] { ar[1], 0 });
            _player2 = new PokemonCollection(new int[] { 0, ar[2] });

        }

        public void movePlayers(Board board) {
            int player1AvailableDistance = DIce.rollTheDice();
            int player2availableDistance = DIce.rollTheDice();


            
        }

        
    }
}
