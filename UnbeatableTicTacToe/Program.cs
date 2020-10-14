using System;

namespace UnbeatableTicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Board playingBoard = new Board();
            Printer printer = new Printer();

            string inpt = "";

            bool playing = true;

            while (playing)
            {
                printer.Print(playingBoard);

                inpt = Console.ReadLine();

                playingBoard.Change(inpt);
            }
        }
    }
}