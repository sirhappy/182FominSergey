using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotLib
{
    public class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        public void Right() { ++X; }
        public void Left() { --X; }
        public void Forward() { ++Y; }
        public void Backward() { --Y; }

        public string Position()
        {
            return $"The Robot position: x={0}, y={1}";
        }
    }

    public delegate void Steps();
}
