// Группа: БПИ 182-2
// Студент: Фомин Сергей
// Задача 1

using System;

namespace Task01
{
    /// <summary>
    ///     Задача: написать метод, находящий число, являющееся
    ///     суммой арифметической прогрессии и цифры которого одинаковы
    /// </summary>
    internal class Program
    {
        /// <summary>
        ///     Метод, находящий число, являющееся суммой
        ///     арифметической прогрессии и цифры которого одинаковы
        /// </summary>
        /// <param name="result">Найденное число</param>
        /// <param name="numberOfMembers">Количество членов арифметической прогрессии</param>
        public static void FindNumber(out int result, out int numberOfMembers)
        {
            int sum = 0, k;
            for (k = 0; !(AreDigitsTheSame(sum) && sum >= 100); sum += ++k) ;
            result = sum;
            numberOfMembers = k;
        }

        /// <summary>
        ///     Являются ли все цифры в числе одинаковыми?
        /// </summary>
        /// <param name="number">Число, которые мы хотим проверить</param>
        /// <returns>Собсна все ли цифры равны</returns>
        public static bool AreDigitsTheSame(int number)
        {
            int digit = number % 10;
            number /= 10;
            while (number > 0)
            {
                if (number % 10 != digit) return false;
                number /= 10;
            }

            return true;
        }

        private static void Main(string[] args)
        {
            do
            {
                FindNumber(out int result, out int k);
                Console.WriteLine($"Полученное число: {result}");
                Console.WriteLine($"Количество членов ряда: {k}");
                Console.WriteLine($"1 + 2 + 3 + ... + {k - 2} + {k - 1} + {k}");

                Console.WriteLine("Для завершения программы нажмите ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}