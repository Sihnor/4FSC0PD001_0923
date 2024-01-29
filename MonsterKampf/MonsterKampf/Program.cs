using System;
using System.Runtime.ConstrainedExecution;

namespace MonsterKampf
{
    internal class Program
    {
        
        
        public static void Main(string[] args)
        {
            Game game = new Game();
            
            
            game.GameLoop();
        }
    }
}