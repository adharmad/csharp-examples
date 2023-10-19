using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace csharp_examples
{
    public class TryLinq1
    {
        public static void sortUsingLinq()
        {
            IList<SObject> lst = new List<SObject> {
                new SObject("Fox", 123, 1.1),
                new SObject("Doll", 456, 3.3),
                new SObject("Banana", 789, 4.4),
                new SObject("Apple", 101112, 2.2)
            };

            foreach(SObject sObject in lst)
            {
                Console.WriteLine(sObject);
            }
            Console.WriteLine("========");

            IEnumerable<SObject> sorted1 = lst.OrderBy(obj => obj.StrField).ThenBy(obj => obj.DoubleField);

            foreach(SObject sObject in sorted1)
            {
                Console.WriteLine(sObject);
            }
            Console.WriteLine("========");

            IEnumerable<SObject> sorted2 = lst.OrderByDescending(obj => obj.LongField);

            foreach(SObject sObject in sorted2)
            {
                Console.WriteLine(sObject);
            }
        }
    }

    public class SObject
    {
        public string StrField { get; set; }
        public long LongField { get; set; }
        public double DoubleField { get; set; }

        public SObject(string strField, long longField, double doubleField)
        {
            StrField = strField;
            LongField = longField;
            DoubleField = doubleField;
        }

        public override string ToString()
        {
            return StrField + " " + LongField + " " + DoubleField;
        }
    }
}
