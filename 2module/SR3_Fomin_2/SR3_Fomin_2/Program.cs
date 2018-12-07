/** Программирование
 * Фомин Сергей, БПИ182-2
 * Вариант 2
 * **/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3_Fomin_2
{
    public static class Randomer
    {
        public static Random rnd = new Random();
    }

    class Creature
    {

        public Creature(string name, double speed)
        {
            Name = name;
            Speed = speed;
        }
        public string Name { get; }

        public double Speed { get; set; }

        public virtual string Run()
        {
            return $"I am running with a speed of {Speed}.";
        }

        public override string ToString()
        {
            return $"{Run()} My name is {Name}";
        }
    }

    class Dwarf : Creature
    {
        int _strength;
        public int Strength
        {
            get => _strength;
            protected set
            {
                if (value < 1 || value > 20) _strength = Randomer.rnd.Next(1, 20 + 1);
            }
        }
        public Dwarf(string name, double speed, int strength) : base(name, speed)
        {
            Strength = strength;
        }

        public override string Run()
        {
            return $"{base.Run()} My strength is {Strength}.";
        }

        public void MakeNewStaff()
        {
            Console.WriteLine("I\'ve created a new staff!");
        }

    }

    class Elf : Creature
    {
        private const int SpeedUpgradeYears = 77;
        int _strength;
        public int Strength
        {
            get => _strength;
            protected set
            {
                if (value < 1 || value > 20) _strength = Randomer.rnd.Next(1, 20 + 1);
            }
        }
        public int Age { get; }

        public Elf(string name, double speed, int strength) : base(name, speed)
        {
            Strength = strength;
            Age = Randomer.rnd.Next(100, 200 + 1);
        }

        public override string Run()
        {
            return $"I am running with a speed of {Speed + Age / SpeedUpgradeYears}. My strength is {Strength}.";
        }
    }

    class Parser
    {
        public static int ReadInt(int minValue, int maxValue, string showMessage, string errorMessage)
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

    static class Name
    {
        public static string Generate()
        {
            char firstLetter = (char)Randomer.rnd.Next('A', 'Z' + 1);
            int n = Randomer.rnd.Next(2, 10 + 1);
            string name = firstLetter.ToString();
            for (int i = 0; i < n; ++i)
            {
                name += (char)Randomer.rnd.Next('a', 'z' + 1);
            }
            return name;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            do
            {
                int n = Parser.ReadInt(1, 100, "Введите количество существ: ", "Неверный ввод!");
                Creature[] creatures = new Creature[n];
                for (int i = 0; i < n; ++i)
                {
                    double choose = Randomer.rnd.NextDouble();
                    if (choose < 0.2) creatures[i] = new Creature(Name.Generate(), Randomer.rnd.Next(10, 18 + 1));
                    else if (choose < 0.6) creatures[i] = new Dwarf(Name.Generate(), Randomer.rnd.Next(10, 18 + 1), Randomer.rnd.Next(-50, 50 + 1));
                    else creatures[i] = new Elf(Name.Generate(), Randomer.rnd.Next(10, 18 + 1), Randomer.rnd.Next(-50, 50 + 1));
                }

                for (int i = 0; i < n; ++i)
                {
                    Console.WriteLine(creatures[i]);
                }
                /*
                foreach (var i in creatures)
                    Console.WriteLine(i);
                */
                for (int i = 0; i < n; ++i)
                    if (creatures[i] is Dwarf) ((Dwarf)creatures[i]).MakeNewStaff();

                Console.WriteLine("Для завершения нажмите ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
