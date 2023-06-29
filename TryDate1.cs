using System;

namespace csharp_examples
{
    class TryDate1
    {
        public static void PrintDate()
        {
            Console.WriteLine(DateTime.Now.ToString());
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd 'T'HH:mm:ss"));
        }
    }
}
