using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualBasic;

namespace csharp_examples
{
    class TryDateTimeParse
    {
        public static readonly List<string> formats = new List<string>
            {
                "yyyyMMddHHmmssffzzz",
            "yyyy-MM-dd HH:mm:ss.ffzzz",
            "yyyy-MM-dd HH:mm:ss.ffffff",
            "dd/MM/yyyy HH:mm:ss.ffffff",
            "ddd dd MMM yyyy h:mm tt zzz",
            "yyyy-MM-dd",
            "HH:mm:ss"
            };


        public static void DateTimeParse()
        {
            // DateTime dateTime = Parse("2023-08-22 17:17:57.720541");
            // Console.WriteLine(dateTime.ToString());
            // Console.WriteLine(dateTime.ToString("yyyy-MM-dd HH:mm:ss.ffffff"));

            string s1 = "2023081519515147-07:00";
            //String s1 = "2023-08-22 17:17:57.720541";
            
            Console.WriteLine(s1);
            DateTime dateTime1 = Parse(s1);
            Console.WriteLine(dateTime1.ToString());
            //Console.WriteLine(dateTime1.ToString("yyyy-MM-dd HH:mm:ss.ffzzz"));
            Console.WriteLine(dateTime1.ToString("yyyyMMddHHmmssffzzz"));
            Console.WriteLine(dateTime1.ToString("yyyyMMddHHmmssffzzz"), new CultureInfo("pt-BR"));
        }

        public static DateTime Parse(string str)
        {
            DateTime dateTime = default;

            foreach (string format in formats)
            {
                try
                {
                    dateTime = DateTime.ParseExact(str, format, CultureInfo.InvariantCulture);
                    Console.WriteLine("Success - " + format + " - " + CultureInfo.InvariantCulture);
                    return dateTime;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Cannot convert with format " + format + " and culture " + CultureInfo.InvariantCulture);
                }

            }

            return dateTime;

        }
    }
}
