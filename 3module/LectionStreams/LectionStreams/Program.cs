using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LectionStreams
{
    

    class Program
    {

        static void Main(string[] args)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            DirectoryInfo directory = new DirectoryInfo(@"C:\Windows");
            directory.Delete();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("Название: {0}", drive.Name);
                Console.WriteLine("Тип: {0}", drive.DriveType);
                if (drive.IsReady)
                {
                    Console.WriteLine("Объем диска: {0}", drive.TotalSize);
                    Console.WriteLine("Свободное пространство: {0}", drive.TotalFreeSpace);
                    Console.WriteLine("Метка: {0}", drive.VolumeLabel);
                }
                Console.WriteLine();
            }

            string dirName = "C:\\";
            Rec(dirName);      // Рекурсивно обходим все директории (прикольная штука)

            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Подкаталоги:");
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
            }


            /*
            using (StreamWriter sw1 = new StreamWriter("firstdoc.txt"), sw2 = new StreamWriter("seconddoc.txt"))
            {
                sw1.WriteLine("This string идёт в первый doc");
                sw2.WriteLine("This string идёт во второй doc");
            }
            */
            Console.ReadKey();
        }
        public static void Rec(string s, int t = 1)
        {
            if (Directory.Exists(s))
            {
                try
                {
                    string[] dirs = Directory.GetDirectories(s);
                    string[] files = Directory.GetFiles(s);
                    foreach (string dir in dirs)
                    {
                        if (dir.Contains("craft")) Console.WriteLine(dir);
                        DirectoryInfo dirInfo = new DirectoryInfo(dir);
                        Console.WriteLine($"{" ".PadLeft(t*2)} {dirInfo.Name}");
                        Rec(dir, t + 1);
                    }
                    foreach (string file in files)
                    {
                        if (file.Contains("craft")) Console.WriteLine(file);
                    }
                }
                catch (Exception ex)
                {
       //             Console.WriteLine("Access error" + ex);
                }
            }
        }
    }
}
