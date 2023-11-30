using Microsoft.Win32;
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
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLiThueXeOto.View
{
    public partial class Register : Form
    {
        UserController userController;
        public Register()
        {
            InitializeComponent();
            this.userController = new UserController();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string fullName = tbFullName.Text;
            string address = tbAddress.Text;
            string username = tbUserName.Text;
            string password = tbPassword.Text;
            string enteredPassword = tbRePassword.Text;
            string phone = tbPhone.Text;
            string role = cbRole.SelectedItem.ToString();

            bool IsValidPhoneNumber(string phoneNumber)
            {
                // Kiểm tra xem phone có đủ 10 chữ số hay không
                if (phone.Length != 10)
                {
                    return false;
                }

                // Kiểm tra xem phone có chứa ký tự không phải là số hay không
                foreach (char c in phone)
                {
                    if (!char.IsDigit(c))
                    {
                        return false;
                    }
                }

                return true;
            }

            //string sqlQuery = "SELECT * FROM your_table";
            //DataTable result = new QueryDb().ExecuteQuery(sqlQuery);

            if (string.IsNullOrEmpty(fullName))
            {
                // Tên đầy đủ không được để trống
                // Thực hiện các hành động cần thiết (hiển thị thông báo lỗi, ngăn chặn insert, v.v.)
                MessageBox.Show("Vui lòng nhập đầy đủ tên");

            }
            else if (string.IsNullOrEmpty(phone))
            {
                // Địa chỉ không được để trống
                // Thực hiện các hành động cần thiết
                MessageBox.Show("Vui lòng nhập số điện thoại");

            }
            else if (string.IsNullOrEmpty(username))
            {
                // Tên người dùng không được để trống
                // Thực hiện các hành động cần thiết
                MessageBox.Show("Vui lòng nhập tên tài khoản");
            }
            else if (string.IsNullOrEmpty(password))
            {
                // Mật khẩu không được để trống
                // Thực hiện các hành động cần thiết
                MessageBox.Show("Vui lòng nhập mật khẩu");
            }
            else if (string.IsNullOrEmpty(enteredPassword))
            {
                // Mật khẩu nhập lại không được để trống
                // Thực hiện các hành động cần thiết
                MessageBox.Show("Vui lòng nhập mật khẩu");

            }
            else if (password != enteredPassword)
            {
                // Mật khẩu và mật khẩu nhập lại không khớp
                // Thực hiện các hành động cần thiết
                MessageBox.Show("Mật khẩu sai");
            }
            else if (!IsValidPhoneNumber(phone))
            {
                // Số điện thoại không được để trống
                // Thực hiện các hành động cần thiết
                MessageBox.Show("Số điện thoại không hợp lệ");
            }
            else
            {
                QTV qTV = new QTV(username, password, address ,fullName, phone, role);
                bool res = userController.register(qTV);
                if (res)
                {
                    MessageBox.Show("Đăng kí thành công");
                }
                else
                {
                    MessageBox.Show("Đăng kí thất bại");
                }
            }
            
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignIn signIn = new SignIn();
            signIn.Show();
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

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
