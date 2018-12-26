using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest
{
    static class Parser
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
    }
}
