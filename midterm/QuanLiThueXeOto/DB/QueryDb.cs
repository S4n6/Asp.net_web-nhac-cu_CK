using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThueXeOto.DB
{
    public class QueryDb
    {
        private string connectionString;

        public QueryDb()
        {
            // Tạo chuỗi kết nối từ thông tin được truyền vào
            connectionString = $"Server=DESKTOP-KQGV35N;Database=QLOTO;Trusted_Connection=True;";
        }

        public DataTable ExecuteQuery(string sqlQuery, SqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(new SqlParameter(parameter.ParameterName, parameter.Value));
                }

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }

                connection.Close();
            }

            return dataTable;
        }

        public int ExecuteNonQuery(string sqlQuery, SqlParameter[] parameters)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                rowsAffected = command.ExecuteNonQuery();

                connection.Close();
            }

            return rowsAffected;
        }
    }
}
