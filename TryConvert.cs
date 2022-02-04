using System;
using System.IO;

namespace csharp_examples
{
    class TryConvert
    {
        public static void Convert()
        {
            double d = 0.0D;
            string s0 = d.ToString("F0");
            Console.WriteLine(s0);
            string s1 = d.ToString("F1");
            Console.WriteLine(s1);
            string s2 = d.ToString("F2");
            Console.WriteLine(s2);
            string s3 = d.ToString("F3");
            Console.WriteLine(s3);
        }
    }
}
