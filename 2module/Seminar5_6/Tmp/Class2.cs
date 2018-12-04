using System;

namespace Common
{
    public class Misc
    {
        /// <summary>
        /// Simple exit handler
        /// </summary>
        /// <returns>True if program should continue, false otherwise</returns>
        public static bool HandleExit()
        {
            Console.WriteLine("ESC to exit, any key to continue...");
            var key = Console.ReadKey(true).Key;
            Console.Clear();
            return key != ConsoleKey.Escape;
        }
    }
}