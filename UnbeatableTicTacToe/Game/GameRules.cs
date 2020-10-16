namespace UnbeatableTicTacToe.Game
{
    public static class GameRules
    {
        public static bool IsWinner(string player, Board board)
        {
            for (var i = 0; i < 3; i++)
            {
                //Check rows
                if (board.SBoard[i, 0] == player && board.SBoard[i, 1] == player && board.SBoard[i, 2] == player)
                    return true;
                
                //Check columns
                if (board.SBoard[0, i] == player && board.SBoard[1, i] == player && board.SBoard[2, i] == player)
                    return true;
            }
            
            //Check diagonals
            return (board.SBoard[0, 0] == player && board.SBoard[1, 1] == player && board.SBoard[2, 2] == player)
                   || (board.SBoard[0,2] == player && board.SBoard[1,1] == player && board.SBoard[2,0] == player);
        }

        public static bool IsDraw(Board board)
        {
            for (var i = 0; i < 3; i++)
            {
                for (var y = 0; y < 3; y++)
                {
                    if (board.SBoard[i, y] == "-")
                        return false;
                }
            }

            if (IsWinner("X", board))
                if(IsWinner("O", board))
                    return false;

            return !IsWinner("X", board) && !IsWinner("O", board);
        }
    }
}