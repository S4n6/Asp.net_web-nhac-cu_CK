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
    public class CustomerController
    {
        private QueryDb queryDb;

        public CustomerController()
        {
            queryDb = new QueryDb();
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            // SQL query to retrieve customer data
            string sqlQuery = "SELECT id, name, birthDay, address, phone FROM CUSTOMER";
            SqlParameter[] parameters = new SqlParameter[0];
            // Execute the query and get the result as a DataTable
            DataTable dataTable = queryDb.ExecuteQuery(sqlQuery, parameters);

            // Iterate through each row in the DataTable
            foreach (DataRow row in dataTable.Rows)
            {
                // Create a new Customer object and populate its properties

                int id = Convert.ToInt32(row["id"]);
                string name = row["name"].ToString();
                DateTime birthDay = Convert.ToDateTime(row["birthDay"]);
                string address = row["address"].ToString();
                string phone = row["phone"].ToString();


                Customer customer = new Customer(id, name, birthDay, address, phone);
                customers.Add(customer);
            }

            return customers;
        }

        public Customer GetCustomerById(int id)
        {
            // SQL query to retrieve customer data
            string sqlQuery = "SELECT * FROM CUSTOMER WHERE id = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", id) };
            // Execute the query and get the result as a DataTable
            DataTable dataTable = queryDb.ExecuteQuery(sqlQuery, parameters);

            // Iterate through each row in the DataTable
            foreach (DataRow row in dataTable.Rows)
            {
                string name = row["name"].ToString();
                DateTime birthDay = Convert.ToDateTime(row["birthDay"]);
                string address = row["address"].ToString();
                string phone = row["phone"].ToString();


                return new Customer(id, name, birthDay, address, phone);
                
            }

            return null;
        }

        public List<Customer> SearchCustomer(string name, string phone, string address)
        {
            List<Customer> customerList = GetCustomers();
            var query = customerList.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(customer => customer.name.Contains(name));
            }

            if (!string.IsNullOrEmpty(phone))
            {
                query = query.Where(customer => customer.phone.Contains(phone));
            }

            if (!string.IsNullOrEmpty(address))
            {
                query = query.Where(customer => customer.address.Contains(address));
            }

            return query.ToList();
        }

        public bool AddCustomer(string name, DateTime birthDay, string address, string phone)
        {
            string sqlQuery = "INSERT INTO CUSTOMER (name, birthDay, address, phone) VALUES (@name, @birthDay, @address, @phone)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@name", name),
                new SqlParameter("@birthDay", birthDay),
                new SqlParameter("@address", address),
                new SqlParameter("@phone", phone)
            };

            return queryDb.ExecuteNonQuery(sqlQuery, parameters) > 0 ? true : false;
        }

        public bool UpdateCustomer(int id, string name, DateTime birthDay, string address, string phone)
        {
            string sqlQuery = "UPDATE CUSTOMER SET name = @name, birthDay = @birthDay, address = @address, phone = @phone WHERE id = @id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", id),
                new SqlParameter("@name", name),
                new SqlParameter("@birthDay", birthDay),
                new SqlParameter("@address", address),
                new SqlParameter("@phone", phone)
            };

            return queryDb.ExecuteNonQuery(sqlQuery, parameters) > 0;
        }

        public bool DeleteCustomer(int id)
        {
            string sqlQuery = "DELETE FROM CUSTOMER WHERE id = @id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", id)
            };

            return queryDb.ExecuteNonQuery(sqlQuery, parameters) > 0;
        }

        public void getPaymentByBrand()
        {
            string sqlQuery = "SELECT CAR.brand, SUM(ORDERCAR.payment) AS total_payment " +
                  "FROM ORDERCAR " +
                  "JOIN CAR ON ORDERCAR.idCar = CAR.idCar " +
                  "GROUP BY CAR.brand";

            SqlParameter[] parameters = null;

            DataTable dataTable = queryDb.ExecuteQuery(sqlQuery, parameters);


        }

    }
}
