using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    abstract class V1Data
    {
        public string S { get; }
        public DateTime D { get; }

        public V1Data(string S1, DateTime D1)
        {
            S = S1; D = D1;
        }
        public abstract int Count { get; }
        public abstract double AverageValue { get; }
        public abstract string ToLongString(string format);
        public override string ToString()
        {
            return $"{S}, {D}" ;
        }
    }
}
