using pokemonGame;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_game
{
    internal class Game
    {
        private Board _board;
        private PokemonCollection _player1;
        private PokemonCollection _player2;

        public Game()
        {
            int[] ar = TUI.askForBoardSize();
            _board = new Board(ar[0], ar[1]);

            _player1 = new PokemonCollection();
            _player2 = new PokemonCollection();

        }

        public void movePlayers(Board board) {
            int player1AvailableDistance = DIce.rollTheDice();
            int player2availableDistance = DIce.rollTheDice();

            //List<string> p1Move = TUI.askForDirection(player1AvailableDistance);
            //List<string> p2Move = TUI.askForDirection(player2availableDistance);

            List<List<string>> pMoves = new List<List<string>>() {
                TUI.askForDirection(player1AvailableDistance, 1),
                TUI.askForDirection(player2availableDistance, 2)
            };
            for (int i = 0; i < pMoves.Count; i++)
            {
                int tiles = int.Parse(pMoves[i][0]);
                string direction = pMoves[i][1];

                int xDiff = 0;
                int yDiff = 0;

                if (direction == "n") xDiff = -tiles;
                else if (direction == "s") xDiff = tiles;
                else if (direction == "e") yDiff = tiles;
                else if (direction == "w") yDiff = -tiles;


                int newX = _board.getPlayerPlace(i)[0] + xDiff;
                int newY = _board.getPlayerPlace(i)[1] + yDiff;

                if ((newX < 0 || newX >= _board.Rows || newY < 0 || newY >= _board.Cols ) && i == 0)
                {
                    Console.WriteLine("Player 1 you cant move abroad the board.");
                    continue;
                } else if ((newX < 0 || newX >= _board.Rows || newY < 0 || newY >= _board.Cols) && i == 1)
                {
                    Console.WriteLine("Player 2 you cant move abroad the board.");
                    continue;
                }

                Console.WriteLine("");

                _board.setPlayerPlace(i, xDiff, yDiff);

                Pokemon pika = _board[_board.getPlayerPlace(i)[0], _board.getPlayerPlace(i)[1]].Pokemon;
                if (pika != null && i == 0)
                {
                    _player1.addPokemon(pika);
                    TUI.gotNewPokemon(pika.Power, 1);
                }
                else if (pika != null)
                {
                    _player2.addPokemon(pika);
                    TUI.gotNewPokemon(pika.Power, 2);
                }

                Console.WriteLine();


                pika = null;
            }

        }

        public bool checkForFight(Board board) {
            int distanceX = Math.Abs(_board.getPlayerPlace(1)[0] - _board.getPlayerPlace(0)[0]);
            int distanceY = Math.Abs(_board.getPlayerPlace(1)[1] - _board.getPlayerPlace(0)[1]);

            if (distanceX > 1 || distanceY > 1) {
                return false;
            }
            return true;
        }

        public async Task apiRequest(double numOfBytes) {
            HttpClient httpClient = new HttpClient();
            string url = $"http://127.0.0.1:5195/api/bytes/{numOfBytes}";
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Zakończono pobieranie {(int)numOfBytes} bajtów");
                }
                else
                {
                    Console.WriteLine($"Serwer zwrócił błąd: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd połączenia: {ex.Message}");
            }
        }

        public async Task fight(PokemonCollection _player1, PokemonCollection _player2) {
            if (checkForFight(_board))
            {
                int[] fighters = TUI.chooseFighters(_player1, _player2);
                List<Task> tasks = new List<Task>
                {
                    apiRequest(_player1.getPokemons()[fighters[0]].Power),
                    apiRequest(_player2.getPokemons()[fighters[1]].Power)
                };

                Task firstCompletedTask = await Task.WhenAny(tasks);
                if (firstCompletedTask == tasks[1])
                {
                    Console.WriteLine("Player's 1 pokemon won");
                    _player2.removePokemon(fighters[0]);
                }
                else if (firstCompletedTask == tasks[0])
                {
                    Console.WriteLine("Player's 2 pokemon won");
                    _player1.removePokemon(fighters[0]);
                }


            }
        }

        public void Run()
        {
            bool gameRunning = true;
            while (gameRunning)
            {
                TUI.displayBoard(_board);
                movePlayers(_board);
                if (checkForFight(_board))
                {
                    fight(_player1, _player2);
                }
            }
        }

    }
}
