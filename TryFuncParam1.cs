using System;
using System.Collections.Generic;

namespace csharp_examples
{
    class TryFuncParam1
    {
        public static void FuncParam()
        {
            var funcDict = new Dictionary<string, Action>()
            {
                { "callme1", delegate(){ CallMe1(); }},
                { "callme2", delegate(){ CallMe2(); }}
            };

            funcDict["callme1"]();
            funcDict["callme2"]();
        }


        public static void CallMe1()
        {
            Console.WriteLine("Calling me 1");
        }

        public static void CallMe2()
        {
            Console.WriteLine("Calling me 2");
        }

    }
}
