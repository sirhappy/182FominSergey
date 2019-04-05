using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task02
{

    [Serializable]
    public class Human
    {
        public string Name { get; set; }
    }

    [Serializable]
    public class Professor : Human
    {
        
    }

    [Serializable]
    public class Department
    {
        public string Name { get; set; } 
        public List<Human> Employees { get; set; } = new List<Human>();
    }
    
    [Serializable]
    public class University
    {
        public string Name { get; set; }
        public List<Department> Departments { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            University university = new University() { Name = "HSE", Departments = new List<Department>() };
            university.Departments.Add(new Department() { Name = "Департамент" });

            XmlSerializer xs = new XmlSerializer(typeof(University));
            using (FileStream fs = new FileStream("universities.xml", FileMode.Create))
            {
                xs.Serialize(fs, university);
            }

            using (FileStream fs = new FileStream("universities.xml", FileMode.Open))
            {
                object o = xs.Deserialize(fs);
                Console.WriteLine(o.GetType());
            }

            Console.ReadKey();
        }
    }
}
