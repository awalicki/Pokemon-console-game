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

            Console.WriteLine("Podaj długość tablicy: ");
            result[0] = int.Parse(Console.ReadLine());


            Console.WriteLine("Podaj szerokość tablicy: ");
            result[1] = int.Parse(Console.ReadLine());

            return result;
        }


        public static void displayBoard(Board board) { 
            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Cols; j++)
                {
                    Console.Write("[] ");
                }
                Console.WriteLine("");
            }
        }
    }
}
