using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Street
{
    [Serializable]
    public class Street
    {
        public string Name { get; set; }

        public int[] Houses { get; set; }
        
        public static int operator ~(Street street) => street.Houses.Length;

        public static bool operator !(Street street)
        {
            foreach (var i in street.Houses)
            {
                if (i == 7) return true;
            }
            return false;
        }

        public override string ToString()
        {
            string s = $"{Name} Street: ";
            foreach (var i in Houses) s += i.ToString() + " ";
            s = s.Substring(0, s.Length - 1) + ";";
            return s;
        }
    }
}
