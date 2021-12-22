using System;
using System.Threading;

namespace csharp_examples
{
    public class ThreadPool2
    {
        public static void RunThreads()
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(MyMethod));
            }
            Console.Read();
        }

        public static void MyMethod(object obj)
        {
            Thread thread = Thread.CurrentThread;
            Console.WriteLine("Executing " + thread.ManagedThreadId);
            string message = $"Background: {thread.IsBackground}, Thread Pool: {thread.IsThreadPoolThread}, Thread ID: {thread.ManagedThreadId}";
            Console.WriteLine(message);
            Thread.Sleep(1000);
            Console.WriteLine("Exiting " + thread.Name);
        }
    }
}
