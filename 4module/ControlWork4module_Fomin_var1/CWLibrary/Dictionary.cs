using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace CWLibrary
{
    /// <summary>
    ///     Класс, описывающий словарь
    /// </summary>
    [Serializable]
    public class Dictionary : IEnumerable<Pair<string, string>>
    {
        public int locale;
        private List<Pair<string, string>> _words = new List<Pair<string, string>>();

        /// <summary>
        ///     Конструктор класса
        /// </summary>
        /// <param name="locale">Локаль</param>
        public Dictionary(int locale)
        {
            if (locale != 0 && locale != 1)
                throw new ArgumentOutOfRangeException();
            this.locale = locale;
        }

        /// <summary>
        ///     Добавление элемента в словарь
        /// </summary>
        /// <param name="pair">Пара, которую мы добавляем в словарь</param>
        public void Add(Pair<string, string> pair)
        {
            pair.item1.ToLower();
            pair.item2.ToLower();
            _words.Add(pair);
        }

        /// <summary>
        ///     Добавление элемента в словарь
        /// </summary>
        /// <param name="item1">Первое слово (русское)</param>
        /// <param name="item2">Второе слово (английское)</param>
        public void Add(string item1, string item2)
        {
            Add(new Pair<string, string>(item1, item2));
        }

        /// <summary>
        ///     Enumerator по словарю
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Pair<string, string>> GetEnumerator()
        {
            List<Pair<string, string>> result;
            if (locale == 0)
                result = _words.OrderBy(w => w.item1).ToList();
            else
                result = _words.OrderBy(w => w.item2).ToList();
            return result.GetEnumerator();
        }

        /// <summary>
        ///     Enumerator по словарю
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        ///     Enumerable по заданной первой букве
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public IEnumerable<Pair<string, string>> GetLetterEnumerator(char c)
        {
            List<Pair<string, string>> result;
            if (locale == 0)
                result = _words.OrderBy(w => w.item1).ToList();
            else
                result = _words.OrderBy(w => w.item2).ToList();
            if (c >= 'а' && c <= 'я') // выбираем по русским словам
                result = result.Where(w => w.item1[0] == c).ToList();
            if (c >= 'a' && c <= 'z')
                result = result.Where(w => w.item2[0] == c).ToList();
            return result;
        }

        /// <summary>
        ///     Сериализация
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void MySerialize(string path)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, this);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     Десериализация
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void MyDeserialize(string path)
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    Dictionary dict = (Dictionary)binaryFormatter.Deserialize(fs);
                    _words = dict._words;
                    locale = dict.locale;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
