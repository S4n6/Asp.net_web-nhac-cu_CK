using QuanLiThueXeOto.Controller;
using QuanLiThueXeOto.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using OfficeOpenXml;
using Microsoft.Office.Interop.Excel;


namespace QuanLiThueXeOto.View
{
    public partial class QuanLiCustomer : Form
    {
        CustomerController customerController;
        int customerSelectedId;
        private QTV user = null;
        public QuanLiCustomer(QTV user)
        {
            InitializeComponent();
            customerController = new CustomerController();
            this.user = user;
        }

        private void QuanLiCustomer_Load(object sender, EventArgs e)
        {
            if (user != null && !user.role.Equals("admin"))
            {
                btnDelete.Hide();
            }
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            List<Customer> customers = customerController.GetCustomers();
            dgvCustomers.Controls.Clear();
            dgvCustomers.DataSource = customers;
            dgvCustomers.CellClick += DgvCars_CellClick;


        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateCustomer createCustomer = new CreateCustomer(false, null);
            createCustomer.FormClosed += CreateCustomer_FormClosed;
            createCustomer.Show();
        }

        private void CreateCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            QuanLiCustomer_Load(null, EventArgs.Empty);
        }

        private void DgvCars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo chỉ xử lý khi người dùng nhấp vào một hàng hợp lệ (không phải là hàng tiêu đề)
            {
                pnDetail.Controls.Clear();
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                int id = Convert.ToInt32(row.Cells["Id"].Value);
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                customerSelectedId = id;
                DetailCustomerUI detailCustomerUI = new DetailCustomerUI(customerController.GetCustomerById(id));
                pnDetail.Controls.Add(detailCustomerUI);
                detailCustomerUI.Left = (pnDetail.Width - detailCustomerUI.Width) / 2;
                detailCustomerUI.Top = (pnDetail.Height - detailCustomerUI.Height) / 3;
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(customerSelectedId > 0) { 
                CreateCustomer createCustomer = new CreateCustomer(true, customerController.GetCustomerById(customerSelectedId));
                createCustomer.FormClosed += CreateCustomer_FormClosed;
                createCustomer.Show();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (customerSelectedId > 0)
            {
                bool res = customerController.DeleteCustomer(customerSelectedId);
                if(res)
                {
                    MessageBox.Show("Xóa thành công");
                    QuanLiCustomer_Load(null, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Xóa thát bại");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = null;
            string address = null;
            string phone = null;
            if (!string.IsNullOrEmpty(tbName.Text))
            {
                name = tbName.Text;
            }
            if (!string.IsNullOrEmpty(tbAddress.Text))
            {
                address = tbAddress.Text;
            }
            if (!string.IsNullOrEmpty(tbPhone.Text))
            {
                phone = tbPhone.Text;
            }


            List<Customer> customers = customerController.SearchCustomer(name, phone, address);
            dgvCustomers.Controls.Clear();
            dgvCustomers.DataSource = customers;
            dgvCustomers.CellClick += DgvCars_CellClick;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Tạo một thể hiện của SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Thiết lập các thuộc tính của SaveFileDialog
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.DefaultExt = "xlsx";
            saveFileDialog.AddExtension = true;

            // Hiển thị SaveFileDialog và kiểm tra kết quả
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn và tên tệp được chọn
                string filePath = saveFileDialog.FileName;

                // Khởi tạo ứng dụng Excel
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                // Tạo một workbook mới
                Workbook workbook = excelApp.Workbooks.Add(Type.Missing);

                // Tạo một worksheet mới
                Worksheet worksheet = workbook.ActiveSheet;

                // Đặt tiêu đề cho các cột từ DataGridView
                worksheet.Cells[1, 1] = "Mã khách hàng";
                worksheet.Cells[1, 2] = "Họ Tên";
                worksheet.Cells[1, 3] = "Ngày sinh";
                worksheet.Cells[1, 4] = "Địa chỉ";
                worksheet.Cells[1, 5] = "Số điện thoại";



                // Đổ dữ liệu từ DataGridView vào worksheet
                for (int i = 0; i < dgvCustomers.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvCustomers.Columns.Count; j++)
                    {
                        worksheet.Cells[i+2, j+1] = dgvCustomers.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // Lưu workbook vào tệp Excel
                workbook.SaveAs(filePath);

                // Đóng workbook và ứng dụng Excel
                workbook.Close();
                excelApp.Quit();

                // Giải phóng tài nguyên COM
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                MessageBox.Show("Xuất file Excel thành công!");
            }
        }

      
    }
}
