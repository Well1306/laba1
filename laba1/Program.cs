using System;

namespace laba1
{
    class Program
    {
        static void SaveLoad()
        {
            Console.WriteLine("TEST SAVE AND LOAD");
            V1DataArray A = new("TestArray", DateTime.Now, 2, 2, 1, 1, Methods.M1);
            A.SaveAsText("testarray.txt");
            V1DataArray A1 = null;
            V1DataArray.LoadAsText("testarray.txt", ref A1);
            Console.WriteLine("Original:");
            Console.WriteLine(A.ToLongString("f3"));
            Console.WriteLine("Saved:");
            Console.WriteLine(A1.ToLongString("f3"));

            V1DataList L = new("TestList", DateTime.Now);
            L.AddDefaults(5, Methods.M1);
            L.SaveBinary("testlist.txt");
            V1DataList L1 = null;
            V1DataList.LoadBinary("testlist.txt", ref L1);
            Console.WriteLine("Original:");
            Console.WriteLine(L.ToLongString("f3"));
            Console.WriteLine("Saved:");
            Console.WriteLine(L1.ToLongString("f3"));
            Console.WriteLine("\n\n\n");
        }
        static void LINQ()
        {
            Console.WriteLine("TEST LINQ");
            V1MainCollection M = new();
            V1MainCollection M1 = new();
            V1DataList L = new("ListForLINQ", DateTime.Parse("01.01.2020 00:00:00"));
            L.AddDefaults(5, Methods.M1);
            M.Add(L);
            V1DataList L1 = new("ListForLINQ1", DateTime.Now);
            M.Add(L1);
            V1DataList L2 = new("ListForLINQ2", DateTime.Now);
            L2.AddDefaults(2, Methods.M1);
            M.Add(L2);
            V1DataArray A = new("ArrayForLINQ", DateTime.Now, 2, 2, 1, 1, Methods.M1);
            M.Add(A);
            V1DataArray A1 = new("ArrayForLINQ1", DateTime.Now);
            M.Add(A1);
            Console.WriteLine(M.ToLongString("f3"));
            Console.WriteLine("\nMIN DATE: " + M.MinDate);
            Console.WriteLine("\nSORT:");
            if (M.SortAvg is not null)
            {
                foreach (var V in M.SortAvg)
                {
                    Console.WriteLine(V + " " + V.AverageValue);
                }
            }
            if (M1.SortAvg is null)
            {
                Console.WriteLine("M1 is empty");
            }
            Console.WriteLine("\nMAX MEANSUREMENTS:");
            if (M.MaxMeasurements is not null)
            {
                foreach (var V in M.MaxMeasurements)
                {
                    Console.WriteLine(V);
                }
            }
            if (M1.MaxMeasurements is null)
            {
                Console.WriteLine("M1 is empty");
            }
            Console.WriteLine("\n\n\n");
        }
        static void Main(string[] args)
        { 
            SaveLoad();
            LINQ();
        }
    }
}
