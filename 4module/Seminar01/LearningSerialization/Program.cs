using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace LearningSerialization
{

    [Serializable]
    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Person julia = new Person() { Name = "Julia", Age = 21 };

            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream("Julia.bin", FileMode.Create))
            {
                bf.Serialize(fs, julia);
                Console.WriteLine("BinaryFormatter успешно сериализован!");
            }

            using (FileStream fs = new FileStream("Julia.bin", FileMode.Open))
            {
                Person deserializedJulia = (Person)bf.Deserialize(fs);
                Console.WriteLine($"Name: {deserializedJulia.Name}   Age: {deserializedJulia.Age}");
            }


            Person madilina = new Person() { Name = "Madilina", Age = 32 };
            SoapFormatter sf = new SoapFormatter();
            using (FileStream fs = new FileStream("Madilina.soap", FileMode.Create))
            {
                sf.Serialize(fs, madilina);
                Console.WriteLine("SOAP сериализация прошла успешно!");
            }

            using (FileStream fs = new FileStream("Madilina.soap", FileMode.Open))
            {
                Person newMadilina = (Person)sf.Deserialize(fs);
                Console.WriteLine($"Имя: {newMadilina.Name}   Возраст: {newMadilina.Age}");
            }

            Console.ReadKey();
        }
    }
}
