/*
 * Группа: БПИ182-2
 * Студент: Фомин Сергей Дмитриевич
 * Дата: 25.09.2018
 * Вариант: - 
 * Задача: !(p & q) & !(p | !q)
*/

using System;

namespace Task02
{
    class Program
    {
        public static int Function(int p, int q)
        {
            bool p2 = p == 1;
            bool q2 = q == 1;
            int ans = !(p2 & q2) & !(p2 | !q2) ? 1 : 0;
            return ans;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("p q F");
            for (int p = 0; p <= 1; ++p)
                for (int q = 0; q <= 1; ++q)
                    Console.WriteLine($"{p} {q} {Function(p, q)}");
        }
    }
}
