using System;
using System.Threading;
using UnbeatableTicTacToe.GameModes;

namespace UnbeatableTicTacToe
{
    public class GameManager
    {
        public GameManager()
        {
            var running = true;

            while (running)
            {
                Console.WriteLine("Choose an option EasyAI, NormalAI, UnbeatableAI or PvP. Write Quit to quit");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "EasyAI":
                        Console.Clear();
                        var easyAI = new EasyAI();
                        break;
                    
                    case "NormalAI":
                        Console.Clear();
                        break;
                    
                    case "UnbeatableAI":
                        Console.Clear();
                        break;
                    
                    case "PvP":
                        Console.Clear();
                        PvP.Pvp();
                        break;
                    
                    case "Quit":
                        running = false;
                        break;
                    
                    default:
                        Console.WriteLine("Undetected input. This program is case sensitive.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}