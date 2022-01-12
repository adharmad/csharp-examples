using System;
using System.IO;

namespace csharp_examples
{
    class TryFile2
    {
        public static void WriteFile()
        {
            // Create a string array with the lines of text
            string[] lines = { "First line", "Second line", "Third line" };

            try
            {
                // Write the string array to a new file named "WriteLines.txt".
                using (StreamWriter outputFile = new StreamWriter(Path.Combine("/tmp", "WriteLines.txt")))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be written:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
