using System;
using System.IO;

namespace csharp_examples
{
    class TryCustomAttributes1
    {
        public static void TryCustomAttributes()
        {
            Type type1 = typeof(TestObj1);
            System.Console.WriteLine($"Test information for {type1}");
            DumpAttributes(type1);

            Type type2 = typeof(TestObj2);
            System.Console.WriteLine($"Test information for {type2}");
            DumpAttributes(type2);

        }

        public static void DumpAttributes(System.Type type)
        {
            // Using reflection.
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(type);  // Reflection.

            // Displaying output.
            foreach (System.Attribute attr in attrs)
            {
                if (attr is TestAttribute a)
                {
                    System.Console.WriteLine($"   {a.Name}, {a.Description}, version {a.Version:f}");
                }
            }
        }
    }


    [Test("Test123", Description = "Hello World", Version = 3.141)]
    public class TestObj1
    {
        public TestObj1() {}
    }

    [Test("Test456", Description = "Mellow World", Version = 2.718)]
    public class TestObj2
    {
        public TestObj2() {}
    }

    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class TestAttribute : System.Attribute
    {
        public string Name;
        public string Description;
        public double Version;

        public TestAttribute(string name)
        {
            Name = name;
        }

        public TestAttribute(string name, string desc)
        {
            Name = name;
            Description = desc;
            Version = 1.0;
        }

        public TestAttribute(string name, string desc, double vers)
        {
            Name = name;
            Description = desc;
            Version = vers;
        }        
    }

}
