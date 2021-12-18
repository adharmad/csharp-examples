using System;
using System.Data.SqlClient;

namespace csharp_examples
{
    class ExecuteSelectQuery
    {
        public static void ExecuteQuery()
        {

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "localhost";
                builder.UserID = "SA";
                builder.Password = "Welc0me@1";
                builder.UserID = "SA";
                builder.InitialCatalog = "IONATE06_INIT";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    String sql = "SELECT POLICY_NUMBER, PRODUCT_CODE FROM PPOLC";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }


            Console.ReadLine();
        }
    }
}
