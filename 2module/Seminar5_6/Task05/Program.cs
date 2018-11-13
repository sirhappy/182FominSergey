using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
    class VideoFile
    {
        string _name; // наименование видеофайла
        int _duration; // длительность в секундах
        int _quality; // качество видеофайла

        public VideoFile(string name, int duration, int quality)
        {
            _name = name;
            _duration = duration;
            _quality = quality;
        }

        public int Size => _duration * _quality;

        public override string ToString() => $"name = {_name} duration = {_duration} quality = {_quality}";
    }

    class Program
    {
        public static Random rnd = new Random();

        public static string RandomString()
        {
            int n = rnd.Next(2, 10);
            string s = "";
            for (int i = 0; i < n; ++i)
                s += (char)rnd.Next('a', 'z' + 1);
            return s;
        }

        public static VideoFile RandomVideoFile() => new VideoFile(RandomString(), rnd.Next(60, 361), rnd.Next(100, 1001));

        static void Main(string[] args)
        {
            do
            {
                VideoFile videoFile = RandomVideoFile();
                Console.WriteLine("Отдельный видеофайл: " + videoFile + '\n');

                int N = rnd.Next(5, 16);
                VideoFile[] array = new VideoFile[N];
                for (int i = 0; i < N; ++i)
                {
                    array[i] = RandomVideoFile();
                    Console.WriteLine(i + " " + array[i]);
                }

                Console.WriteLine("\nРазмер этих видеофайлов больше отдельного: ");
                for (int i = 0; i < N; ++i)
                    if (videoFile.Size > array[i].Size)
                        Console.WriteLine(i + " " + array[i]);

                Console.WriteLine("Нажмите ESC для выхода из программы\n");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            
        }
    }
}
