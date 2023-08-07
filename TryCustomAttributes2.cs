using System;
using System.IO;
using System.Reflection ;

namespace csharp_examples
{
    class TryCustomAttributes2
    {
        public static void TryCustomAttributes()
        {
            Type type1 = typeof(TestPropAttrObj);
            System.Console.WriteLine($"Test information for {type1}");
            DumpPropAttributes(type1);

        }

        public static void DumpPropAttributes(System.Type type)
        {
            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                foreach (System.Attribute attr in Attribute.GetCustomAttributes(propertyInfo))
                {
                    if (attr is PropAttribute a)
                    {
                        System.Console.WriteLine($"   {a.Name}, {a.Pic}, size {a.Size:f}");
                    }
                }
            }
        }
    }

    public class TestPropAttrObj
    {

        [Prop("Attr1 Name", Pic = "X(100)", Size = 100)]
        public string Attr1 { get; set; }

        [Prop("Attr2 Name", Pic = "9(10)", Size = 10)]
        public int Attr2 { get; set; }

        [Prop("Attr3 Name", Pic = "9(10)S(2)", Size = 12)]
        public double Attr3 { get; set; }

        public TestPropAttrObj() {}
    }

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class PropAttribute : System.Attribute
    {
        public string Name;
        public string Pic;
        public int Size;

        public PropAttribute(string name)
        {
            Name = name;
        }

        public PropAttribute(string name, string pic, int size)
        {
            Name = name;
            Pic = pic;
            Size = size;
        }

    }

}
