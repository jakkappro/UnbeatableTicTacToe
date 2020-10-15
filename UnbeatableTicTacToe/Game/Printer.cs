using System;

namespace UnbeatableTicTacToe
{
    public class Printer
    {
        public static void Print(Board print)
        {
            Console.Clear();
            
            //Write Top Row
            Console.WriteLine("  0 1 2");
            
            //Write all other rows from print
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i switch { 0 => "A", 1 => "B", 2 => "C" }} {print.SBoard[i, 0]} {print.SBoard[i, 1]} {print.SBoard[i, 2]}");
            }
            
            //Write turn
            Console.WriteLine($"Choose position of {(print.XTurn ? "X" : "0")}.");
        }
    }
}
//TODO: find better name for print