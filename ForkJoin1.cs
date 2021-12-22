using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace csharp_examples
{
    class ForkJoin1
    {
        public static void FJ()
        {
            List<int> intList = new List<int>();
            var random = new Random();
            for (int i=0; i<100; i++)
            {
                intList.Add(random.Next());
            }

            for (int i = 0; i < 100; i++)
            {
                Console.Write(intList[i] + " ");
            }
            Console.WriteLine();


            // TODO
            //System.Threading.Tasks.Parallel.For(0, 10, );
        }

        public static void AlterList(List<int> lst, int startIndex, int endIndex)
        {
            for (int i=startIndex; i<endIndex; i++)
            {
                lst[i] = lst[i] % 13;
            }
        }

    }
}
