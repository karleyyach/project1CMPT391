using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _391project1
{
    class Database
    {
        private static readonly string DBString = "server=DESKTOP-O33F5QE;" +
                                                  "Trusted_Connection=yes;" +
                                                  "database=car-rental-agency; " +
                                                  "connection timeout=30";

        public static string connectionString { get { return DBString; } }

        public static DataTable SqlQuery(string query)
        {
            SqlConnection connection = new SqlConnection(Database.connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);

            connection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();

            dataAdapter.Fill(table);

            connection.Close();

            return table;
        }

        public static void runQuery(String query)
        {
            // Connection string
            string connectionString = Database.connectionString;

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                // Creates your command with the query
                SqlCommand command = new SqlCommand(query, sqlCon);

                // Command execution
                SqlDataReader reader = command.ExecuteReader();
            }
        }
        public static DataTable getDataTableAfterRunningQuery(String query)
        {
            // Connection string
            string connectionString = Database.connectionString;

            // Creating a data table
            DataTable table = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                // Creates your command with the query
                SqlCommand command = new SqlCommand(query, sqlCon);

                // Command execution
                SqlDataReader reader = command.ExecuteReader();

                // Loading the data table with the query result 
                table.Load(reader);
            }
            return table;
        }


        public static void SqlInsert(string query)
        {
            SqlDataReader dataReader;
            SqlCommand cmd;
            SqlConnection connection = new SqlConnection(Database.connectionString);

            try
            {
                connection.Open();
                cmd = new SqlCommand(query, connection);

                dataReader = cmd.ExecuteReader();
                while (dataReader.Read()) { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}