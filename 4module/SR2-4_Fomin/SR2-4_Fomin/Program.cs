/*
 * Фомин Сергей, СР 2-4
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR2_4_Fomin
{
    public class DualNumber
    {
        public double A { get; set; }
        public double B { get; set; }

        /// <summary>
        ///     Конструктор дуального числа
        /// </summary>
        /// <param name="a">Действительная часть</param>
        /// <param name="b">Дуальная часть</param>
        public DualNumber(double a, double b)
        {
            A = a;
            B = b;
        }
        /// <summary>
        ///     Пустой конструктор a = 0, b = 0
        /// </summary>
        public DualNumber()
        {
            A = 0;
            B = 0;
        }

        /// <summary>
        ///     Перегрузка +
        /// </summary>
        /// <param name="a">Первое дуальное число</param>
        /// <param name="b">Второое дуальное число</param>
        /// <returns>a + b</returns>
        public static DualNumber operator +(DualNumber a, DualNumber b)
        {
            return new DualNumber(a.A + b.A, a.B + b.B);
        }

        /// <summary>
        ///     Перегрузка -
        /// </summary>
        /// <param name="a">Первое дуальное число</param>
        /// <param name="b">Второое дуальное число</param>
        /// <returns>a - b</returns>
        public static DualNumber operator -(DualNumber a, DualNumber b)
        {
            return new DualNumber(a.A - b.A, a.B - b.B);
        }

        /// <summary>
        ///     Перегрузка *
        /// </summary>
        /// <param name="a">Первое дуальное число</param>
        /// <param name="b">Второое дуальное число</param>
        /// <returns>a * b</returns>
        public static DualNumber operator *(DualNumber a, DualNumber b)
        {
            return new DualNumber(a.A * b.A, a.B * b.A + a.A * b.B);
        }

        /// <summary>
        ///     Перегрузка /
        /// </summary>
        /// <param name="a">Первое дуальное число</param>
        /// <param name="b">Второое дуальное число</param>
        /// <returns>a / b</returns>
        public static DualNumber operator /(DualNumber a, DualNumber b)
        {
            return new DualNumber(a.A / b.A, (a.B * b.A - a.A * b.B) / (b.A * b.A));
        }

        /// <summary>
        ///     Приведение дабла к дуалу
        /// </summary>
        /// <param name="x">x</param>
        public static implicit operator DualNumber(double x)
        {
            return new DualNumber { A = x, B = 0 };
        }

        public override string ToString()
        {
            return $"{A:F3} + {B:F3}ε";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            do
            {
                DualNumber a1 = new DualNumber(), a2 = new DualNumber();
                double k;
                a1.A = Reader.ReadDouble("Введите a первого дуального числа: ");
                a1.B = Reader.ReadDouble("Введите b первого дуального числа: ");
                a2.A = Reader.ReadDouble("Введите a второго дуального числа: ");
                a2.B = Reader.ReadDouble("Введите b второго дуального числа: ");
                k = Reader.ReadDouble("Введите k: ");
                try
                {
                    Console.WriteLine("a1 + a2 = " + (a1 + a2));
                    Console.WriteLine("a1 - a2 = " + (a1 - a2));
                    Console.WriteLine("a1 * a2 = " + (a1 * a2));
                    if (Math.Abs(a2.B) < double.Epsilon)
                        Console.WriteLine("Деление невозможно");
                    else
                        Console.WriteLine("a1 / a2 = " + (a1 / a2));
                    Console.WriteLine("a1 + k = " + (a1 + k));
                    Console.WriteLine("a1 - k = " + (a1 - k));
                    Console.WriteLine("a1 * k = " + (a1 * k));

                    if (Math.Abs(k) < double.Epsilon)
                        Console.WriteLine("Деление невозможно");
                    else
                        Console.WriteLine("a1 / k = " + (a1 / k));
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Попытка деления на ноль!");
                }
                catch (ArithmeticException)
                {
                    Console.WriteLine("Ошибка в арифметике!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }

    class Reader
    {
        /// <summary>
        ///     Считывает double
        /// </summary>
        /// <param name="message">Сообщение для пользователя</param>
        /// <returns>Считанное число</returns>
        public static double ReadDouble(string message)
        {
            Console.Write(message);
            double result;
            while (!double.TryParse(Console.ReadLine(), out result))
                Console.Write("Неверный формат числа!\n" + message);
            return result;
        }
    }
}
