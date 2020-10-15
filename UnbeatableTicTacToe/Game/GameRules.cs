namespace UnbeatableTicTacToe.Game
{
    public static class GameRules
    {
        public static bool IsWinner(string player, Board board)
        {
            for (var i = 0; i < 3; i++)
            {
                //Check rows
                if (board._board[i, 0] == player && board._board[i, 1] == player && board._board[i, 2] == player)
                    return true;
                
                //Check columns
                if (board._board[0, i] == player && board._board[1, i] == player && board._board[2, i] == player)
                    return true;
            }

            //Check diagonals
            return (board._board[0, 0] == player && board._board[1, 1] == player && board._board[2, 2] == player)
                   || (board._board[0,2] == player && board._board[1,1] == player && board._board[2,0] == player);
        }
    }
}