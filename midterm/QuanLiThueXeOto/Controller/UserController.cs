using QuanLiThueXeOto.DB;
using QuanLiThueXeOto.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiThueXeOto.Controller
{
    public class UserController
    {
        private QueryDb queryDb;

        public UserController()
        {
            queryDb = new QueryDb();
        }

        public QTV logIn(string username, string password)
        {
            string sqlQuery = "SELECT * FROM QTV WHERE username = @username AND password = @password";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            };

            DataTable dataTable = queryDb.ExecuteQuery(sqlQuery, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                QTV qtv = new QTV(
                    row["username"].ToString(),
                    row["password"].ToString(),
                    row["fullName"].ToString(),
                    row["address"].ToString(),
                    row["phone"].ToString(),
                    row["role"].ToString()
                );
                return qtv;
            }

            return null;
        }

        public bool register(QTV qtv)
        {
            // Thực hiện câu truy vấn INSERT để chèn thông tin người dùng vào cơ sở dữ liệu
            string sqlQuery = "INSERT INTO QTV (username, password, fullName, address, phone, role) " +
                "VALUES (@username, @password, @fullName, @address, @phone, @role)";

            // Tạo mảng tham số SqlParameter
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@username", qtv.username),
                new SqlParameter("@password", qtv.password),
                new SqlParameter("@fullName", qtv.fullName),
                new SqlParameter("@address", qtv.address),
                new SqlParameter("@phone", qtv.phone),
                new SqlParameter("@role", qtv.role)
            };

            // Thực thi câu truy vấn INSERT
            int rowsAffected = queryDb.ExecuteNonQuery(sqlQuery, parameters);

            // Trả về kết quả chèn thông tin người dùng
            return rowsAffected > 0;
        }
    }
}
