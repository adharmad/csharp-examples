using System;

namespace csharp_examples
{
    class TryNewGuid
    {
        public static void NewGuids()
        {
            for (int i = 0; i < 10; i++)
            {
                Guid myuuid = Guid.NewGuid();
                string myuuidAsString = myuuid.ToString();

                Console.WriteLine("Your UUID is: " + myuuidAsString);
            }
        }
    }
}
