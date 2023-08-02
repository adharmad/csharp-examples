using System;

namespace csharp_examples
{
    class TryRef1
    {
        public static void TryRef()
        {
            string s1 = "hello world";
            Console.WriteLine("s1 = " + s1);
            PassNormal(s1);
            Console.WriteLine("after pass normal s1 = " + s1);
            PassRef(ref s1);
            Console.WriteLine("after pass ref s1 = " + s1);
        }

        public static void PassNormal(string s1)
        {
            s1 = "mellow world";
        }

        public static void PassRef(ref string s1)
        {
            s1 = "mellow world";
        }        
    }
}