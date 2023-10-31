using System;

namespace csharp_examples
{
    class TryRef2
    {
        public static void TryRef()
        {
            string srcStr = "hello world";
            string destStr = "this is going fuzzy now";
            Console.WriteLine($"srcStr = {srcStr}, destStr = {destStr}");
            ChangeSubstrViaRef(srcStr, ref destStr, 0, 8, 11);
            Console.WriteLine("after pass ref destStr = " + destStr);
        }

        public static void ChangeSubstrViaRef(string sourceStr, ref string destinationStr, int sourceBeginIndex, int destinationBeginIndex, int numCharacters)
        {
            // Ensure sufficient space in destination
            destinationStr = destinationStr.PadRight(destinationBeginIndex + numCharacters);
            char[] destinationChArr = destinationStr.ToCharArray();

            // Ensure sufficient space in source
            sourceStr = sourceStr.PadRight(sourceBeginIndex + numCharacters);

            sourceStr.CopyTo(sourceBeginIndex, destinationChArr, destinationBeginIndex, numCharacters);
            string str = new string(destinationChArr);
            
            //Defensive check.
            if (str.Length < destinationStr.Length)
            {
                str = str.PadRight(destinationStr.Length);
            }

            destinationStr = str;
            
            return;
        }        
    }
}
