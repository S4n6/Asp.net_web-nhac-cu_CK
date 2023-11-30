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
    public partial class DetailCustomerUI : UserControl
    {
        private Customer customer;
        OrderController orderController;
        public DetailCustomerUI(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            orderController = new OrderController();
        }

        private void DetailCustomerUI_Load(object sender, EventArgs e)
        {
            lbAddress.Text = customer.address;
            lbName.Text = customer.name;
            lbPhone.Text = customer.phone;
            lbBirth.Text = customer.birthDay.ToString("dd/MM/yyyy");
            loadSchedule();

        }

        private void loadSchedule()
        {
            List<OrderCar> orderCars = orderController.getOrdersByCustomerId(customer.id);
            dgvSchedule.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn orderNumberColumn1 = new DataGridViewTextBoxColumn();
            orderNumberColumn1.DataPropertyName = "locationStart";
            orderNumberColumn1.HeaderText = "Địa điểm xuất phát";
            orderNumberColumn1.Width = dgvSchedule.Width / 4;
            DataGridViewTextBoxColumn orderNumberColumn2 = new DataGridViewTextBoxColumn();
            orderNumberColumn2.DataPropertyName = "locationEnd";
            orderNumberColumn2.HeaderText = "Điểm đến";
            orderNumberColumn2.Width = dgvSchedule.Width / 4;
            DataGridViewTextBoxColumn orderNumberColumn3 = new DataGridViewTextBoxColumn();
            orderNumberColumn3.DataPropertyName = "timeStart";
            orderNumberColumn3.HeaderText = "Thời gian khởi hành";
            orderNumberColumn3.Width = dgvSchedule.Width / 4;
            DataGridViewTextBoxColumn orderNumberColumn4 = new DataGridViewTextBoxColumn();
            orderNumberColumn4.DataPropertyName = "timeEnd";
            orderNumberColumn4.HeaderText = "Thời gian kết thúc";
            orderNumberColumn4.Width = dgvSchedule.Width / 4;

            dgvSchedule.Columns.Add(orderNumberColumn1);
            dgvSchedule.Columns.Add(orderNumberColumn2);
            dgvSchedule.Columns.Add(orderNumberColumn3);
            dgvSchedule.Columns.Add(orderNumberColumn4);

            dgvSchedule.DataSource = orderCars;
        }
    }
}
