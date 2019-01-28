using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    delegate double delegataConvertTemperature(double x);

    class TemperatureConverterImp
    {
        public double CelsiumToFarenheit(double celsium) => 9d / 5 * (celsium + 32);

        public double FarenheitToCelsium(double farenheit) => 5d / 9 * (farenheit - 32);
    }

    class Program
    {
        static void Main(string[] args)
        {
            delegataConvertTemperature del1, del2;
            double c = 36.6;
            TemperatureConverterImp temperature = new TemperatureConverterImp();
            del1 = temperature.CelsiumToFarenheit;
            del2 = temperature.FarenheitToCelsium;
            Console.WriteLine(del1(c) + " " + del2(c));
            Console.ReadKey();
        }
    }
}
