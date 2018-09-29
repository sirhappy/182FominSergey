// Группа: БПИ182-2
// Студент: Фомин Сергей
// Задача 2

using System;

namespace Task02
{
    /// <summary>
    ///     Задача: написать метод, разворачивающий число
    /// </summary>
    internal class Program
    {
        /// <summary>
        ///     Допустимые значения для ввода
        /// </summary>
        private const int MinCorrectValue = 0, MaxCorrectValue = 1000000000;

        /// <summary>
        ///     Считывает целое число
        /// </summary>
        /// <param name="message">Сообщение, выводящееся на экран перед считыванием</param>
        /// <returns>Считанное целое число</returns>
        public static int ReadInt(string message)
        {
            int result;
            bool isCorrect = false;
            do
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out result) && result >= MinCorrectValue
                                                                 && result <= MaxCorrectValue)
                    isCorrect = true;
                else
                    Console.WriteLine("Неверный формат ввода!");
            } while (!isCorrect);

            return result;
        }

        /// <summary>
        ///     Возвращает число, цифры которого записаны в обратном порядке
        /// </summary>
        /// <param name="x">Число, цифры которого надо "развернуть"</param>
        /// <returns>Перевёрнутое число</returns>
        public static int ReverseDigits(int x)
        {
            int result = 0;
            while (x > 0)
            {
                result = result * 10 + x % 10;
                x /= 10;
            }

            return result;
        }

        private static void Main(string[] args)
        {
            do
            {
                int x = ReadInt("Введите число, которое хотите развернуть: ");
                Console.WriteLine($"Число, записанное наоборот: {ReverseDigits(x)}");

                Console.WriteLine("Для завершения программы нажмите ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}