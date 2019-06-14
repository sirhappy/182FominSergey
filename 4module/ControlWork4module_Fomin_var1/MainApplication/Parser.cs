using System;

namespace MainApplication
{
    /// <summary>
    ///     Класс, содержащий функции для парсинга чисел
    /// </summary>
    public class Parser
    {
        public static int ReadInt(int minValue, int maxValue, string errorMessage = "Неверный формат ввода")
        {
            int result;
            while (!(int.TryParse(Console.ReadLine(), out result) && result >= minValue && result <= maxValue))
                Console.WriteLine("Неверный формат ввода!");
            return result;
        }

    }
}
