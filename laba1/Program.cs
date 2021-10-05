using System;

namespace laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            string f = "f3";
            DateTime date = DateTime.Now;
            V1DataArray a1 = new("a1", date, 2, 2, 0.5, 1, Methods.M1);
            Console.WriteLine(a1.ToLongString(f));
            Console.WriteLine('\n');

            V1DataList l1 = (V1DataList) a1;
            Console.WriteLine(l1.ToLongString(f));
            Console.WriteLine('\n');

            Console.WriteLine("Count: " + l1.Count.ToString());
            Console.WriteLine("Avg value: " + l1.AverageValue.ToString());
            Console.WriteLine('\n');

            V1DataArray a2 = new("a2", date, 3, 3, 1, 0.1, Methods.M1);
            V1MainCollection m = new();
            m.Add(a2);
            m.Add(l1);
            Console.WriteLine(m.ToLongString(f));
            //Console.WriteLine('\n');

            Console.WriteLine("Collection count: " + m.Count.ToString());

            for(int i = 0; i < m.Count; ++i)
            {
                Console.WriteLine($"Collection {i}:");
                Console.WriteLine("\tCount: " + m[i].Count.ToString());
                Console.WriteLine("\tAvg value: " + m[i].AverageValue.ToString());
            }
        }
    }
}
