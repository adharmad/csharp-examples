using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace csharp_examples
{
    class ProdConsWithThreads
    {
        public ProdConsWithThreads(int NumCons)
        {
            NumConsumers = NumCons;
            threads = new Thread[NumConsumers];
            for (int i=0; i<NumConsumers; i++)
            {
                threads[i] = new Thread(ConsumeIt);
            }
        }

        public ConcurrentQueue<int> cq { get; set; } = new ConcurrentQueue<int>();
        public int NumConsumers { get; set; }
        public Thread[] threads {get ; set;}

        public void ProdAndConsViaThreads()
        {
            // Populate the queue.
            for (int i = 0; i < 10000; i++)
            {
                cq.Enqueue(i);
            }

            for (int i=0; i<NumConsumers; i++)
            {
                threads[i].Start();
            }


            for (int i = 0; i < NumConsumers; i++)
            {
                threads[i].Join();
                Console.WriteLine("======== Joined thread " + i + " ========");
            }

            Console.WriteLine("Done");
        }

        public void ConsumeIt()
        {
            int myValue;
            while (cq.TryDequeue(out myValue))
            {
                Thread.Sleep(10);
                int value = myValue % 13;
                Console.WriteLine("ThreadID = " + Thread.CurrentThread.ManagedThreadId + " " + value);
            }
        }
    }
}
