using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace csharp_examples
{
    class TryType1
    {
        public string myType {get ; set ; } = System.Reflection.Assembly.GetExecutingAssembly().EntryPoint.DeclaringType.Namespace;
        public void GetMyType()
        {
            Console.WriteLine(myType);
        }
    }
}
