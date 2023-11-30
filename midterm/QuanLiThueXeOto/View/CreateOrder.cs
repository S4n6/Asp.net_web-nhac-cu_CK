using QuanLiThueXeOto.Controller;
using QuanLiThueXeOto.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;



namespace QuanLiThueXeOto.View
{
    public partial class CreateOrder : Form
    {
        OrderController orderController;
        CarController carController;
        CustomerController customerController;
        Customer customerSelected;
        Car carSelected = null;
        List<CheckBox> cbFeatures = new List<CheckBox>();
        RadioButton rbChecked;
        double paymentRb;
        public CreateOrder()
        {
            InitializeComponent();
            orderController = new OrderController();
            carController = new CarController();
            customerController = new CustomerController();
        }

        private void CreateOrder_Load(object sender, EventArgs e)
        {
            
            AutoCompleteStringCollection dataCarMenu = new AutoCompleteStringCollection();
            AutoCompleteStringCollection dataCustomerMenu = new AutoCompleteStringCollection();
            cbCar.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbCar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            List<Car> cars = carController.getCars();
            List<Customer> customers = customerController.GetCustomers();

            for (int i = 0; i < cars.Count; i++)
            {
                Car car = cars[i];
                string carInfo = $"{car.Type}, {car.Brand}, {car.Seat}";
                dataCarMenu.Add(carInfo);
                cbCar.Items.Add(carInfo);
            }

            for (int i = 0; i < customers.Count; i++)
            {
                Customer customer = customers[i];
                string carInfo = $"{customer.name}/{customer.address}/{customer.phone}";
                dataCustomerMenu.Add(carInfo);
                cbCustomer.Items.Add(carInfo);
            }
            cbCar.AutoCompleteCustomSource = dataCarMenu;
            cbCustomer.AutoCompleteCustomSource = dataCustomerMenu;

            assignClickCheckbox();
            assignCheckRadioButton();
        }

        private void assignClickCheckbox()
        {
            foreach (Control control in pnFeature.Controls)
            {
                if (control is CheckBox checkbox)
                {
                    checkbox.CheckedChanged += Checkbox_CheckedChanged;
                   
                }
            }
        }

        private void assignCheckRadioButton()
        {
            rbAll.CheckedChanged += RbAll_CheckedChanged;
            rbDiesel.CheckedChanged += RbAll_CheckedChanged;
            rbElectric.CheckedChanged += RbAll_CheckedChanged;
            rbGas.CheckedChanged += RbAll_CheckedChanged;

        }

        private void RbAll_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            if (radioButton.Checked)
            {
                rbChecked = radioButton;
                switch (radioButton.Text)
                {
                    case "Tất cả":
                        paymentRb += 100;
                        break;
                    case "Xăng":
                        paymentRb += 50;
                        break;
                    case "Dầu diesel":
                        paymentRb += 30;
                        break;
                    case "Điện":
                        paymentRb += 20;
                        break;
                    default:

                        break;
                }

            }
            else
            {
                switch (radioButton.Text)
                {
                    case "Tất cả":
                        paymentRb -= 100;
                        break;
                    case "Xăng":
                        paymentRb -= 50;
                        break;
                    case "Dầu diesel":
                        paymentRb -= 30;
                        break;
                    case "Điện":
                        paymentRb -= 20;
                        break;
                    default:

                        break;
                }
            }
            DateTime timeStartValue = timeStart.Value;
            DateTime timeEndValue = timeEnd.Value;
            getTotal(carSelected.PayMent, timeStartValue, timeEndValue);

        }

        private void Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            DateTime timeStartValue = timeStart.Value;
            DateTime timeEndValue = timeEnd.Value;
            CheckBox clickedCheckbox = (CheckBox)sender;
            
