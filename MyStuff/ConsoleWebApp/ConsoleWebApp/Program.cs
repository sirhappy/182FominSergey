using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWebApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            Console.WriteLine($"ip = {ipAddress}");

            WebClient webClient = new WebClient();
            /*
            using (Stream stream = webClient.OpenRead("https://www.vk.com/"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            Console.WriteLine("Файл загружен");
            */

            IPHostEntry host1 = Dns.GetHostEntry("www.microsoft.com");
            Console.WriteLine(host1.HostName);
            foreach (IPAddress ip in host1.AddressList)
                Console.WriteLine(ip.ToString());

            Console.WriteLine();

            IPHostEntry host2 = Dns.GetHostEntry("google.com");
            Console.WriteLine(host2.HostName);
            foreach (IPAddress ip in host2.AddressList)
                Console.WriteLine(ip.ToString());

            Console.WriteLine();
            IPHostEntry host3 = Dns.GetHostEntry("vk.com");
            Console.WriteLine(host3.HostName);
            foreach (IPAddress ip in host3.AddressList)
                Console.WriteLine(ip.ToString());

            Function();

            Console.ReadKey();
        }

        static async void Function()
        {
            WebRequest webRequest = WebRequest.Create("https://api.vk.com/method/users.get?user_id=151537141&v=5.52");
            WebResponse webResponse = await webRequest.GetResponseAsync();
            using (Stream stream = webResponse.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
        }
    }
}
