using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

namespace Task01
{

    [DataContract]
    class Student
    {
        [DataMember]
        public string Surname { get; set; }
        
        [DataMember]
        public int Course { get; set; }
    }

    [DataContract]
    class Group
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<Student> Students { get; set; } = new List<Student>();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Group group1 = new Group(), group2 = new Group();
            Group[] groups = { group1, group2 };
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Group[]));
            using (FileStream fs = new FileStream("groups.json", FileMode.Create))
            {
                js.WriteObject(fs, groups);
            }

            using (FileStream fs = new FileStream("groups.json", FileMode.Open))
            {
                groups = (Group[])js.ReadObject(fs);
            }

        }
    }
}
