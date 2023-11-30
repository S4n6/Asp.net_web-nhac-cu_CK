using QuanLiThueXeOto.DB;
using QuanLiThueXeOto.Icon;
using QuanLiThueXeOto.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace QuanLiThueXeOto.Controller
{
    public class CarController
    {
        private QueryDb queryDb;

        public CarController()
        {
            queryDb = new QueryDb();
        }

        public byte[] imgToByteArr(Image image)
        {
            byte[] imageBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                imageBytes = ms.ToArray();
            }
            return imageBytes;
        }

        
        public void LoadImageToPictureBox(byte[] imageData, PictureBox pictureBox)
        {
            if (imageData != null && imageData.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image image = Image.FromStream(ms);
                    pictureBox.Image = image;
                }
            }
            else
            {
                // Nếu dữ liệu hình ảnh rỗng, bạn có thể gán một hình ảnh mặc định cho PictureBox
                pictureBox.Image = icon.iconCarCommon;
            }
        }
        public bool createCar(int seat, string brand, string type, double payment, Image image)
        {
            string insertQuery = "INSERT INTO CAR (seat, brand, type, payment, img) VALUES (@Seat, @Brand, @Type, @Payment, @Img)";

            SqlParameter[] parameters = new SqlParameter[5];

            parameters[0] = new SqlParameter("@Seat", seat);
            parameters[1] = new SqlParameter("@Brand", brand);
            parameters[2] = new SqlParameter("@Type", type);
            parameters[3] = new SqlParameter("@Payment", payment);

            if (image != null)
            {
                parameters[4] = new SqlParameter("@Img", imgToByteArr(image));
            }
            else
            {
                parameters[4] = new SqlParameter("@Img", imgToByteArr(icon.iconCarCommon));
            }

            int rowsAffected = queryDb.ExecuteNonQuery(insertQuery, parameters);
            if(rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public List<Car> getCars()
        {
            List<Car> carList = new List<Car>();

            string sqlQuery = "SELECT id, seat, brand, type, timeRentStart, timeRentEnd, payment, img FROM CAR";
            SqlParameter[] parameters = new SqlParameter[0];

            QueryDb queryDb = new QueryDb();

            DataTable dataTable = queryDb.ExecuteQuery(sqlQuery, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                DateTime? timeRentStart;
                DateTime? timeRentEnd;
                int id = Convert.ToInt32(row["id"]);
                int seat = Convert.ToInt32(row["seat"]);
                string brand = row["brand"].ToString();
                string type = row["type"].ToString();
                if (!row.IsNull("timeRentStart") && !row.IsNull("timeRentEnd"))
                {
                    timeRentStart = Convert.ToDateTime(row["timeRentStart"]);
                    timeRentEnd = Convert.ToDateTime(row["timeRentEnd"]);
                }
                else
                {
                    timeRentStart = null;
                    timeRentEnd = null;
                }
                
                double payment = Convert.ToDouble(row["payment"]);
                byte[] img = (byte[])row["img"];

                Car car = new Car(id, seat, brand, type, payment, timeRentStart, timeRentEnd, img);
                carList.Add(car);
            }

            return carList;
        }

        public Car getCarById(int id)
        {
            List<Car> carList = new List<Car>();

            string sqlQuery = "SELECT * FROM CAR WHERE id = @id";
            SqlParameter[] parameters ={ new SqlParameter("@id", id)};

            QueryDb queryDb = new QueryDb();

            DataTable dataTable = queryDb.ExecuteQuery(sqlQuery, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                DateTime? timeRentStart;
                DateTime? timeRentEnd;
                int idCar = Convert.ToInt32(row["id"]);
                int seat = Convert.ToInt32(row["seat"]);
                string brand = row["brand"].ToString();
                string type = row["type"].ToString();
                if (!row.IsNull("timeRentStart") && !row.IsNull("timeRentEnd"))
                {
                    timeRentStart = Convert.ToDateTime(row["timeRentStart"]);
                    timeRentEnd = Convert.ToDateTime(row["timeRentEnd"]);
                }
                else
                {
                    timeRentStart = null;
                    timeRentEnd = null;
                }

                double payment = Convert.ToDouble(row["payment"]);
                byte[] img = (byte[])row["img"];

                return new Car(id, seat, brand, type, payment, timeRentStart, timeRentEnd, img);
                
            }

            return null;
        }

        public List<Car> searchCar(string type, string brand, int seat )
        {
            List<Car> carList = getCars();
            var query = carList.AsQueryable();
            if (seat > 1)
            {
                query = query.Where(car => car.Seat == seat);
            }

            if (!string.IsNullOrEmpty(brand))
            {
                query = query.Where(car => car.Brand.ToLower().Contains(brand.ToLower()));
            }

            if (!string.IsNullOrEmpty(type))
            {
                query = query.Where(car => car.Type.ToLower().Contains(type.ToLower()));
            }

         
            return query.ToList();
        }

        public bool updateCar(int seat, string brand, string type, double payment, byte[] img, int id)
        {
            string queryString = "UPDATE CAR SET seat = @Seat, brand = @Brand, type = @Type, " +
               "payment = @Payment WHERE id = @Id";
            if (img != null)
            {
                queryString = "UPDATE CAR SET seat = @Seat, brand = @Brand, type = @Type, " +
               "payment = @Payment, img = @Img WHERE id = @Id";
            }

    
            List<SqlParameter> parameterList = new List<SqlParameter>();
            parameterList.Add(new SqlParameter("@Seat", seat));
            parameterList.Add(new SqlParameter("@Brand", brand));
            parameterList.Add(new SqlParameter("@Type", type));
            parameterList.Add(new SqlParameter("@Payment", payment));

            if (img != null)
            {
                parameterList.Add(new SqlParameter("@Img", img));
            }

            parameterList.Add(new SqlParameter("@Id", id));

            SqlParameter[] parameters = parameterList.ToArray();
            int rowsAffected = queryDb.ExecuteNonQuery(queryString, parameters);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool deleteCar(int id)
        {
            string sqlQuery = "DELETE FROM CAR WHERE id = @id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", id)
            };

            return queryDb.ExecuteNonQuery(sqlQuery, parameters) > 0;
        }

        

    }
}
