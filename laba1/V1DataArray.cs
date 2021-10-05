using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    class V1DataArray : V1Data
    {
        public int Count_x { get; }
        public int Count_y { get; }
        public double Step_x { get; }
        public double Step_y { get; }
        public System.Numerics.Complex[,] Array { get; }

        public V1DataArray(string S, DateTime D) : base(S,D)
        {
            Array = new System.Numerics.Complex[0, 0];
            Count_x = Count_y = 0;
            Step_x = Step_y = 0;
        }

        public V1DataArray(string S, DateTime D, int cx, int cy, double sx, double sy, FdblComplex F) : base(S,D)
        {
            Count_x = cx;
            Count_y = cy;
            Step_x = sx;
            Step_y = sy;
            Array = new System.Numerics.Complex[cx, cy];
            for (int i = 0; i < cx; ++i)
                for (int j = 0; j < cy; ++j)
                    Array[i, j] = F(sx * i, sy * j);
        }

        public override int Count
        {
            get { return Count_x * Count_y; }
        }

        public override double AverageValue
        {
            get
            {
                double avg = 0;
                for (int i = 0; i < Count_x; ++i)
                    for (int j = 0; j < Count_y; ++j)
                        avg += Array[i, j].Magnitude;
                avg /= Count;
                return avg;
            }
        }

        public override string ToString() => "Type V1DataArray, " + base.ToString() +
            $" Net: ({Count_x}, {Count_y}), Step x: {Step_x}, Step y: {Step_y}";

        public override string ToLongString(string format)
        {
            string res = ToString();
            for (int i = 0; i < Count_x; ++i)
                for (int j = 0; j < Count_y; ++j)
                {
                    DataItem a = new DataItem(Step_x * i, Step_y * j, Array[i, j]);
                    res += "\n" + a.ToLongString(format);
                }
            return res;
        }

        public static explicit operator V1DataList(V1DataArray a)
        {
            V1DataList l = new(a.S + " >> list", a.D);
            for(int i = 0; i < a.Count_x; ++i)
                for(int j = 0; j < a.Count_y; ++j)
                {
                    DataItem d = new(i * a.Step_x, j * a.Step_y, a.Array[i, j]);
                    l.Add(d);
                }
            return l;
        }
    }
}
