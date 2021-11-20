using System;
using System.Linq;

namespace csharp_examples
{
    class TryGC
    {
        public static void GarbageCollect()
        {
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
            Allocate();
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
            GC.Collect();
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));

        }

        public static void Allocate()
        {
            string[] sArr = new string[10000];

            for(int i = 0; i < 10000; i++)
            {
                sArr[i] = string.Concat(Enumerable.Repeat("X", 1000));
            }
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
        }
    }
}
