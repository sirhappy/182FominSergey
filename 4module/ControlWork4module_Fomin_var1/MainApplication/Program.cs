/*
 * Контрольная работа за 4 модуль
 * Вариант 1
 * Фомин Сергей, БПИ182-2
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWLibrary;

namespace MainApplication
{
    partial class Program
    {
        /// <summary>
        ///     Максимальная длина слов
        /// </summary>
        private const int MaxWordsLength = 10;
        /// <summary>
        ///     Минимальное количество слов в словаре
        /// </summary>
        private const int MinWordsCount = 1;
        /// <summary>
        ///     Максимальное количество слов в словаре
        /// </summary>
        private const int MaxWordsCount = 10000;
        /// <summary>
        ///     генератор случайных чисел
        /// </summary>
        public static Random rng = new Random();

        static void Main(string[] args)
        {
            /// Путь к текстовому файлу
            string textFilePath = "../../../dictionary.txt";
            /// Путь к файлу для сериализации
            string serializePath = "../../../out.bin";

            Console.WriteLine("Введите количество строк в словаре: ");
            /// Количество строк в словаре
            int n = Parser.ReadInt(MinWordsCount, MaxWordsCount);

            try /// Пробуем создать текстовый файл со словарём
            {
                CreateText(textFilePath, n);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при создании текстового документа со словарём: " + ex.Message);
            }

            Dictionary dict = null;
            try /// Создаём словарь
            {
                dict = new Dictionary(rng.Next(2));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при создании словаря: " + ex.Message);
            }
            
            try /// Пробуем создать словарь из текстового файла
            {
                using (FileStream fs = new FileStream(textFilePath, FileMode.OpenOrCreate))
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] words = sr.ReadLine().Split(' ');
                        dict.Add(words[0], words[1]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при создании словаря из текстового документа: " + ex.Message);
            }

            try /// Пробуем сериализовать словарь
            {
                dict.MySerialize(serializePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при сериализации словаря: " + ex.Message);
            }

            Dictionary dict2 = null;
            try
            {
                dict2 = new Dictionary(dict.locale);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при создании копии словаря: " + ex.Message);
            }

            try /// Пробуем десериализовать словарь
            {
                dict2.MyDeserialize(serializePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при десериализации словаря: " + ex.Message);
            }

            ///  Вывод десериализованного словаря
            Console.WriteLine("Десериализованный словарь: ");
            foreach (var i in dict2)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            char c = 'a';
            try /// Генерируем букву, с которой начинается слово в словаре в зависимости от локали
            {
                if (dict2.locale == 0) c = (char)rng.Next('а', 'я' + 1);
                else c = (char)rng.Next('a', 'z' + 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при генерации буквы: " + ex.Message);
            }

            try /// Вывод пар слов, начинающихся со сгенерированной буквы
            {
                Console.WriteLine($"Слова, начинающиеся с буквы {c}:");
                foreach (var i in dict2.GetLetterEnumerator(c))
                {
                    Console.WriteLine(i);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при выводе слов: " + ex.Message);
            }
            Console.ReadKey();
        }

        /// <summary>
        ///     Создаём текстовый файл со словарём
        /// </summary>
        /// <param name="path">Путь к текстовому файлу</param>
        /// <param name="n">Количество строк в словаре</param>
        public static void CreateText(string path, int n)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    for (int i = 0; i < n; ++i)
                    {
                        int length1 = rng.Next(1, MaxWordsLength), length2 = rng.Next(1, MaxWordsLength);
                        string word1 = "", word2 = "";
                        for (int k = 0; k < length1; ++k)
                        {
                            word1 += (char)rng.Next('а', 'я' + 1);
                        }
                        for (int k = 0; k < length2; ++k)
                        {
                            word2 += (char)rng.Next('a', 'z' + 1);
                        }
                        sw.WriteLine($"{word1} {word2}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
