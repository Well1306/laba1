using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace laba1
{
    [Serializable]
    abstract class V1Data : IEnumerable<DataItem>
    {
        public string S { get; protected set; }
        public DateTime D { get; protected set; }

        public V1Data(string S1, DateTime D1)
        {
            S = S1; D = D1;
        }
        public abstract IEnumerator<DataItem> GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        public abstract int Count { get; }
        public abstract double AverageValue { get; }
        public abstract string ToLongString(string format);
        public override string ToString()
        {
            return $"{S}, {D}";
        }
    }
}