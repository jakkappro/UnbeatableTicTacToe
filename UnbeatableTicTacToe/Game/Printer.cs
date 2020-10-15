using System;

namespace UnbeatableTicTacToe.Game
{
    public static class Printer
    {
        public static void Print(Board print, string turn)
        {
            Console.Clear();
            
            //Write Top Row
            Console.WriteLine("  0 1 2");
            
            //Write all other rows from print
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i switch { 0 => "A", 1 => "B", 2 => "C" }} {print._board[i, 0]} {print._board[i, 1]} {print._board[i, 2]}");
            }
            
            //Write turn
            Console.WriteLine($"Choose position of {turn}.");
        }
    }
}
//TODO: find better name for print