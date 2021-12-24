using System;
using System.Threading;
using System.Collections.Concurrent;

namespace csharp_examples
{
    class ProdConsConcQueue
    {
        public ProdConsConcQueue()
        {
        }

        public void ProdAndConsUsingConcQueue()
        {
            BlockingConcurrentQueue<Work> bcq = new BlockingConcurrentQueue<Work>();
            // Populate the queue.
            for (int i = 0; i < 10000; i++)
            {
                bcq.Enqueue(new Work("workid"+i));
            }

            ThreadPoolManager threadPoolManager = new ThreadPoolManager(100, bcq);

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            threadPoolManager.StartThreadPool();
            threadPoolManager.FinalizeThreadPool();
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            Console.WriteLine("Done");
        }
    }

    public class ThreadPoolManager
    {
        public Thread[] threads { get; set; }
        public BlockingConcurrentQueue<Work> Queue { get; set; } = new BlockingConcurrentQueue<Work>();

        public ThreadPoolManager(int numThreads, BlockingConcurrentQueue<Work> bcq)
        {
            Queue = bcq;
            threads = new Thread[numThreads];

            for (int i=0; i<numThreads; i++)
            {
                threads[i] = new Thread(DoWorkInParallel);
            }
        }

        public void StartThreadPool()
        {
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start();
            }
        }

        public void FinalizeThreadPool()
        {
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }
        }

        public void DoWorkInParallel()
        {
            Work myWork;
            while ((myWork = Queue.DrainTo()) != null)
            {
                myWork.DoWork();
            }
        }
    }

    public class Work
    {
        public string WorkId { get; set; }

        public Work(string workId)
        {
            WorkId = workId;
        }

        public void DoWork()
        {
            Thread.Sleep(10);
            Console.WriteLine("ThreadID = " + Thread.CurrentThread.ManagedThreadId + " Work=" + Reverse(WorkId));
            Thread.Sleep(10);
        }

        public string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }

    public class BlockingConcurrentQueue<T> 
    {
        private readonly ConcurrentQueue<T> _queue;
        private static readonly object LOCKER = new object();


        public BlockingConcurrentQueue()
        {
            _queue = new ConcurrentQueue<T>();
        }

        public void Enqueue(T item)
        {
            lock (LOCKER)
            {
                _queue.Enqueue(item);
            }
        }

        public bool TryDequeue(out T result)
        {
            bool retVal = false;
            lock (LOCKER)
            {
                retVal = _queue.TryDequeue(out result);
            }

            return retVal;
        }

        public T DrainTo()
        {
            T element;
            TryDequeue(out element);
            return element;
        }
    }
}
