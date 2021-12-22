using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace csharp_examples
{
    class ProdConsWithThreadPool
    {
        public ProdConsWithThreadPool(int NumCons)
        {
            NumConsumers = NumCons;
            ThreadCounter = NumCons;
        }

        public ConcurrentQueue<int> cq { get; set; } = new ConcurrentQueue<int>();
        public int NumConsumers { get; set; }
        private int ThreadCounter;
        public ManualResetEvent resetEvent { get; set; }  = new ManualResetEvent(false);

        public void ProdAndConsViaThreads()
        {
            // Populate the queue.
            for (int i = 0; i < 10000; i++)
            {
                cq.Enqueue(i);
            }

            
            for (int i=0; i<NumConsumers; i++)
            {
                ThreadPool.QueueUserWorkItem(ConsumeIt);
            }

            resetEvent.WaitOne();

            Console.WriteLine("Done");
        }

        public void ConsumeIt(Object stateInfo)
        {
            int myValue;
            while (cq.TryDequeue(out myValue))
            {
                Thread.Sleep(10);
                int value = myValue % 13;
                Console.WriteLine("ThreadID = " + Thread.CurrentThread.ManagedThreadId + " " + value);
            }

            if (Interlocked.Decrement(ref ThreadCounter) == 0)
            {
                resetEvent.Set();
            }
        }
    }
}
