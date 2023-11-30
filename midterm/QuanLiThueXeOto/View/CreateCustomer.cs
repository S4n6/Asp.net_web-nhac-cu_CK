using QuanLiThueXeOto.Controller;
using QuanLiThueXeOto.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiThueXeOto.View
{
    public partial class CreateCustomer : Form
    {
        CustomerController customerController;
        private bool edit;
        private Customer customer;
        public CreateCustomer(bool edit, Customer customer)
        {
            InitializeComponent();
            customerController = new CustomerController();
            this.edit = edit;
            this.customer = customer;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (edit)
            {
                string name = tbName.Text;
                string dateString = dateBirth.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dateTime = DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string address = tbAddress.Text;
                string phone = tbPhone.Text;
                bool res = customerController.UpdateCustomer(customer.id, name, dateTime, address, phone);
                if (res)
                {
                    MessageBox.Show("Cập nhật thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");

                }
            }
            else
            {
                string name = tbName.Text;
                string dateString = dateBirth.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dateTime = DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string address = tbAddress.Text;
                string phone = tbPhone.Text;
                bool res = customerController.AddCustomer(name, dateTime, address, phone);
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

        private void CreateCustomer_Load(object sender, EventArgs e)
        {
            if (edit)
            {
                label5.Text = "Thông tin khách hàng";
                btnSave.Text = "Lưu";
                tbAddress.Text = customer.address;
                tbName.Text = customer.name;
                tbPhone.Text = customer.phone;
                dateBirth.Value = customer.birthDay;
            }
        }
    }
}
