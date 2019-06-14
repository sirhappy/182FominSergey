using System;
using System.Text;
using System.Threading.Tasks;

namespace CWLibrary
{
    /// <summary>
    ///     Класс, описывающий пару
    /// </summary>
    /// <typeparam name="T">Тип первого элемента</typeparam>
    /// <typeparam name="U">Тип второго элемента</typeparam>
    [Serializable]
    public class Pair<T, U> : IComparable
        where T: IComparable
        where U: IComparable
    {
        /// <summary>
        ///     Первый элемент
        /// </summary>
        public T item1;
        /// <summary>
        ///     Второй элемент
        /// </summary>
        public U item2;

        /// <summary>
        ///     Конструктор класса
        /// </summary>
        /// <param name="item1">Первый элемент</param>
        /// <param name="item2">Второй элемент</param>
        public Pair(T item1, U item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        /// <summary>
        ///     Сравнение двух пар
        /// </summary>
        /// <param name="obj">пара</param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            return item1.CompareTo(((Pair<T, U>)obj).item1);
        }

        /// <summary>
        ///     Переопределённый ToString
        /// </summary>
        /// <returns>Информация о паре</returns>
        public override string ToString()
        {
            return $"{item1}; {item2}";
        }
    }
}
