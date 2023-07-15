using System;
using System.Collections.Generic;

namespace csharp_examples
{
    class TryGenericsClass1
    {
        public static void TestGenericsClassMethod()
        {
            GenContainer<string> genContainer1= new GenContainer<string>();
            genContainer1.TheLst.Add("hello");
            genContainer1.TheLst.Add("world");
            genContainer1.PrintLst();

            Console.WriteLine("======");

            GenContainer<Animal> genContainer2= new GenContainer<Animal>();
            genContainer2.TheLst.Add(new Animal("dog", "woof!"));
            genContainer2.TheLst.Add(new Animal("cat", "mew!"));
            genContainer2.TheLst.Add(new Animal("cow", "moo!"));
            genContainer2.PrintLst();
        }
    }

    class GenContainer<T>
    {
        public List<T> TheLst { get; set; }

        public GenContainer()
        {
            TheLst = new List<T>();
        }

        public void PrintLst()
        {
            foreach (T t in TheLst)
            {
                Console.WriteLine(t.ToString());
            }
        }
    }

    class Animal
    {
        public string Name { get; set; }
        public string Say { get; set; }

        public Animal(string name, string say)
        {
            Name = name;
            Say = say;
        }

        public override string ToString()
        {
            return Name + " seaaks " + Say;
        }
    }
}
