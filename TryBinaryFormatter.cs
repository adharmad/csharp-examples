using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace csharp_examples
{
    [Serializable]
    public class MyObject
    {
        public int n1 = 0;
        public int n2 = 0;
        public String str = null;
        [NonSerializedAttribute]public string testStr = "defaultval";

        public MyObject(int i1, int i2, string str1, string testStr1)
        {
            this.n1 = i1;
            this.n2 = i2;
            this.str = str1;
            this.testStr = testStr1;
        }

        public override string ToString()
        {
            return "n1=" + n1 + ", n2=" + n2 + ", str=" + str + ", testStr=" + testStr;
        }
    }


    class TryBinaryFormatter
    {
        public static void Serialize()
        {
            IFormatter formatter = new BinaryFormatter();

            MyObject obj = new MyObject(55, 99, "hello_world", "anotherstr");
            Console.WriteLine(obj.ToString());
            Stream ostream = new FileStream("obj.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(ostream, obj);
            ostream.Close();

            // Read the object
            Stream istream = new FileStream("obj.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            MyObject obj1 = (MyObject) formatter.Deserialize(istream);
            istream.Close();
            Console.WriteLine(obj1.ToString());
        }

    }
}
