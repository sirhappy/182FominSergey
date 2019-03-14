using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar09
{
    class Program
    {

        static Random rnd = new Random();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            FileInfo file = new FileInfo("test4.txt");
            if (!file.Exists) file.Create();
           

            using (StreamWriter sw = new StreamWriter(file.Name))
            {
                for (int i = 0; i < n; ++i)
                   sw.WriteLine(rnd.Next(-20, 21));
            }

            using (StreamReader sr = new StreamReader(file.Name))
            {
                using (StreamWriter sw2 = new StreamWriter("test2.txt"), sw3 = new StreamWriter("test3.txt"))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        int x = int.Parse(s);
                        if (x % 2 == 0) sw2.WriteLine(x);
                        else sw3.WriteLine(x);
                    }
                }
            }
            
        }
    }
}
