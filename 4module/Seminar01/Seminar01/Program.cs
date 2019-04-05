using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Seminar01
{
    [Serializable]
    public class Student
    {
        public Student(string surname, int course)
        {
            Surname = surname;
            Course = course;
        }

        public Student()
        {
            Surname = null;
            Course = 0;
        }

        public string Surname { get; set; }
        public int Course { get; set; }

    }

    [Serializable]
    public class Group
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

        public override string ToString()
        {
            return Name + " " + Students.Count.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Group group0 = new Group() { Name = "BPI182" };
            Group group1 = new Group() { Name = "BPI181" };

            group0.Students.Add(new Student("Fomin", 1));
            group0.Students.Add(new Student("Petelin", 2));

            group1.Students = group0.Students;

            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream("data0.bin", FileMode.Create))
            {
                bf.Serialize(fs, group0);
            }

            SoapFormatter sf = new SoapFormatter();
            XmlSerializer xs = new XmlSerializer(typeof(Group));
            using (FileStream fs = new FileStream("data1.xml", FileMode.Create))
            {
                xs.Serialize(fs, group1);
            }

            Group group0d;
            using (FileStream fs = new FileStream("data0.bin", FileMode.Open))
            {
                group0d = (Group)bf.Deserialize(fs);
            }

            Console.WriteLine(group0d);

            Console.ReadKey();
        }
    }
}
