using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestruantRepository
{
    public class DataBaseConnectionClass
    {
        private SqlConnection myConnection;
        private SqlCommand myCommand;

        public DataBaseConnectionClass()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Komol\Desktop\FinalProject\VERSION_9\RestruantManagementSystem\RMDB.mdf;Integrated Security=True;Connect Timeout=30";
            myConnection = new SqlConnection(connectionString);
        }
        public void ConnectWithDB()
        {
            myConnection.Open();
        }
        public void CloseConnection()
        {
            myConnection.Close();
        }
        public SqlDataReader GetData(string query)
        {
            myCommand = new SqlCommand(query, myConnection);
            return myCommand.ExecuteReader();
           
        }
        public int ExecuteSQL(string query)
        {
            myCommand = new SqlCommand(query, myConnection);
           
            return myCommand.ExecuteNonQuery();
        }
    }
}
