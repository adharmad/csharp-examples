using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace csharp_examples
{
    class ProdCons
    {
        public ProdCons(int NumCons)
        {
            NumConsumers = NumCons;
            actions = new Action[NumConsumers];
            for (int i=0; i<NumConsumers; i++)
            {
                actions[i] = new Action(ConsumeIt);
            }
        }

        public ConcurrentQueue<int> cq { get; set; } = new ConcurrentQueue<int>();
        public int NumConsumers { get; set; }
        public Action[] actions {get ; set;}

        public void ProdAndCons()
        {
            // Populate the queue.
            for (int i = 0; i < 10000; i++)
            {
                cq.Enqueue(i);
            }

            Parallel.Invoke(actions);

            Console.WriteLine("Done");
        }

        public void ConsumeIt()
        {
            int myValue;
            while (cq.TryDequeue(out myValue))
            {
                int value = myValue % 13;
                Console.WriteLine("ThreadID = " + Thread.CurrentThread.ManagedThreadId + " " + value);
            }
        }
    }
}
