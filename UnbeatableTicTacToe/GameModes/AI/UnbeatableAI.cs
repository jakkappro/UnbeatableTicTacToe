using System;
using UnbeatableTicTacToe.Game;

namespace UnbeatableTicTacToe.GameModes.AI
{
    internal struct Move
    {
        public string row;
        public int column;
    }
    
    public static class UnbeatableAI
    {
        private const string player = "X";
        private const string opponent = "O";
        public static void Start()
        {
            var board = new Board();

            var playerTurn = true;

            while (true)
            {
                Printer.Print(board, playerTurn ? player : opponent);
                if (playerTurn)
                {
                    var input = Console.ReadLine();
                    playerTurn = !board.Change(input, player);
                }
                else
                {
                    board.Change(FindBestMove(board), opponent);
                    playerTurn = true;
                }

                if (GameRules.IsWinner(player, board) || GameRules.IsWinner(opponent, board) || GameRules.IsDraw(board))
                    break;
            }
            
            Printer.Print(board, "");
            Console.WriteLine($"Winner is {(GameRules.IsDraw(board) ? "No one" : playerTurn ? "computer" : "player")}");
        }

        private static string FindBestMove(Board board)
        {
            var bestMove = new Move();
            var bestValue = int.MaxValue;
            for (var i = 0; i < 3; i++)
            {
                for (var y = 0; y < 3; y++)
                {
                    if (board.SBoard[i, y] == "-")
                    {
                        board.SBoard[i, y] = opponent;
                        var moveValue = Minimax(board, true, 0);
                        board.SBoard[i, y] = "-";

                        if (bestValue > moveValue)
                        {
                            bestMove.row = i switch
                            {
                                0 => "A",
                                1 => "B",
                                2 => "C",
                                _ => "D"
                            };
                            bestMove.column = y;
                            bestValue = moveValue;
                        }
                    }
                }
            }
            return $"{bestMove.row}{bestMove.column}";
        }

        private static int EvaluateBoard(Board board)
        {
            if (GameRules.IsWinner(player, board))
                return 1;

            if (GameRules.IsWinner(opponent, board))
                return -1;

            return 0;
        }

        private static int Minimax(Board board, bool isMaximizing, int depth)
        {
            var score = EvaluateBoard(board);

            switch (score)
            {
                case 1:
                    return score;
                case -1:
                    return score;
            }

            if (GameRules.IsDraw(board))
            {
                return 0;
            }

            if (isMaximizing)
            {
                var bestScore = int.MinValue;
                for (var i = 0; i < 3; i++)
                {
                    for (var y = 0; y < 3; y++)
                    {
                        if (board.SBoard[i, y] != "-") continue;
                        board.SBoard[i, y] = player;
                        bestScore = Math.Max(bestScore, Minimax(board, false, depth + 1));
                        board.SBoard[i, y] = "-";
                    }
                }
                
                return bestScore;
            }
            
            else
            {
                var bestScore = int.MaxValue;
                for (var i = 0; i < 3; i++)
                {
                    for (var y = 0; y < 3; y++)
                    {
                        if (board.SBoard[i, y] != "-") continue;
                        board.SBoard[i, y] = opponent;
                        bestScore = Math.Min(bestScore, Minimax(board, true, depth + 1));
                        board.SBoard[i, y] = "-";
                    }
                }

                return bestScore;
            }
        }
    }
}