using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    public class Parser
    {
        public static long ReadLong(long minValue = long.MinValue, long maxValue = long.MaxValue, string errorMessage = "Неверный формат ввода!")
        {
            long result;
            while (!(long.TryParse(Console.ReadLine(), out result) && result >= minValue && result <= maxValue))
                Console.WriteLine(errorMessage);
            return result;
        }
    }
}
