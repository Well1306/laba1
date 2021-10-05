using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    class DataItem
    {
        public double x;
        public double y;
        public System.Numerics.Complex z;

        public DataItem(double x1, double y1, System.Numerics.Complex z1) 
        {
            x = x1;
            y = y1;
            z = z1;
        }

        public string ToLongString(string format)
        {
            return $"({this.x.ToString(format)}, {this.y.ToString(format)}) Value: {this.z.ToString(format)}  Module: {this.z.Magnitude.ToString(format)}";
        }

        public override string ToString()
        {
            return $"({this.x}, {this.y})\n{this.z}";
        }
    }
}
