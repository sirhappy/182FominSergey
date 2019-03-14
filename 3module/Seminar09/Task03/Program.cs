using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream("alphabet.txt", FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    fs.Seek(-1, SeekOrigin.End);
                    char c = (char)fs.ReadByte();
                    Console.Write(c);
                    Console.WriteLine(fs.Length + " " + fs.Position);
                }
            }
            Console.ReadKey();
        }
    }
}
