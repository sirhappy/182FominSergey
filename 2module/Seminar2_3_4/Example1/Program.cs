using System;

// пример взят с сайта https://metanit.com/sharp/tutorial/3.1.php

namespace HelloApp
{
    class Person
    {
        public string name { get; set; } // имя
        private int age;     // возраст

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 0) throw new ArgumentException();
                age = value;
            }
        }

        public Person(string name = "noName", int age = 18)
        {
            this.name = name;
            this.age = age;
            Console.WriteLine(2);
        }
        /*
        public Person() : this("noName")
        {
            Console.WriteLine(0);
        }

        public Person(string name) : this(name, 18) { Console.WriteLine(1); }
        */

        public void GetInfo()
        {
            Console.WriteLine($"Имя: {name}  Возраст: {age}");
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Person tom1 = new Person("Tom1", 18);
            tom1.GetInfo();
            Person tom2 = new Person("Tom2");
            tom2.GetInfo();
            Person tom3 = new Person();
            tom3.Age = 25;
            tom3.name = "tom3";
            tom3.GetInfo();

            Console.ReadKey();
        }
    }
}