using QuanLiThueXeOto.DB;
using QuanLiThueXeOto.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLiThueXeOto.Controller
{
    public class OrderController
    {
        private QueryDb queryDb;

        public OrderController()
        {
            queryDb = new QueryDb();
        }

        public bool addOrder(OrderCar orderCar)
        {
            string sqlQuery = "INSERT INTO ORDERCAR  (idCar, idCustomer, payMent, timeStart, timeEnd, locationStart, locationEnd, carBack) " +
                "VALUES (@carId, @customerId, @payMent, @timeStart, @timeEnd, @locationStart, @locationEnd, @carBack)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@carId", orderCar.carId),
                new SqlParameter("@customerId", orderCar.customerId),
                new SqlParameter("@payMent", orderCar.payMent),
                new SqlParameter("@timeStart", orderCar.timeStart),
                new SqlParameter("@timeEnd", orderCar.timeEnd),
                new SqlParameter("@locationStart", orderCar.locationStart),
                new SqlParameter("@locationEnd", orderCar.locationEnd),
                new SqlParameter("@carBack", orderCar.carBack)

            };

            return queryDb.ExecuteNonQuery(sqlQuery, parameters) > 0;
        }

        public bool deleteOrder(int id)
        {
            string sqlQuery = "DELETE FROM ORDERCAR WHERE id = @id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", id)
            };

            return queryDb.ExecuteNonQuery(sqlQuery, parameters) > 0;
        }

        public List<OrderCar> getOrders()
        {
            List<OrderCar> orderCars = new List<OrderCar>();

            // SQL query to retrieve customer data
            string sqlQuery = "SELECT * FROM ORDERCAR";
            SqlParameter[] parameters = new SqlParameter[0];
            // Execute the query and get the result as a DataTable
            DataTable dataTable = queryDb.ExecuteQuery(sqlQuery, parameters);
            foreach (DataRow row in dataTable.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                int carId = Convert.ToInt32(row["idCar"]);
                int customerId = Convert.ToInt32(row["idCustomer"]);
                double payment = Convert.ToDouble(row["payment"]);
                string locationStart = row["locationStart"].ToString();
                string locationEnd = row["locationEnd"].ToString();
                DateTime timeStart = Convert.ToDateTime(row["timeStart"]);
                DateTime timeEnd = Convert.ToDateTime(row["timeEnd"]);
                bool carBack = Convert.ToBoolean(row["carBack"]);

                OrderCar orderCar = new OrderCar(id, carId, customerId, payment, locationStart, locationEnd, timeStart, timeEnd, carBack);
                orderCars.Add(orderCar);
            }

            return orderCars;
        }

        public OrderCar getOrderById(int id)
        {
            // SQL query to retrieve customer data
            string sqlQuery = "SELECT * FROM ORDERCAR WHERE id = @id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", id),
            };
            // Execute the query and get the result as a DataTable
            DataTable dataTable = queryDb.ExecuteQuery(sqlQuery, parameters);
            foreach (DataRow row in dataTable.Rows)
            {
                int carId = Convert.ToInt32(row["idCar"]);
                int customerId = Convert.ToInt32(row["idCustomer"]);
                double payment = Convert.ToDouble(row["payment"]);
                string locationStart = row["locationStart"].ToString();
                string locationEnd = row["locationEnd"].ToString();
                string timeStartStr = row["timeStart"].ToString();
                DateTime timeStart = DateTime.ParseExact(timeStartStr, "MMM dd yyyy hh:mmtt", CultureInfo.InvariantCulture);
                string timeEndStr = row["timeStart"].ToString();
                DateTime timeEnd = DateTime.ParseExact(timeEndStr, "MMM dd yyyy hh:mmtt", CultureInfo.InvariantCulture);
  

                bool carBack = Convert.ToBoolean(row["carBack"]);

                return new OrderCar(id, carId, customerId, payment, locationStart, locationEnd, timeStart, timeEnd, carBack);
                
            }

            return null;
        }

        public List<OrderCar> getOrdersByCustomerId(int id)
        {
            List <OrderCar> orders = new List < OrderCar >();

            string sqlQuery = "SELECT * FROM ORDERCAR WHERE idCustomer = @id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", id),
            };

            DataTable dataTable = queryDb.ExecuteQuery(sqlQuery, parameters);
            foreach (DataRow row in dataTable.Rows)
            {
                int carId = Convert.ToInt32(row["idCar"]);
                int customerId = Convert.ToInt32(row["idCustomer"]);
                double payment = Convert.ToDouble(row["payment"]);
                string locationStart = row["locationStart"].ToString();
                string locationEnd = row["locationEnd"].ToString();
                string timeStartStr = row["timeStart"].ToString();
                DateTime timeStart = DateTime.ParseExact(timeStartStr, "MMM dd yyyy hh:mmtt", CultureInfo.InvariantCulture);
                string timeEndStr = row["timeStart"].ToString();
                DateTime timeEnd = DateTime.ParseExact(timeEndStr, "MMM dd yyyy hh:mmtt", CultureInfo.InvariantCulture);
                //DateTime timeStart = (DateTime)(row["timeStart"]);
                //DateTime timeEnd = (DateTime)(row["timeEnd"]);

                bool carBack = Convert.ToBoolean(row["carBack"]);

                orders.Add(new OrderCar(id, carId, customerId, payment, locationStart, locationEnd, timeStart, timeEnd, carBack));

            }

            return orders;
        }

        public bool deleteOrderById(int id)
        {
            string sqlQuery = "DELETE FROM ORDERCAR WHERE id = @id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", id)
            };

            return queryDb.ExecuteNonQuery(sqlQuery, parameters) > 0;
        }

        public List<OrderCar> getOrdersByCarId(int id)
        {
            List <OrderCar> orders = new List < OrderCar >();
            string sqlQuery = "SELECT * FROM ORDERCAR WHERE idCar = @id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", id)
            };
            DataTable dataTable = queryDb.ExecuteQuery(sqlQuery, parameters);
            foreach (DataRow row in dataTable.Rows)
            {
                int carId = Convert.ToInt32(row["idCar"]);
                int customerId = Convert.ToInt32(row["idCustomer"]);
                double payment = Convert.ToDouble(row["payment"]);
                string locationStart = row["locationStart"].ToString();
                string locationEnd = row["locationEnd"].ToString();
                DateTime timeStart = (DateTime)(row["timeStart"]);
                DateTime timeEnd = (DateTime)(row["timeEnd"]);

                bool carBack = Convert.ToBoolean(row["carBack"]);

                orders.Add(new OrderCar(id, carId, customerId, payment, locationStart, locationEnd, timeStart, timeEnd, carBack));

            }
            return orders;
        }

        public bool updateStatusOrder(int id)
        {
            string sqlQuery = "UPDATE ORDERCAR SET carBack = @carBack WHERE id = @id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@carBack", true),
                new SqlParameter("@id", id)

            };

            return queryDb.ExecuteNonQuery(sqlQuery, parameters) > 0;
        }

        public List<string> getQuantityOrderByBrand()
        {
            string sqlQuery = "SELECT CAR.brand, COUNT(ORDERCAR.id) AS TotalCount " +
                  "FROM ORDERCAR " +
                  "INNER JOIN CAR ON ORDERCAR.idCar = CAR.id " +
                  "WHERE ORDERCAR.carBack = 1 " +
                  "GROUP BY CAR.brand";
            List<string> brandTotalList = new List<string>();

            SqlParameter[] parameters = new SqlParameter[0];
            DataTable dataTable = queryDb.ExecuteQuery(sqlQuery, parameters);
            foreach (DataRow row in dataTable.Rows)
            {
                string brand = row["brand"].ToString();
                string totalCount = Convert.ToInt32(row["TotalCount"]).ToString();
                string brandTotal = $"{brand}-{totalCount}";
                brandTotalList.Add(brandTotal);

            }
            return brandTotalList;
        }

        public List<string> getRevenueByTime(int month, int year)
        {
            List<string> res = new List<string>();
           

            if(month < 1)
            {
                string sqlQuery = @"SELECT 
                            MONTH(timeStart) AS Month,
                            SUM(payment) AS TotalPayment
                        FROM 
                            ORDERCAR
                        WHERE 
                            YEAR(timeStart) = @Year AND ORDERCAR.carBack = 1
                        GROUP BY 
                            YEAR(timeStart), MONTH(timeStart)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Year", year)
                };
                DataTable dataTable = queryDb.ExecuteQuery(sqlQuery, parameters);
                foreach (DataRow row in dataTable.Rows)
                {
                    int resultMonth = Convert.ToInt32(row["Month"]);
                    decimal totalPayment = Convert.ToDecimal(row["TotalPayment"]);
                    string result = $"{resultMonth}-{year}:{totalPayment}";
                   
                    res.Add(result);
                }

            }
            else
            {
                string sqlQuery = @"SELECT 
                            MONTH(timeStart) AS Month,
                            YEAR(timeStart) AS Year,
                            SUM(payment) AS TotalPayment
                        FROM 
                            ORDERCAR
                        WHERE 
                            YEAR(timeStart) = @Year 
                            AND MONTH(timeStart) = @Month
                            AND ORDERCAR.carBack = 1
                        GROUP BY 
                            YEAR(timeStart), MONTH(timeStart)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Month", month),
                    new SqlParameter("@Year", year)
                };
                DataTable dataTable = queryDb.ExecuteQuery(sqlQuery, parameters);
                foreach (DataRow row in dataTable.Rows)
                {
                    int resultMonth = Convert.ToInt32(row["Month"]);
                    int resultYear = Convert.ToInt32(row["Year"]);
                    decimal totalPayment = Convert.ToDecimal(row["TotalPayment"]);
                    string result = $"{resultMonth}-{resultYear}:{totalPayment}";
                    
                    res.Add(result);
                }
            }
            

            return res;
        }

        public string getPayMentByTime(string startDate, string endDate)
        {
            string totalPayment = "0";
            int orderCarCount = 0;
            string sqlQuery = @"SELECT COUNT(*) AS OrderCarCount,
                                SUM(payment) AS TotalPayment
                            FROM 
                                ORDERCAR
                            WHERE 
                                timeStart > CONVERT(DATETIME, '" + startDate + "', 103) AND timeStart < CONVERT(DATETIME, '" + endDate + "', 103) AND carBack = 1";
    
            SqlParameter[] parameters = new SqlParameter[0];
            DataTable dataTable = queryDb.ExecuteQuery(sqlQuery, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                orderCarCount = Convert.ToInt32(row["OrderCarCount"]);
                if (!row.IsNull("TotalPayment"))
                {
                    totalPayment = row["TotalPayment"].ToString();
                }
            }


            return orderCarCount+"#"+totalPayment;
        }

        public List<string> getQuantityOrderByBrandType(string brand, string type)
        {
            string sqlQuery = "SELECT COUNT(ORDERCAR.id) AS TotalCount, SUM(ORDERCAR.payment) AS TotalPayment " +
                              "FROM ORDERCAR " +
                              "INNER JOIN CAR ON ORDERCAR.idCar = CAR.id " +
                              "WHERE ORDERCAR.carBack = 1 AND (CAR.brand = @brand OR CAR.type = @type) " +
                              "GROUP BY CAR.brand";

            List<string> brandTotalList = new List<string>();

            SqlParameter[] parameters;
            if (!string.IsNullOrEmpty(brand) && !string.IsNullOrEmpty(type))
            {
                sqlQuery = sqlQuery.Replace("@brand", "'" + brand + "'").Replace("@type", "'" + type + "'");
            }
            else if (!string.IsNullOrEmpty(brand))
            {
                sqlQuery = sqlQuery.Replace("@brand", "'" + brand + "'").Replace("OR CAR.type = @type", "");
            }
            else if (!string.IsNullOrEmpty(type))
            {
                sqlQuery = sqlQuery.Replace("CAR.brand = @brand OR", "").Replace("@type", "'" + type + "'");
            }
            else
            {
                sqlQuery = sqlQuery.Replace("@brand", "CAR.brand").Replace("@type", "CAR.type");
            }

            parameters = new SqlParameter[0];
            DataTable dataTable = queryDb.ExecuteQuery(sqlQuery, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                string totalCount = row["TotalCount"].ToString();
                string totalPayment = row["TotalPayment"].ToString();
                string brandTotal = $"{totalCount}-{totalPayment}";
                brandTotalList.Add(brandTotal);
            }

            return brandTotalList;
        }

    }
}
