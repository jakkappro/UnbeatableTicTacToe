using System;

namespace UnbeatableTicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var playingBoard = new Board();

            string winner;

            while (true)
            {
                Printer.Print(playingBoard);
                
                winner = GameRules.IsWinner("X", playingBoard) ? "X" : GameRules.IsWinner("Y", playingBoard) ? "Y" : "";
                
                if (winner != "")
                    break;
                
                var inpt = Console.ReadLine();

                playingBoard.Change(inpt);
            }

            Console.WriteLine($"Winner is {winner}.");
        }
    }
}