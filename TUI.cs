using pokemonGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_game
{
    internal class TUI
    {
        public static int[] askForBoardSize() {
            int[] result = new int[2];

            Console.WriteLine("Lenght of the board: ");
            result[0] = int.Parse(Console.ReadLine());


            Console.WriteLine("Width of the board: ");
            result[1] = int.Parse(Console.ReadLine());

            return result;
        }


        public static void displayBoard(Board board) {
            Console.WriteLine("");
            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Cols; j++)
                {
                    if (board.getPlayerPlace(0)[0] == i && board.getPlayerPlace(0)[1] == j && board.getPlayerPlace(1)[0] == i && board.getPlayerPlace(1)[1] == j)
                    {
                        Console.Write("BTH");
                    }
                    else if (board.getPlayerPlace(0)[0] == i && board.getPlayerPlace(0)[1] == j)
                    {
                        Console.Write("P1 ");
                    }
                    else if (board.getPlayerPlace(1)[0] == i && board.getPlayerPlace(1)[1] == j)
                    {
                        Console.Write("P2 ");
                    }
                    else {
                        Console.Write("[ ]");
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("\n\n");
        }

        public static List<string> askForDirection(int avdist, int player) {
            string numberOfTiles;
            List<char> availableDirections = new List<char> {'n', 's', 'e', 'w' };
            string direction;
            do
            {
                Console.WriteLine($"Player {player}: Write the number of tiles you wont to move (max {avdist}):");
                numberOfTiles = Console.ReadLine();
            } while (int.Parse( numberOfTiles) < 0 && int.Parse(numberOfTiles) > avdist);
            do
            {
                Console.WriteLine($"Player {player}: Write the directiont of your move:\n ↑ - n \n ↓ - s \n → - e \n ← - w \n\n");
                direction = Console.ReadLine();
            } while (!(availableDirections.Contains(char.Parse(direction))));
            List<string> result = new List<string> { numberOfTiles, direction};
            return result;
        }

        public static void gotNewPokemon(double power, int player) {
            Console.WriteLine($"Player {player}: You just got a new pokemon!! It's power is {power}");
        }

        public static void showPlayerCollection(PokemonCollection pc) {
            Console.Write($"You have {pc.getPokemons().Count} : ");

            for (int i = 0; i < pc.getPokemons().Count; i++)
            {
                Console.Write($"{i + 1} - {pc[i].Power}, ");
            }
            Console.WriteLine($"\n And {pc.Upgrades} upgrades.\n\n");
        }

        public static int[] chooseFighters(PokemonCollection p1, PokemonCollection p2)
        {
            int[] result = new int[2];
            showPlayerCollection(p1);
            Console.WriteLine("Player 1, choose the number of pokemon for the fight");
            int pom = int.Parse(Console.ReadLine());
            if (pom <= p1.getPokemons().Count && pom > 0) {
                result[0] = pom - 1;
            }
            Console.WriteLine($"Player 1 chose pokemon number: {pom}.\n");


            showPlayerCollection(p2);
            Console.WriteLine("Player 2,  choose the number of pokemon for the fight");
            pom = int.Parse(Console.ReadLine());
            if (pom <= p2.getPokemons().Count && pom > 0)
            {
                result[1] = pom - 1;
            }
            Console.WriteLine($"Player 2 chose pokemon number {pom}.\n");

            return result;
        }
    }
}
  