using System;

namespace UnbeatableTicTacToe
{
    public class Printer
    {
        public void Print(Board print)
        {
            Console.Clear();
            
            Console.WriteLine("  A B C");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i + 1}{print.SBoard[i, 0]} {print.SBoard[i, 1]} {print.SBoard[i, 2]}");
            }
            
            Console.WriteLine("Choose position of X.");
        }
    }
}