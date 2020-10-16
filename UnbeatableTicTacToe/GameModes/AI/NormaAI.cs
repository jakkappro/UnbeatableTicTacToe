using System;
using System.Collections.Generic;
using UnbeatableTicTacToe.Game;

namespace UnbeatableTicTacToe.GameModes.AI
{
    public static class NormaAI
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
                    var end = CanEnd(playingBoard);

                    if (end != "")
                    {
                        playingBoard.Change(end, "O");
                    }
                    else
                    {
                        var find = false;
                        while (!find)
                        {
                            find = playingBoard.Change(new string($"{GeneratePos(playingBoard)}"), "O");
                        }
                    }
                }

                playing = !(GameRules.IsWinner("X", playingBoard) || GameRules.IsWinner("O", playingBoard) ||
                            GameRules.IsDraw(playingBoard));
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
                    if (board.SBoard[i, y] == "-")
                        viable.Add($"{i switch {0 => "A", 1 => "B", 2 => "C", _ => "D"}}{y.ToString()}");
                }
            }

            var rand = new Random().Next(0, viable.Count - 1);

            return viable[rand];
        }

        private static string CanEnd(Board board)
        {
            //rows
            for (var i = 0; i < 3; i++)
            {
                if (board.SBoard[i, 0] == "X" && board.SBoard[i, 1] == "X" && board.SBoard[i, 2] == "-")
                    return $"{i switch{0 => "A", 1 => "B", 2 =>"C", _ =>"E"}}2";
                
                if (board.SBoard[i, 1] == "X" && board.SBoard[i, 2] == "X" && board.SBoard[i, 0] == "-")
                    return $"{i switch{0 => "A", 1 => "B", 2 =>"C", _ =>"E"}}0";
                
                if (board.SBoard[i, 0] == "X" && board.SBoard[i, 2] == "X"  && board.SBoard[i, 1] == "-")
                    return $"{i switch{0 => "A", 1 => "B", 2 =>"C", _ =>"E"}}1";
            }
            
            //columns
            for (var i = 0; i < 3; i++)
            {
                if (board.SBoard[0, i] == "X" && board.SBoard[1, i] == "X" && board.SBoard[2, i] == "-")
                    return $"C{i}";
                
                if (board.SBoard[1, i] == "X" && board.SBoard[2, i] == "X" && board.SBoard[0, i] == "-")
                    return $"A{i}";
                
                if (board.SBoard[0, i] == "X" && board.SBoard[2, i] == "X" && board.SBoard[1, i] == "-")
                    return $"B{i}";
            }
            
            //diagonals
            if (board.SBoard[0, 0] == "X" && board.SBoard[1, 1] == "X" && board.SBoard[2, 2] == "-")
                return "C2";

            if (board.SBoard[0, 0] == "X" && board.SBoard[2, 2] == "X" && board.SBoard[1, 1] == "-")
                return "B1";

            if (board.SBoard[1, 1] == "X" && board.SBoard[2, 2] == "X" && board.SBoard[0, 0] == "-")
                return "A0";
            
            if (board.SBoard[0, 2] == "X" && board.SBoard[1, 1] == "X" && board.SBoard[2, 0] == "-")
                return "C0";

            if (board.SBoard[0, 2] == "X" && board.SBoard[2, 0] == "X" && board.SBoard[1, 1] == "-")
                return "B1";

            if (board.SBoard[1, 1] == "X" && board.SBoard[2, 0] == "X" && board.SBoard[0, 2] == "-")
                return "A2";
            
            return "";
        }
    }
}
