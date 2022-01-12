using System;
using System.Collections.Generic;

namespace csharp_examples
{
    class TryList1
    {
        public static void TestList()
        {
            List<string> lst = new List<string>();
            for (int i=0 ; i<10 ; i++)
            {
                lst.Add("hello" + i);
            }

            Console.WriteLine(string.Join(", ", lst));

            for (int i=0 ; i<10 ; i++)
            {
                if (i%2 == 0)
                {
                    lst.Remove("hello" + i);
                }
            }

            Console.WriteLine(string.Join(", ", lst));
        }
    }
}
