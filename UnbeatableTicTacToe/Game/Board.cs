using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace UnbeatableTicTacToe.Game
{
    public class Board
    {
        public string[,] SBoard { get; set; } = new[, ] {{"-", "-", "-"}, {"-", "-", "-"}, {"-", "-", "-"}};

        public bool Change(string pos, string who)
        {
            var iRow = 0;
            var iCollum = 0;
            
            //Validate input
            var upper = pos.ToUpper().ToCharArray();
            if (upper.Length > 2)
            {
                Console.WriteLine("Too long input.");
                Thread.Sleep(1000);
                return false;
            }

            if (upper[0] < 'A' || upper[0] > 'C')
            {
                Console.WriteLine("Pleas input character between A - C.");
                Thread.Sleep(1000);
                return false;
            }

            if (upper[1] < '0' || upper[1] > '2')
            {
                Console.WriteLine("Pleas input number between 0 - 2");
                Thread.Sleep(1000);
                return false;
            }

            //Determinate first index
            iRow = upper[0] switch
            {
                'A' => 0,
                'B' => 1,
                'C' => 2,
                _ => iRow
            };

            //Determinate second index
            iCollum = upper[1] switch
            {
                '0' => 0,
                '1' => 1,
                '2' => 2,
                _   => iCollum
            };
            
            //Check if space is occupied
            if (SBoard[iRow, iCollum] != "-")
            {
                Console.WriteLine("This space is occupied.");
                Thread.Sleep(1000);
                return false;
            }

            //Change string
            SBoard[iRow, iCollum] = who;
            return true;
        }
    }
}