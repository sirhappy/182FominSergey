/**
 *  Фомин Сергей
 *  БПИ182
 *  Вариант 2
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fomin_SR7_var2
{
    class LucasCollection : IEnumerable<int>
    {
        /// <summary>
        ///     Закрытый класс для итератора
        /// </summary>
        private class LucasCollectionEnumerator : IEnumerable<int>
        {
            private int _count;

            public LucasCollectionEnumerator(int count)
            {
                _count = count;
            }

            /// <summary>
            ///     Получить итератор
            /// </summary>
            /// <returns>итератор</returns>
            public IEnumerator<int> GetEnumerator()
            {
                List<int> a = new List<int>() { 2, 1 };
                for (int i = 0; i < _count; ++i)
                {
                    if (a.Count() == i) a.Add(a[a.Count() - 1] + a[a.Count() - 2]);
                    yield return a[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        private int _count;

        public LucasCollection(int count)
        {
            _count = count;
        }

        /// <summary>
        ///     Возращает итератор из закрытого класса
        /// </summary>
        /// <returns>итератор</returns>
        public IEnumerator<int> GetEnumerator()
        {
            return new LucasCollectionEnumerator(_count).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
    {
        /// <summary>
        ///     Минимальное N
        /// </summary>
        private const int MinCount = 1;
        /// <summary>
        ///     Максимальное N (иначе переполняется вывод)
        /// </summary>
        private const int MaxCount = 45;

        static void Main(string[] args)
        {
            do
            {
                int n;
                Console.Write($"Введите n (от {MinCount} до {MaxCount}): ");
                while (!(int.TryParse(Console.ReadLine(), out n) && (n >= MinCount) && (n <= MaxCount)))
                    Console.WriteLine("Неверный формат ввода!");

                LucasCollection lucasCollection = new LucasCollection(n);
                foreach (var i in lucasCollection)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();

                Console.WriteLine("Нажмите ESC для выхода из программы");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
