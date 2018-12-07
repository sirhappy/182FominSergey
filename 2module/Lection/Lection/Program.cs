using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = " Hello, World!";
            Console.WriteLine(s.Length);
            string t = "London is the capital of GB";
            string q = String.Concat(s, " ", t);
            Console.WriteLine(q);
            Console.WriteLine(s.Contains("Hello"));

            char[] determiners = { ' ', ',' , '!'};
            string[] arr = s.Split(determiners, StringSplitOptions.RemoveEmptyEntries);


            foreach (string i in arr)
                Console.WriteLine(i.Length + " " + i);
            Console.WriteLine(q.ToUpper());
            Console.WriteLine(q);
            Console.WriteLine(s.CompareTo(q));
            Console.WriteLine(s.CompareTo(s));
            Console.WriteLine(q.CompareTo(s));

            string w = new string('W', 7);
            char[] car = { 'C', 'a', 'r' };
            string c = new string(car);

            Console.WriteLine(w);
            Console.WriteLine(c);

            string a = "mess";
            string b = "mess";

            Console.WriteLine(a == b);

            s = "The {0, -4:D} quick {1} brown fox jumps over the lazy dog {2}";
            Console.WriteLine(s);
            s = string.Format(s, 1, "furry", "wolf");
            Console.WriteLine(s);

            int x = 256;
            Console.WriteLine(x.ToString("X3"));

            string sw = "One";

            switch (sw)
            {
                case "One": Console.WriteLine(1); break;
                case "Two": Console.WriteLine(2); break;
                default: Console.WriteLine("NA"); break;
            }

            int[] nums = { 1, 2, 3, 4, 5 };

            string numsPrint = string.Join(" ", nums);

            Console.WriteLine(numsPrint);

            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(double.MaxValue * double.MaxValue);

            string row = "0123456789";
            char[] rowChar = row.ToCharArray();
            rowChar[2] = '9';
            row = new string(rowChar);
            Console.WriteLine(row);

            char u = '\u0479';
            Console.WriteLine(u);
        //    u = '\uE282AC';
            Console.WriteLine();

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
