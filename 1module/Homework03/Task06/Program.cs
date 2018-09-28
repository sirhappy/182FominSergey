// Группа: БПИ182-2
// Студент: Фомин Сергей
// Задача 6

using System;
using System.Text;

namespace Task06
{
    /// <summary>
    ///     Задача: Написать метод для расчёта сложных процентов
    /// </summary>
    internal class Program
    {
        /// <summary>
        ///     Возвращает верное введённое вещественное число
        /// </summary>
        /// <param name="message">Строка, выводящаяся перед считыванием</param>
        /// <returns>Введённое число</returns>
        public static double ReadDouble(string message = "Введите вещественное число: ")
        {
            double result;
            bool isCorrect = false;

            do
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out result) && result > 0)
                    isCorrect = true;
                else
                    Console.WriteLine("Введено неверное значение!");
            } while (!isCorrect);

            return result;
        }

        /// <summary>
        ///     Возвращает введённое неотрицательное целое число
        /// </summary>
        /// <param name="message">Строка, выводящаяся перед считыванием</param>
        /// <returns>Введённое число</returns>
        public static uint ReadUInt(string message = "Введите неотрицательное целое число: ")
        {
            uint result;
            bool isCorrect = false;

            do
            {
                Console.Write(message);
                if (uint.TryParse(Console.ReadLine(), out result))
                    isCorrect = true;
                else
                    Console.WriteLine("Введено неверное значение!");
            } while (!isCorrect);

            return result;
        }

        /// <summary>
        ///     Метод для рассчёта сложных капиталов
        /// </summary>
        /// <param name="k">начальный капитал</param>
        /// <param name="r">годовая процентная ставка</param>
        /// <param name="n">число лет вклада</param>
        /// <returns>итоговая сумма в конце срока вклада</returns>
        public static double Total(double k, double r, uint n)
        {
            double result = k;
            for (uint year = 0; year < n; ++year) result *= (100 + r) / 100;
            return result;
        }

        public static void Main(string[] args)
        {
            do
            {
                Console.OutputEncoding = Encoding.Unicode;
                double k = ReadDouble("Введите начальный капитал: ");
                double r = ReadDouble("Введите годовую процентную ставку: ");
                uint n = ReadUInt("Введите число лет: ");
                for (uint year = 1; year <= n; ++year)
                    Console.WriteLine($"В конце {year} года на счету будет {Total(k, r, year):C}");

                Console.WriteLine("Нажмите Escape для выхода из программы");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}