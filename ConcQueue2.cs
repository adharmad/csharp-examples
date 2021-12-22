using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace csharp_examples
{
    class ConcQueue2
    {
        public static void TryConcQueue2()
        {
            // Construct a ConcurrentQueue.
            ConcurrentQueue<int> cq = new ConcurrentQueue<int>();

            // Populate the queue.
            for (int i = 0; i < 10000; i++)
            {
                cq.Enqueue(i);
            }

            Action[] actions = new Action[10];
            for (int i=0; i<10; i++)
            {
                actions[i] = () =>
                {                    
                    int localValue;
                    while (cq.TryDequeue(out localValue)) PrintIt(localValue);
                };
            }

            Parallel.Invoke(actions);

            Console.WriteLine("Done");
        }

        public static void PrintIt(int value)
        {
            Console.WriteLine("ThreadID = " + Thread.CurrentThread.ManagedThreadId + " " + value);
        }
    }
}
