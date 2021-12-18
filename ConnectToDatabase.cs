using System;
using System.Data.SqlClient;

namespace csharp_examples
{
    class ConnectToDatabase
    {
        public static void Connect()
        {
            Console.WriteLine("Getting Connection ...");

            var server = "localhost";
            var database = "IONATE06_INIT";
            var username = "SA";
            var password = "Welc0me@1";

            //your connection string
            string connString = @"Server=" + server + ";Database="
                + database + ";User Id=" + username + ";Password=" + password + ";";

            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();
        }
    }
}
