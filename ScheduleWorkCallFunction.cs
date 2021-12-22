using System;
using System.Threading.Tasks;
using System.Threading;

namespace csharp_examples
{
    class ScheduleWorkCallFunction
    {
        public static void ScheduleFunction()
        {
            Task task = Task.Run(Foo);

            // Wait for task to be complete
            task.Wait();
        }

        public static void Foo()
        {
            Console.WriteLine("Hello Sleeping in function");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Awoke from function");
        }
    }
}
