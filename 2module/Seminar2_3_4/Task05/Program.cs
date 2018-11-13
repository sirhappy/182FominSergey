using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
    public class ConsolePlate
    {
        char _plateChar; // символ

        public ConsoleColor PlateColorForeground { get; set; }
        public ConsoleColor PlateColorBackground { get; set; }

        public char PlateChar
        {
            get { return _plateChar; }
            set
            {
                if (value < 'A' || value > 'Z') _plateChar = 'A';
                else
                    _plateChar = value;    
            }
        }
        
        public ConsolePlate()
        {
            _plateChar = 'A';
            PlateColorBackground = ConsoleColor.Black;
            PlateColorForeground = ConsoleColor.Gray;
        }

        public ConsolePlate(char c, ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            PlateChar = c;
            PlateColorBackground = backgroundColor;
            PlateColorForeground = foregroundColor;
        }
    }

    class Program
    {
        public static Random rnd = new Random();

        public static ConsoleColor[] colors =
        {
            ConsoleColor.Red, ConsoleColor.Blue, ConsoleColor.Yellow,
            ConsoleColor.Magenta, ConsoleColor.Green, ConsoleColor.Gray
        };

        static void Main(string[] args)
        {
            ConsolePlate x = new ConsolePlate('X', ConsoleColor.Red, ConsoleColor.White);
            ConsolePlate o = new ConsolePlate('O', ConsoleColor.Magenta, ConsoleColor.White);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; ++i, Console.WriteLine())
                for (int j = 0; j < n; ++j)
                {
                    ConsolePlate t = (i + j) % 2 == 0 ? x : o;
                    Console.BackgroundColor = t.PlateColorBackground;
                    Console.ForegroundColor = t.PlateColorForeground;
                    Console.Write(t.PlateChar);
                }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ReadLine();
        }
    }
}
