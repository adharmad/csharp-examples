﻿using System;

namespace csharp_examples
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConnectToDatabase.Connect();
            //ExecuteSelectQuery.ExecuteQuery();
            //ThreadPool1.RunMain();
            //ThreadPool2.RunThreads();
            //ScheduleWork.ScheduleIt();
            //ScheduleWorkCallFunction.ScheduleFunction();
            //TaskScheduler1.Schedule();
            //ConcQueue1.TryConcQueue();
            //ConcQueue2.TryConcQueue2();
            //new ProdCons(2).ProdAndCons();
            //new ProdConsWithThreads(4).ProdAndConsViaThreads();
            //new ProdConsWithThreadPool(5).ProdAndConsViaThreads();
            new ProdConsConcQueue().ProdAndConsUsingConcQueue();
        }
    }
}
