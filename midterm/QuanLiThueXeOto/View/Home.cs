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
    public partial class Home : Form
    {
        private QTV user;
        public Home(QTV qtv)
        {
            InitializeComponent();
            user = qtv;
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SignIn().Show();
        }

        private void btnCar_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            QuanLiCar quanLiOto = new QuanLiCar(user);
            quanLiOto.TopLevel = false;
            quanLiOto.Dock = DockStyle.Fill;
            quanLiOto.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            pnMain.Controls.Add(quanLiOto);
            quanLiOto.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            QuanLiCustomer quanLiCustomer = new QuanLiCustomer(user);
            quanLiCustomer.TopLevel = false;
            quanLiCustomer.Dock = DockStyle.Fill;
            quanLiCustomer.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            pnMain.Controls.Add(quanLiCustomer);
            quanLiCustomer.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            QuanLiOrder quanLiOrder = new QuanLiOrder(user);
            quanLiOrder.TopLevel = false;
            quanLiOrder.Dock = DockStyle.Fill;
            quanLiOrder.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            pnMain.Controls.Add(quanLiOrder);
            quanLiOrder.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            HomeUI homeUI = new HomeUI();
            pnMain.Controls.Add(homeUI);

        }

        private void Home_Load(object sender, EventArgs e)
        {
            if (!user.role.Equals("admin"))
            {
                btnRegister.Enabled = false;
            }

            pnMain.Controls.Clear();
            HomeUI homeUI = new HomeUI();
            pnMain.Controls.Add(homeUI);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
        }
    }
}
