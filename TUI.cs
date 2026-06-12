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

            Console.WriteLine("Write the lenght of the array: ");
            result[0] = int.Parse(Console.ReadLine());


            Console.WriteLine("Write the width of the array: ");
            result[1] = int.Parse(Console.ReadLine());

            return result;
        }


        public static void displayBoard(Board board) {
            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Cols; j++)
                {
                    if (board.getPlayerPlace(1)[0] == i && board.getPlayerPlace(1)[1] == j)
                    {
                        Console.Write("P1 ");
                    }
                    else if (board.getPlayerPlace(2)[0] == i && board.getPlayerPlace(2)[1] == j)
                    {
                        Console.Write("P2 ");
                    }
                }
                Console.WriteLine("");
            }
        }

        public static List<string> askForDirection(int avdist) {
            Console.WriteLine($"Write the number of tiles you wont to move yourself (max {avdist}):");
            string numberOfTiles = Console.ReadLine();
            Console.WriteLine($"Write the directiont of your move:\n ↑ - n \n ↓ - s \n → - e \n ← - w ");
            string direction = Console.ReadLine();
            List<string> result = new List<string> { numberOfTiles, direction};
            return result;
        }

        public static void gotNewPokemon(double power) {
            Console.WriteLine($"You just got a new pokemon!! Its power is {power}");
        }
    }
}
  