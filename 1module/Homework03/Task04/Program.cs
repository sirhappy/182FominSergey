// Группа: БПИ 182-2
// Студент: Фомин Сергей
// Задача: №4 из презентации

using System;

namespace Homework03
{
    /// <summary>
    ///     Найти квадратный корень с максимальной точностью
    /// </summary>
    internal class Program
    {
        /// <summary>
        ///     Метод, считывающий вещественное число
        /// </summary>
        /// <param name="message">Строка, выводащаяся на экран перед считыванием числа</param>
        /// <returns>Число, введённое пользователем</returns>
        public static double ReadDouble(string message = "Введите вещественное число: ")
        {
            double result;
            bool isCorrect = false;
            do
            {
                Console.Write(message);

                if (double.TryParse(Console.ReadLine(), out result))
                    isCorrect = true;
                else
                    Console.WriteLine("Неверный формат числа!");
            } while (!isCorrect);

            return result;
        }

        /// <summary>
        ///     Метод, вычисляющий приближённое значение квадратного корня
        /// </summary>
        /// <param name="x">подкоренное значение</param>
        /// <param name="n">основание</param>
        /// <returns>Приближённое значение квадратного корня</returns>
        private static double ApproximateSqrt(double x, double n)
        {
            double result = 1, previousResult;
            do
            {
                previousResult = result;
                result = 1d / 2d * (result + x / result);
            } while (Math.Abs(result - previousResult) > double.Epsilon);

            return result;
        }

        private static void Main(string[] args)
        {
            do
            {
                double input = ReadDouble("Введите число, корень которого следует найти: ");
                if (input >= 0)
                    Console.WriteLine($"sqrt({input}) = {ApproximateSqrt(input, 2):F6}");
                else
                    Console.WriteLine("Корень из отрицательного числа извлечь невозможно");

                Console.WriteLine("Для завершения программы нажмите ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}