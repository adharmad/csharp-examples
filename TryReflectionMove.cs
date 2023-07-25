using System;
using System.Reflection;

namespace csharp_examples
{
    public class TryReflectionMove
    {
        public static void MoveViaReflection()
        {
            AObject aObject = new AObject("hello", 11, 22.33);
            Console.WriteLine(aObject.ToString());
            BObject bObject = new BObject("", 0, 0.0);
            Console.WriteLine(bObject.ToString());

            Type aType = aObject.GetType();
            Type bType = bObject.GetType();
            PropertyInfo[] props = aType.GetProperties();
            foreach (var prop in props)
            {
                string aPropName = prop.Name;
                PropertyInfo bProp = bType.GetProperty(aPropName);

                if (bProp != null)
                {
                    object aPropValue = prop.GetValue(aObject);
                    bProp.SetValue(bObject, aPropValue);
                }

                //Console.WriteLine(prop.Name + " : " + prop.GetValue(aObject));

            }

            Console.WriteLine(bObject.ToString());
            

        }
    }

    public class AObject
    {
        public string StrField { get; set; }
        public long LongField { get; set; }
        public double DoubleField { get; set; }

        public AObject(string strField, long longField, double doubleField)
        {
            StrField = strField;
            LongField = longField;
            DoubleField = doubleField;
        }

        public override string ToString()
        {
            return StrField + " " + LongField + " " + DoubleField;
        }
    }

    public class BObject
    {
        public string StrField { get; set; }
        public long LongField { get; set; }
        public double DoubleField { get; set; }

        public BObject(string strField, long longField, double doubleField)
        {
            StrField = strField;
            LongField = longField;
            DoubleField = doubleField;
        }

        public override string ToString()
        {
            return StrField + " " + LongField + " " + DoubleField;
        }        
    }

}
