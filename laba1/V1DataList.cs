using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    class V1DataList : V1Data
    {
        public List<DataItem> L { get; }
        public V1DataList(string S1, DateTime D1) : base(S1, D1)
        {
            L = new List<DataItem>();
        }
        public bool Add(DataItem newItem)
        {
            bool b = !L.Contains(newItem);
            if (b) L.Add(newItem);
            return b;
        }
        public int AddDefaults(int nItems, FdblComplex F)
        {
            int n = 0;
            for (int i = 0; i < nItems; ++i)
            {
                double x = Math.Sin(i) * 8;
                double y = Math.Cosh(i);
                DataItem a = new(x, y, F(x, y));
                if (this.Add(a)) n++;
            }
            return n;
        }
        public override int Count
        {
            get { return L.Count; }
        }
        public override double AverageValue
        {
            get
            {
                double avg = 0;
                for (int i = 0; i < L.Count; ++i)
                {
                    avg += L[i].z.Magnitude;
                }
                avg /= Count;
                return avg;
            }
        }
        public override string ToString() => "Type: V1DataList, " +
            base.ToString() + $", Count: {Count}";

        public override string ToLongString(string format)
        {
            string res = ToString();
            foreach (DataItem i in L)
                res += "\n" + i.ToLongString(format);
            return res;
        }
    }
}
