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
            ConsoleKey consoleKey = ConsoleKey.NoName;
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

        /// <summary>
        ///     Выводит информацию о квадрате
        /// </summary>
        /// <param name="sender">Square</param>
        /// <param name="e">SquareEventArgs</param>
        public static void PrintInfo(object sender, SquareEventArgs e)
        {
            Square s = sender as Square;
            Coordinate c = s.Coordinates;
            Console.WriteLine($"Координаты изменились. Новые координаты: ({c.A}, {c.B}); ({e.End.A}, {e.End.B})!");
        }
    }

    class Square
    {
        /// <summary>
        ///     Конструктор для создания квадрата
        /// </summary>
        /// <param name="coordinate">Координата левой нижней точки</param>
        public Square(Coordinate coordinate)
        {
            Coordinates = coordinate;
        }

        /// <summary>
        ///     Сторона квадрата
        /// </summary>
        public const int Side = 10;

        /// <summary>
        ///     Стандартный шаблон для события изменения координаты
        /// </summary>
        /// <param name="sender">Square</param>
        /// <param name="e">SquareEventArgs с конечной точкой</param>
        public delegate void CoordinateChanged(object sender, SquareEventArgs e);
        /// <summary>
        ///     Событие изменения координаты
        /// </summary>
        public static event CoordinateChanged OnCoordinateChanged;

        /// <summary>
        ///     Координата
        /// </summary>
        private Coordinate coordinate;

        /// <summary>
        ///     Свойство для координаты
        /// </summary>
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

    /// <summary>
    ///     Класс SquareEventArgs для передачи конечной точки
    /// </summary>
    class SquareEventArgs : EventArgs
    {
        /// <summary>
        ///     Конструктор, принимающий конечную точку
        /// </summary>
        /// <param name="end"></param>
        public SquareEventArgs(Coordinate end)
        {
            End = end;
        }
        /// <summary>
        ///     Конечная точка
        /// </summary>
        public Coordinate End { get; set; }
    }

    /// <summary>
    ///     Класс Coordinate для удобного хранения точек
    /// </summary>
    class Coordinate
    {
        /// <summary>
        ///     Первая координата
        /// </summary>
        public int A { get; set; }

        /// <summary>
        ///     Вторая координата
        /// </summary>        
        public int B { get; set; }

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="a">первая координата</param>
        /// <param name="b">вторая координата</param>
        public Coordinate(int a, int b)
        {
            A = a;
            B = b;
        }

        /// <summary>
        ///     Конструктор без параметров
        ///     A = 0, B = 0
        /// </summary>
        public Coordinate()
        {
            A = 0;
            B = 0;
        }
    }
}
