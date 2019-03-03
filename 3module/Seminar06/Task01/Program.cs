using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        public interface ITransform
        {   // интерфейс преобразование
            void Transform(double coef);    // преобразовать 
        }
        class Circle : ITransform
        {   // круг
            double rad = 1;     // радиус круга
            public void Transform(double coef) { rad *= coef; }
            public override string ToString()
            {
                return String.Format("Площадь круга: {0:G4}",
                                  Math.PI * rad * rad);
            }
        }
        class Cube : ITransform
        {   // куб
            double rib = 1;     // ребро куба
            public void Transform(double coef) { rib *= coef; }
            public override string ToString()
            {
                return String.Format("Объем куба: {0:G4}",
                                 rib * rib * rib);
            }
        }

        public static void Report(ITransform g)
        {
            Console.WriteLine("Данные объекта класса {0}:", g.GetType());
            Console.WriteLine(g);
        }
        public static ITransform Mapping(ITransform g, double d)
        {
            g.Transform(d);
            return g;
        }
        public static void Main()
        {
            ITransform[] iarray = new ITransform[4];
            ITransform ira = new Circle();
            iarray[0] = ira;
            ira.Transform(3);
            iarray[1] = ira;
            ira = Mapping(new Cube(), 2);
            iarray[2] = ira;
            iarray[3] = new Circle();
            foreach (ITransform obj in iarray)
                Report(obj);
            Console.ReadKey();
        }

    }
}
