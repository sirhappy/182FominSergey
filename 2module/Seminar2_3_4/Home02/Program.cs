using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home02
{
    class LatinChar
    {
        private char _char;
        public char Char
        {
            get { return _char; }
            set { _char = value; }
        }

        public LatinChar(char c)
        {
            _char = c;
        }

        public LatinChar() : this('a') { }

    }

    class Program
    {
        static void Main(string[] args)
        {
            char minChar, maxChar;
            char.TryParse(Console.ReadLine(), out minChar);
            char.TryParse(Console.ReadLine(), out maxChar);
            LatinChar latinChar = new LatinChar();
            for (char i = minChar; i <= maxChar; ++i)
            {
                latinChar = new LatinChar(i);
                Console.Write(latinChar.Char + " ");
            }

            Console.ReadLine();
        }
    }
}
