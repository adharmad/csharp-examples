using System;
using System.Reflection;

namespace csharp_examples
{
    public class TryRefParamTypeViaReflection
    {
        public static void GetRefParamType()
        {
            TryRefParamTypeViaReflection obj = new TryRefParamTypeViaReflection();
            Type type = obj.GetType();
            MethodInfo methodInfo = type.GetMethod("Method1");
            ParameterInfo[] parameters = methodInfo.GetParameters();
            foreach (ParameterInfo p in parameters)
            {
                Console.WriteLine(p.ParameterType);
            }

            Console.WriteLine(methodInfo.ToString());
        }

        public void Method1(ref string str1, ref short short1, ref int int1, ref long long1, ref double double1)
        {
            Console.WriteLine("calling method1");
        }
    }
}
