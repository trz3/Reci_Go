using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_Go.Repositories
{
    public class MSSQL
    {
        private static readonly string _connectionString = @"Server=PT-AL-TOMAS\SQLEXPRESS01;Database=Reci&Go;Trusted_Connection=True;Integrated Security=True;";

        private static readonly SqlConnection _sqlConnection = new SqlConnection(_connectionString);

        private static bool _isClose = true;

        public static SqlDataReader Execute(string sql)
        {
            HangUpCall();
            SqlCommand sqlCommand = new SqlCommand(sql, _sqlConnection);
            return sqlCommand.ExecuteReader();
        }

        public static int ExecuteNonQuery(string sql)
        {
            HangUpCall();
            SqlCommand sqlCommand = new SqlCommand(sql, _sqlConnection);
            return sqlCommand.ExecuteNonQuery();
        }

        public static int GetMaxInt(string columnName, string tableName)
        {
            string sql = "SELECT max(" + columnName + ") AS MAX_ID FROM "
                + tableName + " ;";
            SqlDataReader dataReader = Execute(sql);
            if (dataReader.Read())
            {
                return Convert.ToInt32(dataReader["MAX_ID"]);
            }
            return -1;
        }

        private static void HangUpCall()
        {
            if (_isClose)
            {
                _sqlConnection.Open();
                _isClose = !_isClose;
            }
            else
            {
                _sqlConnection.Close();
                _sqlConnection.Open();
            }
        }
    }
}
