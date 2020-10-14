using System;

namespace UnbeatableTicTacToe
{
    public class Board
    {
        private bool turn = true; //True means X turn, false means O turn
        
        private string[, ] board = new string[3, 3];

        public string[,] SBoard
        {
            get
            {
                return board;
            }
            
        }

        public void Change(string pos)
        {
            switch (pos)
            {
                case "A0":
                    board[0, 0] = "X";
                    break;

                case "A1":
                    board[0, 1] = "X";
                    break;

                case "A2":
                    board[0, 2] = "X";
                    break;
                
                case "B0":
                    board[1, 0] = "X";
                    break;

                case "B1":
                    board[1, 1] = "X";
                    break;

                case "B2":
                    board[1, 2] = "X";
                    break;
                
                case "C0":
                    board[2, 0] = "X";
                    break;

                case "C1":
                    board[2, 1] = "X";
                    break;

                case "C2":
                    board[2, 2] = "X";
                    break;
                
                default:
                    Console.WriteLine("Invalid input. Pleas insert input in A0 - C2, with upper case letters");
                    break;
            }
        }
    }
}