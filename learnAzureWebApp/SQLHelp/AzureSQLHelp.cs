using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace learnAzureWebApp.SQLHelp
{
    public class AzureSQLHelp
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        public static void openDatabase()
        {
            conn = new SqlConnection();
            //conn.ConnectionString = "Integrated Security=SSPI;Data Source=(local);initial catalog=test;User ID ='sa';password=123456";
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2012Entities"].ToString();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public static void execute(String sql)
        {
            openDatabase();
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}