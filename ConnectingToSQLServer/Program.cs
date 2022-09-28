using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace ConnectingToSQLServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Connection ...");

            var datasource = @"DESKTOP-T520T9B\SQLEXPRESS";//your server
            var database = "Students"; //your database name
            //var username = "sa"; //username of server to connect
            //var password = "password"; //password
            //your connection string 
            string connString = @"Server=" + datasource + ";database="
                        + database + ";Integrated Security= True;";



            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);


            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append("INSERT INTO Student_details (Name, Email, Class) VALUES ");
                strBuilder.Append("('Neha', 'neha@gmail.com', 'Class X'), ");
                strBuilder.Append("('Shivam', 'shivam@gmail.com', 'Class X') ");

                string sqlQuery = strBuilder.ToString();
                using (SqlCommand command = new SqlCommand(sqlQuery, conn)) //pass SQL query created above and connection
                {
                    command.ExecuteNonQuery(); //execute the Query
                    Console.WriteLine("Query Executed.");
                }
                strBuilder.Clear();

                strBuilder.Append("UPDATE Student_details SET Email = 'sandy@gmail.com' WHERE Name = 'Shivam'");
                sqlQuery = strBuilder.ToString();
                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {
                    int rowsAffected = command.ExecuteNonQuery(); //execute query and get updated row count
                    Console.WriteLine(rowsAffected + " row(s) updated");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();
        }
    }
}

