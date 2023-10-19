using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace csharp_examples
{
    public class TryLinq2
    {
        public static void sortUsingLinq2()
        {
            IList<TObject> lst = new List<TObject> {
                new TObject("Fox", "San Francisco", 12, 1.1),
                new TObject("Apple", "San Francisco", 910, 2.2),
                new TObject("Doll", "New York", 45, 3.3),
                new TObject("Fox", "New York", 13, 0.5),
                new TObject("Banana", "New York", 78, 5.5),
                new TObject("Doll", "New York", 56, 4.4),
                new TObject("Banana", "San Francisco", 89, 3.2),
                new TObject("Apple", "San Francisco", 1011, 1.2)
            };

           printList(lst);

           IList<TObject> lst1 = sort1(lst, obj => obj.StrField);

           //printList(lst1);

            IList<TObject> lst2 = sort2<TObject>(lst, obj => obj.StrField, obj => obj.XField, obj => obj.LongField);

        }

        public static IList<TObject> sort1(IList<TObject> lst, Func<TObject, string> cond1)
        {
            return lst.OrderBy(cond1).ToList();
        }

        public static IList<TObject> sort2<T>(IList<TObject> lst, params Func<TObject, object>[] conds)
        {
            IOrderedEnumerable<TObject> tmpLst = lst.OrderBy(conds[0]);
            //printList(tmpLst.ToList());

            for (int i=1 ; i<conds.Length ; i++)
            {
                tmpLst = tmpLst.ThenBy(conds[1]);
                //printList(tmpLst.ToList());
            }

            return tmpLst.ToList();
        }

        public static void printList(IList<TObject> lst)
        {
            foreach(TObject sObject in lst)
            {
                Console.WriteLine(sObject);
            }
            Console.WriteLine("========");   
        }
    }

    public class TObject
    {
        public string StrField { get; set; }
        public string XField { get; set; }
        public long LongField { get; set; }
        public double DoubleField { get; set; }

        public TObject(string strField, string xField, long longField, double doubleField)
        {
            StrField = strField;
            XField = xField;
            LongField = longField;
            DoubleField = doubleField;
        }

        public override string ToString()
        {
            return StrField + " " + XField + " " + LongField + " " + DoubleField;
        }
    }
}
