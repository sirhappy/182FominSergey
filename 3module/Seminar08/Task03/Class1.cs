using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    public interface IFigure
    {
        double Area();
    }

    class Square : IFigure
    {
        double IFigure.Area()
        {
            throw new NotImplementedException();
        }
    }

    public class Class1
    {
        public void Main()
        {

        }
    }
}
