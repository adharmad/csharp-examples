using System;

namespace csharp_examples
{
    class PassPropertyByRef
    {
        public static void PropertyByRef()
        {
            Person person = new Person("Madan", "Chopra");
            Console.WriteLine(person);
            string f = person.First; ChangePropertyByRef(ref f); person.First = f;
            Console.WriteLine(person);
        }

        public static void ChangePropertyByRef(ref string var1)
        {
            var1 = "Mohan";
        }
    }

    public class Person
    {
        public string First { get; set; }
        public string Last {get ; set ; }

        public Person(string f, string l)
        {
            First = f;
            Last = l;
        }

        public override string ToString()
        {
            return $"First = {First}, Last = {Last}";
        }
    }
}
