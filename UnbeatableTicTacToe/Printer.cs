using System;

namespace UnbeatableTicTacToe
{
    public class Printer
    {
        public static void Print(Board print)
        {
            Console.Clear();
            //Write Top Row
            Console.WriteLine("  A B C");
            
            //Write all other rows from print
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i + 1} {print.SBoard[i, 0]} {print.SBoard[i, 1]} {print.SBoard[i, 2]}");
            }
            
            //Write turn
            Console.WriteLine($"Choose position of {(print.XTurn ? "X" : "0")}.");
        }
    }
}
//TODO: find better name for print