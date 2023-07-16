using System;
using System.Collections.Generic;

namespace csharp_examples
{
    class TryDict1
    {
        public static void Dict1()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                { "hello", 123 },
                { "world", "test" },
                { "third", new List<string> { "foo", "bar" } }
            };

            foreach (KeyValuePair<string, object> elem in dict)
            {
                Console.WriteLine(elem.Key + " " + elem.Value.ToString());
            }
        }
    }
}
