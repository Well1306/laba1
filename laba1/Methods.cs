using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{

    delegate System.Numerics.Complex FdblComplex(double x, double y);
    static class Methods
    {
        public static System.Numerics.Complex M1(double x, double y)
        {
            System.Numerics.Complex a = new(x, y);
            return a;
        }
    }
}
