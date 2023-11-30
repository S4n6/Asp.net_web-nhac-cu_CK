using QuanLiThueXeOto.Controller;
using QuanLiThueXeOto.DB;
using QuanLiThueXeOto.Icon;
using QuanLiThueXeOto.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLiThueXeOto.View
{
    public partial class SignIn : Form
    {
        UserController userController;
        //public SignIn(string username, string password)
        //{
        //    InitializeComponent();
        //    this.userController = new UserController();
        //}

        public SignIn()
        {
            InitializeComponent();
            this.userController = new UserController();
        }

        private void SignIn_Load(object sender, EventArgs e)
        {
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.FlatAppearance.BorderColor = Color.Red;
            btnSignUp.FlatAppearance.BorderSize = 1;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Xin lỗi, cần cung cấp quyền truy cập để tạo tài khoản");
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string enteredUsername = tbUsername.Text;
            string enteredPassword = tbPassword.Text;

            QTV qtv = userController.logIn(enteredUsername, enteredPassword); ;
            
            if (qtv != null)
            {
                this.Hide();
                Home home = new Home(qtv);
                home.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ");
            }
        }

        private void pbIconPassword_Click(object sender, EventArgs e)
        {
            if (tbPassword.PasswordChar != '\0')
            {

                
                pbIconPassword.Image = icon.notSeenPassword;
                tbPassword.PasswordChar = '\0';
            }
            else
            {

                pbIconPassword.Image = icon.seePassword;
                tbPassword.PasswordChar = '*';
            }
        }
    }
}
