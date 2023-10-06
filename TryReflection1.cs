using System;
using System.Reflection;

namespace csharp_examples
{
    public class TryReflection1
    {
        public static void Reflection1()
        {
            StateObject stateObject = new StateObject();
            Type type = stateObject.GetType();
            MethodInfo methodInfo = type.GetMethod("TestMethod");
            methodInfo.Invoke(stateObject, null);

            PropertyInfo prop1 = type.GetProperty("ErrorMessage", BindingFlags.Public | BindingFlags.Instance);
            if(null != prop1 && prop1.CanWrite)
            {
                prop1.SetValue(stateObject, "HelloWorld", null);
            }

            PropertyInfo prop2 = type.GetProperty("ErrorCode", BindingFlags.Public | BindingFlags.Instance);
            if(null != prop2 && prop2.CanWrite)
            {
                prop2.SetValue(stateObject, 666, null);
            }

            Console.WriteLine(stateObject);
        }
    }

    public class StateObject
    {
        public string ErrorMessage { get; set; }
        public long ErrorCode { get; set; }

        public StateObject()
        {
        }

        public void TestMethod()
        {
            Console.WriteLine("Calling Test Method");
        }

        public override string ToString()
        {
            return $"Error Message = {ErrorMessage}, Error Code = {ErrorCode}";
        }
    }

}
