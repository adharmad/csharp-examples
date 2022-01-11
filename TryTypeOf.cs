using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace csharp_examples
{
    class TryTypeOf
    {
        public static void RunTryTypeOf()
        {
            Parent p = new Parent();
            Child1 c1 = new Child1();
            Child2 c2 = new Child2();

            if (p.GetType() == typeof(Parent))
            {
                Console.WriteLine("I am a parent");
                Console.WriteLine(p.GetType().ToString());
            }

            if (c1.GetType() == typeof(Child1))
            {
                Console.WriteLine("I am child1");
                Console.WriteLine(c1.GetType().ToString());
            }
        }
    }

    class Parent
    {
        public string Test { get ; set; }
        public Parent() {}
    }

    class Child1 : Parent
    {
        public string Test1 { get ; set; }
        public Child1() {}
    }


    class Child2 : Parent
    {
        public string Test2 { get ; set; }
        public Child2() {}
    }
}
