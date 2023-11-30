using Microsoft.Office.Interop.Excel;
using QuanLiThueXeOto.Controller;
using QuanLiThueXeOto.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace QuanLiThueXeOto.View
{
    public partial class QuanLiCar : Form
    {
        CarController carController;
        private int carSelectedId = 0;
        private QTV user = null;
        public QuanLiCar(QTV user)
        {
            InitializeComponent();
            carController = new CarController();
            this.user = user;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CreateCar createCar = new CreateCar(false, null);
            createCar.FormClosed += CreateCar_FormClosed;
            createCar.Show();
        }

        private void QuanLiOto_Load(object sender, EventArgs e)
        {
            if ( user != null && !user.role.Equals("admin"))
            {
                btnDelete.Hide();
                btnAdd.Hide();
                btnAddByExcel.Hide();
                btnEdit.Hide();
            }
            List<Car> cars = carController.getCars();
            dgvCars.DataSource = cars;
            dgvCars.Columns["TimeRentStart"].Visible = false;
            dgvCars.Columns["TimeRentEnd"].Visible = false;
            dgvCars.CellClick += DgvCars_CellClick;

        }

        private void CreateCar_FormClosed(object sender, FormClosedEventArgs e)
        {
            QuanLiOto_Load(null, EventArgs.Empty);
        }

        private void DgvCars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo chỉ xử lý khi người dùng nhấp vào một hàng hợp lệ (không phải là hàng tiêu đề)
            {
                pnDetail.Controls.Clear();
                DataGridViewRow row = dgvCars.Rows[e.RowIndex];
                int id = Convert.ToInt32(row.Cells["Id"].Value);
                DetailCarUI otoUI = new DetailCarUI(carController.getCarById(id));
                pnDetail.Controls.Add(otoUI);
                carSelectedId = id;
                otoUI.Left = (pnDetail.Width - otoUI.Width) / 2;
                otoUI.Top = (pnDetail.Height - otoUI.Height) / 3;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (carSelectedId > 0)
            {
                CreateCar createCar = new CreateCar(true, carController.getCarById(carSelectedId));
                createCar.FormClosed += CreateCar_FormClosed;
                createCar.Show();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (carSelectedId > 0)
            {
                bool res = carController.deleteCar(carSelectedId);
                if (res)
                {
                    MessageBox.Show("Xóa thành công");
                    QuanLiOto_Load(null, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Xóa thát bại");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int seat = 0;
            string brand = null;
            string type = null;
            if (!string.IsNullOrEmpty(tbSeat.Text))
            {   
                seat = int.Parse(tbSeat.Text);
            }
            if (!string.IsNullOrEmpty(tbBrand.Text))
            {
                brand = tbBrand.Text;
            }
            if (!string.IsNullOrEmpty(tbType.Text))
            {
                type = tbType.Text;
            }

            List<Car> listCardSearched = carController.searchCar(type, brand, seat);
            dgvCars.DataSource = listCardSearched;
            dgvCars.Columns["TimeRentStart"].Visible = false;
            dgvCars.Columns["TimeRentEnd"].Visible = false;
            dgvCars.CellClick += DgvCars_CellClick;
            
        }

        private void btnAddByExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            int seat = 0;
            string brand = "";
            string type = "";
            double payment = 0;

            // Thiết lập các thuộc tính của OpenFileDialog
            openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            // Hiển thị OpenFileDialog và kiểm tra kết quả
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn và tên tệp được chọn
                string filePath = openFileDialog.FileName;

                // Khởi tạo ứng dụng Excel
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                // Mở workbook
                Workbook workbook = excelApp.Workbooks.Open(filePath);

                // Lấy worksheet đầu tiên từ workbook
                Worksheet worksheet = workbook.Sheets[1];

                // Lấy số hàng và số cột trong worksheet
                int rowCount = worksheet.UsedRange.Rows.Count;
                int columnCount = worksheet.UsedRange.Columns.Count;

                // Duyệt qua từng ô trong worksheet
                for (int row = 2; row <= rowCount; row++)
                {
                    for (int col = 2; col <= columnCount; col++)
                    {
                        // Đọc giá trị của ô
                        Range cell = worksheet.Cells[row, col];
                        string cellValue = cell.Value != null ? cell.Value.ToString() : "";

                        if(col == 2)
                        {
                            seat = int.Parse(cellValue);
                        }
                        else if(col == 3)
                        {
                            brand = cellValue;
                        }
                        else if(col == 4)
                        {
                            type = cellValue;
                        }
                        else if( col == 5)
                        {
                            payment = double.Parse(cellValue);
                        }
                        else
                        {

                        }
                        
                    }
                    carController.createCar(seat, brand, type, payment, null);
                }

                // Đóng workbook và ứng dụng Excel
                workbook.Close();
                excelApp.Quit();
                MessageBox.Show("Thêm thành công");
                QuanLiOto_Load(null, EventArgs.Empty);
            }
        }
    }
}
