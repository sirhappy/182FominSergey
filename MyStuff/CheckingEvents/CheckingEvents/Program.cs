using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckingEvents
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class ForEvents
    {
        public delegate void ChangeHandler(object sender, MyEventArgs eventArgs);
        public event ChangeHandler handler;
    }

    public class MyEventArgs
    {
        public int Num { get; set; }
        string Message { get; set; }
    }
}
