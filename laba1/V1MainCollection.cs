using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    class V1MainCollection
    {
        private List<V1Data> D;
        public V1MainCollection()
        {
            D = new List<V1Data>();
        }
        public int Count
        {
            get => D.Count;
        }
        public V1Data this[int index]
        {
            get => D[index];
        }
        public bool Contains(string ID)
        { 
            foreach(V1Data i in D)
            {
                if (i.S == ID) return true;
            }
            return false;
        }
        public bool Add(V1Data v1Data)
        {
            if (!Contains(v1Data.S))
            {
                D.Add(v1Data);
                return true;
            }
            else return false;
        }
        public string ToLongString(string format)
        {
            string res = "";
            foreach(V1Data i in D)
            {
                res += i.ToLongString(format) + '\n';
            }
            return res;
        }
        public override string ToString()
        {
            string res = "";
            foreach (V1Data i in D)
            {
                res += i.ToString() + '\n';
            }
            return res;
        }
    }
}
