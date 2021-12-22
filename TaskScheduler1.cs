using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace csharp_examples
{
    class TaskScheduler1
    {
        public static void Schedule()
        {
            var schedulerPair = new ConcurrentExclusiveSchedulerPair(TaskScheduler.Default, maxConcurrencyLevel: 8);
            TaskScheduler scheduler = schedulerPair.ConcurrentScheduler;
            ParallelOptions parallelOptions = new ParallelOptions { TaskScheduler = scheduler };
            List<List<string>> myList = new List<List<string>>();
            for (int i = 0; i < 8; i++)
            {
                List<string> lst = new List<string>();
                myList.Add(lst);
                for (int j = 0; j < 10; j++)
                {
                    lst.Add("hello" + i + " saying " + j);
                }
            }

            Parallel.ForEach(myList, parallelOptions, lst => AlterList(lst));


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(myList[i][j]);
                }
                Console.WriteLine();
            }
        }

        public static void AlterList(List<string> lst)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                lst[i] = lst[i] + "Modified - ";
            }
        }
    }
}
