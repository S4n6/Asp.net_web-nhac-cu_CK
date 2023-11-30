using QuanLiThueXeOto.Controller;
using QuanLiThueXeOto.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiThueXeOto.View
{
    public partial class DetailOrderUI : UserControl
    {
        OrderCar orderCar;
        CustomerController customerController;
        CarController carController;
        public DetailOrderUI(OrderCar orderCar)
        {
            InitializeComponent();
            this.orderCar = orderCar;
            customerController = new CustomerController();
            carController = new CarController();
        }

        private void DetailOrderUI_Load(object sender, EventArgs e)
        {
            Car car = carController.getCarById(orderCar.carId);
            Customer customer = customerController.GetCustomerById(orderCar.customerId);
            lbAddress.Text = customer.address;
            lbBirth.Text = customer.birthDay.ToString();
            lbPhone.Text = customer.phone.ToString();
            lbName.Text = customer.name;
            lbBrand.Text = car.Brand;
            lbSeat.Text = car.Seat.ToString();
            lbType.Text = car.Type.ToString();
            lbTimeStart.Text = orderCar.timeStart.ToString();
            lbTimeEnd.Text = orderCar.timeEnd.ToString();
            lbTotal.Text = orderCar.payMent.ToString();
            lbLocationStart.Text = orderCar.locationStart.ToString();
            lbLocationEnd.Text = orderCar.locationEnd.ToString();
            lbStatus.Text = orderCar.carBack ? "Đã thanh toán" : "Chưa thanh toán";

        }
    }
}
