using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace laba1
{
    [Serializable]
    class V1DataList : V1Data
    {
        public List<DataItem> L { get; }
        public V1DataList(string S1, DateTime D1) : base(S1, D1)
        {
            L = new List<DataItem>();
        }
        public override IEnumerator<DataItem> GetEnumerator()
        {
            return L.GetEnumerator();
        }
        public bool Add(DataItem newItem)
        {
            foreach (DataItem i in L)
            {
                if (newItem.x == i.x && newItem.y == i.y) return false;
            }
            L.Add(newItem);
            return true;
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

        public bool SaveBinary(string filename)
        {
            FileStream file = null;
            try
            {
                using (file = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    BinaryFormatter form = new BinaryFormatter();
                    form.Serialize(file, this);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return false;
            }
            finally
            {
                if (file != null) file.Close();
            }
        }

        public static bool LoadBinary(string filename, ref V1DataList v1)
        {
            BinaryReader file = null;
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    BinaryFormatter form = new BinaryFormatter();
                    v1 = (V1DataList)form.Deserialize(fs);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return false;
            }
            finally
            {
                if (file != null) file.Close();
            }
        }
    }
}
