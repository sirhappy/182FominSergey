using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fomin_SR2_var2
{
    class Program
    {
        /// <summary>
        ///     Константы для генерации машин
        /// </summary>
        private const int NumberOfCars = 10;
        private const int MinPower = 50;
        private const int MaxPower = 250;
        private const int MinWeight = 900;
        private const int MaxWeight = 3000;
        private const int MinRun = 0;
        private const int MaxRun = 300000;

        /// <summary>
        ///     Random для генерации характеристик машин
        /// </summary>
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            do
            {
                Car[] cars = new Car[NumberOfCars];
                for (int i = 0; i < NumberOfCars; ++i)
                {
                    cars[i] = new Car(rnd.Next(MinPower, MaxPower) + rnd.NextDouble(), 
                                      rnd.Next(MinWeight, MaxWeight) + rnd.NextDouble(), 
                                      rnd.Next(MinRun, MaxRun) + rnd.NextDouble());
                }
                Array.ForEach(cars, x => Console.WriteLine(x));
                
                Array.Sort(cars, (a, b) => b.Run.CompareTo(a.Run));
                
                /*
                 * Сортировка без использования CompareTo
                Array.Sort(cars, (a, b) =>
                {
                    if (b.Run < a.Run) return -1;
                    else if (b.Run > a.Run) return 1;
                    else return 0;
                });
                */

                Console.WriteLine("Сортируем по убыванию пробега: ");
                Array.ForEach(cars, x => Console.WriteLine(x));

                Console.WriteLine("Press ESC to quit the program");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }

    class Car
    {
        /// <summary>
        ///     Мощность
        /// </summary>
        private double _power;

        /// <summary>
        ///     Вес
        /// </summary>
        private double _weight;

        /// <summary>
        ///     Пробег
        /// </summary>
        private double _run;

        /// <summary>
        ///     Конструктор Car
        /// </summary>
        /// <param name="power">Мощность</param>
        /// <param name="weight">Вес</param>
        /// <param name="run">Пробег</param>
        public Car(double power, double weight, double run)
        {
            _power = power;
            _weight = weight;
            _run = run;
        }

        /// <summary>
        ///     Свойство мощности
        /// </summary>
        public double Power { get => _power; }
        
        /// <summary>
        ///     Свойство веса
        /// </summary>
        public double Weight { get => _weight; }

        /// <summary>
        ///     Свойство пробега
        /// </summary>
        public double Run { get => _run; }

        /// <summary>
        ///     Переопределение ToString
        /// </summary>
        /// <returns>Информация о машине</returns>
        public override string ToString()
        {
            return $"Мощность: {Power:F3} л.с.;\t Вес: {Weight:F3} кг;\t Пробег: {Run:F3} км\t";
        }
    }
}
