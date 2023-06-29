using System;

namespace csharp_examples
{
    class TryDate2
    {
        public static void GetDate()
        {
            DateTime dateTime = new DateTime(2023, 6, 28, 12, 13, 14, 666);
            Console.WriteLine(dateTime.ToString());
            Console.WriteLine(dateTime.ToString("yyyyMMddHHmmssff"));
        }
    }
}
