using System;
using System.Data.SqlClient;

namespace csharp_examples
{
    class CreateBatchWork
    {

        public static readonly string BATCH_NUMBERS_INSERT_QUERY = "INSERT INTO dbo.PPLB2_BATCH_NUMBERS "
                        + "(PROCESS_NUMBER,JOB_NAME,CODER_ID,BATCH_NUMBER, STATUS_CODE) "
                        + " VALUES "
                        + " (@processnumber,@jobname,@coderid,@batchnumber, @statuscode)";

        public static readonly string WORK_STATUS_INSERT_QUERY = "INSERT INTO dbo.PPLB2_WORK_STATUS "
                        + "(PROCESS_NUMBER,JOB_NAME,CODER_ID,BATCH_NUMBER, REQUEST_ID, WORKER_ID, SERVER_NAME, "
                        + "STATUS_CODE, SERVER_PID, STATUS_MESSAGE, COMPANY_CODE, POLICY_NUMBER, DATE_SUBMITTED, "
                        + "DATE_PROCESSED, ADDITIONAL_PARMS)"
                        + " VALUES "
                        + "(@processnumber,@jobname,@coderid,@batchnumber, @requestid, @workerid, @servername, "
                        + "@statuscode, @serverpid, @statusmessage, @companycode, @policynumber, @datesubmitted, "
                        + "@dateprocessed, @additionalparms)";

        public int ProcessNumber { get; set; }
        public int NumBatchEntries { get; set; }
        public string JobName { get; set; }
        public string CoderId { get; set; }
        public int StatusCode { get; set; }
        public int WorkerId { get; set; }
        public string CompanyCode { get; set; }
        public string ServerName { get; set; }
        public int ServerPid { get; set; }
        public string StatusMessage { get; set; }
        public string PolicyNumberPrefix { get; set; }

        public CreateBatchWork()
        {
            ProcessNumber = 100;
            NumBatchEntries = 10000;
            JobName = "PAC";
            CoderId = "APD1";
            StatusCode = -1;
            CompanyCode = "01";
            PolicyNumberPrefix = "POLICY";
            WorkerId = 0;
            ServerName = "Kubernetes";
            ServerPid = 0;
            StatusMessage = "Created";
        }

        public void CreateWork()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "localhost";
                builder.UserID = "SA";
                builder.Password = "Welc0me@1";
                builder.InitialCatalog = "IONATE06_INIT";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    Console.WriteLine("Openning Connection ...");

                    //open connection
                    connection.Open();
                    Console.WriteLine("Connection successful!");


                    for (int i = 0; i < NumBatchEntries; i++)
                    {
                        int batchNumber = i + 1;
                        string policyNumber = PolicyNumberPrefix + i;
                        string additionalParms = CompanyCode + " " + policyNumber + " " + DateTime.Now.ToString();

                        SqlCommand batchCommand = new SqlCommand(BATCH_NUMBERS_INSERT_QUERY, connection);
                        batchCommand.Parameters.Add("@processnumber", System.Data.SqlDbType.SmallInt).Value = ProcessNumber;
                        batchCommand.Parameters.Add("@jobname", System.Data.SqlDbType.NChar).Value = JobName;
                        batchCommand.Parameters.Add("@coderid", System.Data.SqlDbType.Char).Value = CoderId;
                        batchCommand.Parameters.Add("@batchnumber", System.Data.SqlDbType.Int).Value = batchNumber;
                        batchCommand.Parameters.Add("@statuscode", System.Data.SqlDbType.SmallInt).Value = StatusCode;

                        Console.WriteLine("Adding batchNumber " + batchNumber);
                        batchCommand.ExecuteNonQuery();

                        SqlCommand workStatusCommand = new SqlCommand(WORK_STATUS_INSERT_QUERY, connection);
                        workStatusCommand.Parameters.Add("@processnumber", System.Data.SqlDbType.SmallInt).Value = ProcessNumber;
                        workStatusCommand.Parameters.Add("@jobname", System.Data.SqlDbType.NChar).Value = JobName;
                        workStatusCommand.Parameters.Add("@coderid", System.Data.SqlDbType.Char).Value = CoderId;
                        workStatusCommand.Parameters.Add("@batchnumber", System.Data.SqlDbType.Int).Value = batchNumber;
                        workStatusCommand.Parameters.Add("@requestid", System.Data.SqlDbType.Int).Value = batchNumber;
                        workStatusCommand.Parameters.Add("@workerid", System.Data.SqlDbType.Int).Value = WorkerId;
                        workStatusCommand.Parameters.Add("@servername", System.Data.SqlDbType.VarChar).Value = ServerName;
                        workStatusCommand.Parameters.Add("@statuscode", System.Data.SqlDbType.SmallInt).Value = StatusCode;
                        workStatusCommand.Parameters.Add("@serverpid", System.Data.SqlDbType.Int).Value = ServerPid;
                        workStatusCommand.Parameters.Add("@statusmessage", System.Data.SqlDbType.VarChar).Value = StatusMessage;
                        workStatusCommand.Parameters.Add("@companycode", System.Data.SqlDbType.Char).Value = CompanyCode;
                        workStatusCommand.Parameters.Add("@policynumber", System.Data.SqlDbType.NChar).Value = policyNumber;
                        workStatusCommand.Parameters.Add("@datesubmitted", System.Data.SqlDbType.DateTime).Value = DateTime.Now;
                        workStatusCommand.Parameters.Add("@dateprocessed", System.Data.SqlDbType.DateTime).Value = DateTime.Now;
                        workStatusCommand.Parameters.Add("@additionalparms", System.Data.SqlDbType.VarChar).Value = additionalParms;

                        Console.WriteLine("Adding workStatus for " + batchNumber);
                        workStatusCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        
        
    }
}
