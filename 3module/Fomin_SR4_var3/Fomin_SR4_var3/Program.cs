using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fomin_SR4_var3
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey consoleKey = ConsoleKey.A;
            do
            {
                int a = 0, b = 0;
                bool f = false;
                try
                {
                    Console.Write("Введите A: ");
                    a = int.Parse(Console.ReadLine());
                    if (a > 1000 || a < -1000) throw new ArgumentOutOfRangeException();

                    Console.Write("Введите B: ");
                    b = int.Parse(Console.ReadLine());
                    if (b > 1000 || b < -1000) throw new ArgumentOutOfRangeException();
                    f = true;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Неверный формат ввода!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный формат ввода!");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Координаты должны быть от -1000 до 1000!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Неверный формат ввода!");
                }
                if (!f) continue;
                Square square;
                Square.OnCoordinateChanged += PrintInfo;

                square = new Square(new Coordinate(a, b));
                square = new Square(new Coordinate(a * a, b * b));

                Console.WriteLine("Нажмите ESC для выхода");
                consoleKey = Console.ReadKey(true).Key;
            } while (consoleKey != ConsoleKey.Escape);
        }

        public static void PrintInfo(object sender, SquareEventArgs e)
        {
            Square s = sender as Square;
            Coordinate c = s.Coordinates;
            Console.WriteLine($"Координаты изменились. Новые координаты: ({c.A}, {c.B}); ({e.End.A}, {e.End.B})!");
        }
    }

    class Square
    {
        public Square(Coordinate coordinate)
        {
            Coordinates = coordinate;
        }

        public const int Side = 10;

        public delegate void CoordinateChanged(object sender, SquareEventArgs e);
        public static event CoordinateChanged OnCoordinateChanged;

        private Coordinate coordinate;

        public Coordinate Coordinates
        {
            get => coordinate;
            set
            {
                coordinate = value;
                OnCoordinateChanged?.Invoke(this, new SquareEventArgs(new Coordinate(Coordinates.A + Side, Coordinates.B + Side)));
            }
        }
    }

    class SquareEventArgs : EventArgs
    {
        public SquareEventArgs(Coordinate end)
        {
            End = end;
        }
        public Coordinate End { get; set; }
    }

    class Coordinate
    {
        public int A { get; set; }

        public int B { get; set; }

        public Coordinate(int a, int b)
        {
            A = a;
            B = b;
        }

        public Coordinate()
        {
            A = 0;
            B = 0;
        }
    }
}
