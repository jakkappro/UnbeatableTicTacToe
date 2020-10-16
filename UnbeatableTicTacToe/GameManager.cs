using System;
using System.Threading;
using UnbeatableTicTacToe.GameModes;
using UnbeatableTicTacToe.GameModes.AI;

namespace UnbeatableTicTacToe
{
    public class GameManager
    {

        public GameManager()
        {
            var running = true;
            Console.WriteLine("Hello, welcome in Tic Tac Toe. Choose your game mode pleas.");
            while(running)
            {
                Console.WriteLine("Game modes are PvP, EasyAI, NormalAI, UnbeatableAI. For quit write Quit.");
                var input = Console.ReadLine();
                
                switch (input)
                {
                    case "EasyAI":
                        Console.Clear();
                        EasyAI.Start();
                        break;
                    
                    case "NormalAI":
                        Console.Clear();
                        NormaAI.Start();
                        break;
                    
                    case "UnbeatableAI":
                        Console.Clear();
                        UnbeatableAI.Start();
                        break;
                    
                    case "PvP":
                        Console.Clear();
                        PvP.Start();
                        break;
                    
                    case "Quit":
                        running = false;
                        break;
                    
                    default:
                        Console.WriteLine("Invalid input. This program is case sensitive.");
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                }
            }
        }
        
    }
}