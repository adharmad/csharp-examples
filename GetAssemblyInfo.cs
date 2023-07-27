using System;
using System.Reflection;

namespace csharp_examples
{
    class GetAssemblyInfo
    {
        public static void AssemblyInfo()
        {
            // Get the currently executing assembly.
            Assembly currentAssem = Assembly.GetExecutingAssembly();
            Console.WriteLine("Currently executing assembly: {0}", currentAssem.FullName);
            Console.WriteLine("CodeBase: {0}", currentAssem.CodeBase);
            Console.WriteLine("Location: {0}", currentAssem.Location);

        }
    }
}
