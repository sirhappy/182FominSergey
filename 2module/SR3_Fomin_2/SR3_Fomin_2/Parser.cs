/**
 * Программирование, Фомин Сергей
**/
using System;

namespace SR3_Fomin_2
{
    class Parser
    {
        public static int ReadInt(int minValue, int maxValue, string showMessage, string errorMessage = "Неверный формат ввода")
        {
            int result = 0;
            bool isCorrect = false;
            do
            {
                Console.Write(showMessage);
                if (int.TryParse(Console.ReadLine(), out result) && minValue <= result && result <= maxValue)
                    isCorrect = true;
                else
                    Console.WriteLine(errorMessage);
            } while (!isCorrect);
            return result;
        }

        public static uint ReadUInt(uint minValue, uint maxValue, string showMessage, string errorMessage = "Неверный формат ввода")
        {
            uint result = 0;
            bool isCorrect = false;
            do
            {
                Console.Write(showMessage);
                if (uint.TryParse(Console.ReadLine(), out result) && minValue <= result && result <= maxValue)
                    isCorrect = true;
                else
                    Console.WriteLine(errorMessage);
            } while (!isCorrect);
            return result;
        }

        public static double ReadDouble(double minValue, double maxValue, string showMessage, string errorMessage = "Неверный формат ввода")
        {
            double result = 0;
            bool isCorrect = false;
            do
            {
                Console.Write(showMessage);
                if (double.TryParse(Console.ReadLine(), out result) && minValue <= result && result <= maxValue)
                    isCorrect = true;
                else
                    Console.WriteLine(errorMessage);
            } while (!isCorrect);
            return result;
        }
    }
}
