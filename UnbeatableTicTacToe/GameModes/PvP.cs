using System;
using UnbeatableTicTacToe.Game;

namespace UnbeatableTicTacToe.GameModes
{
    public static class PvP
    {
        public static void Pvp()
        {
            bool xTurn = true;
            var playingBoard = new Board();

            string winner;

            while (true)
            {
                Printer.Print(playingBoard, xTurn ? "X" : "O");
                
                winner = GameRules.IsWinner("X", playingBoard) ? "X" : GameRules.IsWinner("O", playingBoard) ? "O" : "";
                
                if (winner != "")
                    break;
                
                var inpt = Console.ReadLine();

                xTurn =  playingBoard.Change(inpt, xTurn ? "X" : "O") ? !xTurn : xTurn;
            }

            Console.WriteLine($"Winner is {winner}.");
        }
    }
}