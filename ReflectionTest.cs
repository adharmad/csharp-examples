using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Reflection;

namespace csharp_examples
{
    class ReflectionTest
    {
        private static Random random = new Random();

        public static void ReflectMultipleTimes()
        {
            long time1 = 0L;
            long time2 = 0L;
            long elapsed = 0;

            for (int i=0 ; i<1000 ; i++)
            {
                string s1 = RandomAlphaString(8);
                string s2 = RandomAlphaString(8);
                string s3 = RandomAlphaString(8);
                int rand = RandomInt(256);

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                //object ret1 = InvokeMethod("csharp_examples.Test1", "Method1", new object[]{rand, s1, s2});
                object ret1 = new Test1().Method1(rand, s1, s2);
                stopWatch.Stop();
                elapsed = stopWatch.ElapsedTicks;
                time1 += elapsed;
                Console.WriteLine("call to Test1->Method1 time = " + elapsed);
                //Console.WriteLine("ret1 = " + ret1.ToString());

                stopWatch = new Stopwatch();
                stopWatch.Start();
                //object ret2 = InvokeMethod("csharp_examples.Test2", "Method2", new object[]{rand, s1, s2, s3});
                object ret2 = new Test2().Method2(rand, s1, s2, s3);
                stopWatch.Stop();
                elapsed = stopWatch.ElapsedTicks;
                time2 += elapsed;
                Console.WriteLine("call to Test2->Method2 time = " + elapsed);
                //Console.WriteLine("ret2 = " + ret2.ToString());
            }

            Console.WriteLine("time1 = " + time1 + " average = " + (time1/100000));
            Console.WriteLine("time2 = " + time2 + " average = " + (time2/100000));
        }

        public static object InvokeMethod(string className, string methodName, object[] parameters)
        {
            Type reflType = Type.GetType(className);
            ConstructorInfo reflConstructor = reflType.GetConstructor(Type.EmptyTypes);
            object objRef = reflConstructor.Invoke(new object[] { });

            MethodInfo reflMethod = reflType.GetMethod(methodName);
            ParameterInfo[] reflMethodParamInfos = reflMethod.GetParameters();

            object reflValue = reflMethod.Invoke(objRef, parameters);
            return reflValue;
        }

        public static string RandomAlphaString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static int RandomInt(int max)
        {
            int randLong = random.Next();
            int ret = Convert.ToInt32(randLong % max);

            return ret;
        }
    }


    class Test1
    {
        public Test1() {}
        public object Method1(int num, string s1, string s2)
        {
            //Console.WriteLine("s1 = " + s1 + ", s2 = " + s2);
            Func<int, int> factorial = null; // Just so we can refer to it
            factorial = x => x <= 1 ? 1 : x * factorial(x-1);
            int sumFact = 0;

            for (int i=1 ; i<num ; i++)
            {
                sumFact += factorial(i);
            }
            return s1 + "-" + s2 + "+" + sumFact;
        }
    }

    class Test2
    {
        public Test2() {}
        public object Method2(int num, string s1, string s2, string s3)
        {
            //Console.WriteLine("s1 = " + s1 + ", s2 = " + s2 + ", s3 = " + s3);
            Func<int, int> factorial = null; // Just so we can refer to it
            factorial = x => x <= 1 ? 1 : x * factorial(x-1);
            int sumFact = 0;

            for (int i=1 ; i<num ; i++)
            {
                sumFact += factorial(i);
            }

            return s1 + "-" + s2 + "-" + s3 + "+" + sumFact;
        }
    }

}
