using QuanLiThueXeOto.Controller;
using QuanLiThueXeOto.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLiThueXeOto.View
{
    public partial class HomeUI : UserControl
    {
        OrderController orderController;
        CarController carController;
        public HomeUI()
        {
            InitializeComponent();
            orderController = new OrderController();
            carController = new CarController();
        }

        private void HomeUI_Load(object sender, EventArgs e)
        {
            List<string> totalByBrand = orderController.getQuantityOrderByBrand();
            
            foreach (string brandTotal in totalByBrand)
            {
                string brand = brandTotal.Split('-')[0];
                int total = int.Parse(brandTotal.Split('-')[1]);
                chartBrand.Series["Số lượng"].Points.AddXY(brand, total);
            }

            loadComboBox();
            loadChartTime();
            loadNumberStatic();
        }

        private void timeChart_ValueChanged(object sender, EventArgs e)
        {

            loadChartTime();
            
        }

        private void loadChartTime()
        {
            string selectedMonthYear = timeChart.Value.ToString("MM/yyyy");
            DateTime selectedDateTime = DateTime.Parse(selectedMonthYear);

            int selectedMonth = selectedDateTime.Month;
            int selectedYear = selectedDateTime.Year;

            chartTime.Series["Doanh thu"].Points.Clear();

            List<string> revenueByTime = orderController.getRevenueByTime(0, selectedYear);

            foreach (string revenue in revenueByTime)
            {
                
                string time = revenue.Split(':')[0];
                double total = double.Parse(revenue.Split(':')[1]);
                chartTime.Series["Doanh thu"].Points.AddXY(time, total);
            }



        }

        private void loadNumberStatic()
        {
            string selectedtimeStart = new DateTime(timeStart.Value.Year, timeStart.Value.Month, timeStart.Value.Day).ToString("dd/MM/yyyy");
            string selectedtimeEnd = new DateTime(timeEnd.Value.Year, timeEnd.Value.Month, timeEnd.Value.Day).ToString("dd/MM/yyyy");
            string res = orderController.getPayMentByTime(selectedtimeStart, selectedtimeEnd);
            string quantity = res.Split('#')[0];
            string total = res.Split('#')[1];
            lbQuantityTime.Text = quantity;
            lbRevenueTime.Text = total;


            
        }

        private void loadNumberStaticBrandType(string brand, string type)
        {
            List<string> strings = orderController.getQuantityOrderByBrandType(brand, type);
            string count = "0";
            string total = "0";
            foreach (string item in strings)
            {
                count = item.Split('-')[0];
                total = item.Split('-')[1];
                if(!string.IsNullOrEmpty(brand))
                {
                    lbQuantityBrand.Text = count;
                    lbRevenueBrand.Text = total;
                }
                else
                {
                    lbQuantityType.Text = count;
                    lbRevenueType.Text = total;
                }
            }

        }

        private void loadComboBox()
        {
            List<Car> cars = carController.getCars();
            HashSet<string> uniqueBrands = new HashSet<string>();
            HashSet<string> uniqueType = new HashSet<string>();

            foreach (Car car in cars) {
                if (!string.IsNullOrEmpty(car.Brand) && !uniqueBrands.Contains(car.Brand))
                {
                    cbBrand.Items.Add(car.Brand);
                    uniqueBrands.Add(car.Brand);
                }

                if (!string.IsNullOrEmpty(car.Type) && !uniqueType.Contains(car.Type))
                {
                    cbType.Items.Add(car.Type);
                    uniqueType.Add(car.Type);
                }
            }
        }

        private void timeStart_ValueChanged(object sender, EventArgs e)
        {
            loadNumberStatic();
        }

        private void timeEnd_ValueChanged(object sender, EventArgs e)
        {
            loadNumberStatic();

        }

        private void cbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBrand.SelectedIndex != -1)
            {
                string selectedValue = cbBrand.SelectedItem.ToString();
                loadNumberStaticBrandType(selectedValue, null);
            }
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbType.SelectedIndex != -1)
            {
                string selectedValue = cbType.SelectedItem.ToString();
                loadNumberStaticBrandType(null, selectedValue);
            }
        }

        private void chartBrand_Click(object sender, EventArgs e)
        {

        }
    }
}
