using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LectionFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "file.txt";
            string s2 = @"..\file.txt";
            string s3 = @"..\..\work\file.txt";

            Directory.CreateDirectory("FirstDirectory");

            Directory.CreateDirectory(@"C:\RootDir");

           // File.Create(@"FirstDirectory\testfile");

            File.SetCreationTime(@"FirstDirectory\testfile", new DateTime(2020, 1, 1));
            File.SetLastAccessTime(@"FirstDirectory\testfile", new DateTime(2020, 1, 1));
            File.SetLastWriteTime(@"FirstDirectory\testfile", new DateTime(2020, 1, 1));
            Console.WriteLine(Directory.GetCurrentDirectory());

            List<string> dict = new List<string>();
            for (int i = 0; i < 100000000; ++i)
            {
                dict.Add($"String for many text {i}");
            }

            File.AppendAllLines(@"FirstDirectory\testfile", dict);

            //File.AppendAllLinesAsync(@"FirstDirectory\testfile", dict);

            Console.WriteLine("Ready");

            Console.ReadKey();
            
        }
    }
}
