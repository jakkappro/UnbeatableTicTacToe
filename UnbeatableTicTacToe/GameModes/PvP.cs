using System;
using UnbeatableTicTacToe.Game;

namespace UnbeatableTicTacToe.GameModes
{
    public static class PvP
    {
        public static void Start()
        {
            var xTurn = true;
            var playingBoard = new Board();

            string winner;

            while (true)
            {
                Printer.Print(playingBoard, xTurn ? "X":"O");
                
                winner = GameRules.IsWinner("X", playingBoard) ? "X" :
                    GameRules.IsWinner("O", playingBoard) ? "O" :
                    GameRules.IsDraw(playingBoard) ? "No one" : "";
                
                if (winner != "")
                    break;
                
                var input = Console.ReadLine();

                xTurn = playingBoard.Change(input, xTurn ? "X" : "O") ? !xTurn : xTurn;
            }

            Console.WriteLine($"Winner is {winner}.");
        }   
    }
}