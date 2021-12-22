using System;
using System.Threading.Tasks;
using System.Threading;

namespace csharp_examples
{
    class ScheduleWork
    {
        public static void ScheduleIt()
        {
            Task task = Task.Run(() =>
                {
                    Console.WriteLine("Sleeping");
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    Console.WriteLine("Awoke");
                }
            );

            // Wait for task to be complete
            task.Wait();
        }
    }
}
