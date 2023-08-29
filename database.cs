using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Markup;
using System.Data;
using System.Collections;

namespace WpfApp1
{
    public class database
    {
        string connectionString = "Data Source=DEV-MANAR;Initial Catalog = erp; Integrated Security = True";
        SqlConnection sqlConnection;
        public database()
        {
            sqlConnection = new SqlConnection(connectionString);
        }
        public DataTable GetColumns(string Query)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
                return dataTable;

            }
            catch(Exception E)
            {
                return null;
            }

        }
        public void Insert(string query)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch(Exception E)
            {

            }
        }
    }
}
