using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    interface IFunction
    {
        double Function(double x);
    }


    public delegate double Calculate(double x);

    public class F : IFunction
    {
        public Calculate f;

        public F(Calculate f)
        {
            this.f = f;
        }

        public double Function(double x)
        {
            return f(x);
        }
    }

    public class G : F, IFunction
    {
        F f1, f2;
        public G(F f1, F f2) : base(f1.f)
        {
            this.f1 = f1;
            this.f2 = f2;
        }

        public new double Function(double x)
        {
            return GF(x);
        }

        public double GF(double x0)
        {
            return f2.f(f1.f(x0));
        }
    }
}
