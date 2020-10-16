using System;
using System.Collections.Generic;
using UnbeatableTicTacToe.Game;

namespace UnbeatableTicTacToe.GameModes.AI
{
    public static class EasyAI
    {
        public static void Start()
        {
            var playingBoard = new Board();
            var playerTurn = true;
            var playing = true;

            while (playing)
            {
                Printer.Print(playingBoard, "X");
                if (playerTurn)
                {
                    var input = Console.ReadLine();
                    playerTurn = !playingBoard.Change(input, "X");
                }
                else
                {
                    playerTurn = true;
                    var find = false;
                    while (!find)
                    {
                        find = playingBoard.Change(new string($"{GeneratePos(playingBoard)}"), "O");
                    }
                }

                playing = !(GameRules.IsWinner("X", playingBoard) || GameRules.IsWinner("O", playingBoard) || GameRules.IsDraw(playingBoard));
            }
            Printer.Print(playingBoard, "");
            Console.WriteLine($"Winner is {(GameRules.IsDraw(playingBoard) ? "No one" : !playerTurn ? "X" : "O")}");
        }

        private static string GeneratePos(Board board)
        {
            var viable = new List<string>();
            for (var i = 0; i < 3; i++)
            {
                for (var y = 0; y < 3; y++)
                {
                    if(board.SBoard[i,y] == "-")
                        viable.Add($"{i switch{0 => "A", 1 => "B", 2 => "C", _ => "D"}}{y.ToString()}");
                }
            }
            var rand = new Random().Next(0, viable.Count - 1);

            return viable[rand];
        }
    }
}