            if (clickedCheckbox.Checked)
            {
                cbFeatures.Add(clickedCheckbox);
                getTotal(carSelected.PayMent, timeStartValue, timeEndValue);
            }
            else
            {
                cbFeatures.Remove(clickedCheckbox);
                getTotal(carSelected.PayMent, timeStartValue, timeEndValue);
            }
        }



        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (checkTime())
            {
                string locationStart = tbLocationStart.Text;
                string locationEnd = tbLocationEnd.Text;
            
                //string formattedTimeStart = timeStart.Value.ToString("dd/MM/yyyy HH:mm:ss");
                //MessageBox.Show("formattedTimeStart----" + formattedTimeStart);
                //DateTime parsedTimeStart = DateTime.Parse(formattedTimeStart);
                //string formattedTimeEnd = timeEnd.Value.ToString("dd/MM/yyyy HH:mm:ss");
                //DateTime parsedTimeEnd = DateTime.Parse(formattedTimeEnd);

    
                double payment = getTotal(carSelected.PayMent, timeStart.Value, timeEnd.Value);
                OrderCar orderCar = new OrderCar(0, carSelected.Id, customerSelected.id, payment, locationStart, locationEnd, timeStart.Value, timeEnd.Value, false);
                bool res = orderController.addOrder(orderCar);
                if (res)
                {
                    MessageBox.Show("Tạo thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tạo thất bại");

                }

            }

        }

        private double getTotal(double priceCar, DateTime startTime, DateTime endTime)
        {
            double total = 0;
            TimeSpan duration = endTime - startTime;
            double hours = duration.TotalHours;

            Dictionary<string, double> features = new Dictionary<string, double>();
            features.Add("Bản đồ", 10);
            features.Add("Camera cập lề", 20);
            features.Add("Cảm biến lốp", 30);
            features.Add("Cửa sổ trời", 40);
            features.Add("Khe cắm USB", 50);
            features.Add("Nắp thùng xe bán tải", 60);
            features.Add("Bluetooth", 70);
            features.Add("Camera hành trình", 80);
            features.Add("Cảm biến va chạm", 90);
            features.Add("Định vị GPS", 100);
            features.Add("Lốp dự phòng", 110);
            features.Add("Camera 360", 120);
            features.Add("Camera lùi", 130);
            features.Add("Cảnh báo tốc độ", 140);


            foreach (CheckBox checkbox in cbFeatures)
            {
               total += features[checkbox.Text];
            }
            total += paymentRb;
            total += priceCar * hours;
            lbTotal.Text = total.ToString() + " $";
            return total;
        }

        private void cbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cbCustomerValue = cbCustomer.Text;
            string[] customerValue = cbCustomerValue.Split('/');
            string name = customerValue[0].Trim();
            string address = customerValue[1].Trim();
            string phone = customerValue[2].Trim();

            customerSelected = customerController.SearchCustomer(name, phone, address)[0];
        }

        private void cbCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime timeStartValue = timeStart.Value;
            DateTime timeEndValue = timeEnd.Value;

            string cbCarValue = cbCar.Text;
            string[] carValue = cbCarValue.Split(',');

            string type = carValue[0].Trim();
            string brand = carValue[1].Trim();
            int seat = int.Parse(carValue[2].Trim());

            carSelected = carController.searchCar(type, brand, seat)[0];
            getTotal(carSelected.PayMent, timeStartValue, timeEndValue);


        }

        private bool checkTime()
        {
            if (timeStart.Value >= timeEnd.Value)
            {
                MessageBox.Show("Thời gian đặt xe bắt đầu và kết thúc không hợp lệ");
                return false;
            }
            else
            {
                if(timeStart.Value < DateTime.Now)
                {
                    MessageBox.Show("Thời gian đặt xe đã ở quá khứ =)))");
                    return false;
                }
                else
                {
                    List<OrderCar> orderCar = orderController.getOrdersByCarId(carSelected.Id);
                    bool checkTimeCar = true;
                    foreach(OrderCar car in orderCar)
                    {
                        if (timeStart.Value >= car.timeStart && timeStart.Value <= car.timeEnd)
                        {
                            checkTimeCar = false;
                        }
                    }
                    if(!checkTimeCar)
                    {
                        MessageBox.Show("Xe được chọn không trống trong thời gian này");
                        return false;
                    }
                    else
                    {
                        //MessageBox.Show("Thời gian hợp lệ");
                        return true;
                    }
                }
                
            }

            
        }

        private void timeStart_ValueChanged(object sender, EventArgs e)
        {
            if(carSelected != null)
            {
                DateTime timeStartValue = timeStart.Value;
                DateTime timeEndValue = timeEnd.Value;
                getTotal(carSelected.PayMent, timeStartValue, timeEndValue);
            }
            checkTime();
           
        }

        private void timeEnd_ValueChanged(object sender, EventArgs e)
        {
            if (carSelected != null)
            {
                DateTime timeStartValue = timeStart.Value;
                DateTime timeEndValue = timeEnd.Value;
                getTotal(carSelected.PayMent, timeStartValue, timeEndValue);
            }
            checkTime();
        }
    }
}
