using System;
using System.IO;

namespace csharp_examples
{
    class TryFile1
    {
        public static void ReadFile()
        {
            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader("Program.cs"))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
