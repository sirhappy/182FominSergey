using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork2019.Utilities
{
    public class RandomClass
    {
        public static Random Rnd { get; set; } = new Random();

        public static int RandomInt(int from, int to)
        {
            return Rnd.Next(from, to);
        }
    }
}
