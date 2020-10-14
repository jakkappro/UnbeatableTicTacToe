using System;

namespace UnbeatableTicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var playingBoard = new Board();

            var playing = true;

            while (playing)
            {
                Printer.Print(playingBoard);

                var inpt = Console.ReadLine();

                playingBoard.Change(inpt);
            }
        }
    }
}