using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Reflection;

namespace csharp_examples
{
    class StringInterpTest
    {
        private static Random random = new Random();
        public static void DoStringInterp()
        {
            long limit = 100000000;

            for (int i=0 ; i<limit ; i++)
            {
                string s1 = RandomAlphaString(1000);
                string s2 = RandomAlphaString(1000);
                string s3 = RandomAlphaString(1000);
                object ret2 = new TestPrinter().Method2(s1, s2, s3);
                Console.WriteLine(ret2.ToString());
            }
        }

        public static string RandomAlphaString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }

    class TestPrinter
    {
        public TestPrinter() {}
        public object Method2(string s1, string s2, string s3)
        {
            string now = DateTime.Now.ToString();
            Console.WriteLine($"Entering Method2 {now}");
            Console.WriteLine($"s1 = {s1}, s2 = {s2}, s3 = {s3}");
            Console.WriteLine($"Exiting Method2 {now}");
            return s1 + "-" + s2 + "-" + s3;
        }
    }

}
