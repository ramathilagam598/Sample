using System;
using System.Data;
using System.Data.SqlClient;
namespace AdoDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "(localdb)\\MSSQLLocalDB";
            builder.InitialCatalog = "FHLMC";
            builder.IntegratedSecurity = true;
            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                SqlCommand command = new SqlCommand("Display_Name", conn);
                try
                {
                    conn.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Name",SqlDbType.VarChar,50));
                    command.Parameters[0].Value = "Edit";
                    SqlDataReader reader=command.ExecuteReader();
                    while(reader.Read())
                    {
                        Console.WriteLine(reader[0]);
                    }
                    conn.Close();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
