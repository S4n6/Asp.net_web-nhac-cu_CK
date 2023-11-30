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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuanLiThueXeOto.View
{
    public partial class QuanLiOrder : Form
    {
        OrderController orderController;
        int oderIdSelected;
        public QuanLiOrder(QTV user)
        {
            InitializeComponent();
            orderController = new OrderController();
        }

        private void QuanLiOrder_Load(object sender, EventArgs e)
        {
            List<OrderCar> orderCars = orderController.getOrders();
            dgvOrder.DataSource = orderCars;

            dgvOrder.Columns["carId"].Visible = false;
            dgvOrder.Columns["customerId"].Visible = false;
            //dgvOrder.Columns["carBack"].Visible = false;
            dgvOrder.CellClick += DgvOrder_CellClick;

        }

        private void DgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) // Đảm bảo chỉ xử lý khi người dùng nhấp vào một hàng hợp lệ (không phải là hàng tiêu đề)
            {
                pnDetail.Controls.Clear();
                DataGridViewRow row = dgvOrder.Rows[e.RowIndex];
                int id = Convert.ToInt32(row.Cells["orderId"].Value);
                btnStatus.Enabled = true;
                btnDelete.Enabled = true;
                oderIdSelected = id;
                DetailOrderUI detailOrderUI = new DetailOrderUI( orderController.getOrderById(id) );
                pnDetail.Controls.Add(detailOrderUI);
                //detailOrderUI.Left = (pnDetail.Width - detailOrderUI.Width) / 2;
                //detailOrderUI.Top = (pnDetail.Height - detailOrderUI.Height) / 3;
            }
            
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            CreateOrder createOrder = new CreateOrder();
            createOrder.FormClosed += CreateOrder_FormClosed;
            createOrder.Show();
        }
        private void CreateOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            QuanLiOrder_Load(null, EventArgs.Empty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (oderIdSelected > 0)
            {
                bool res = orderController.deleteOrder(oderIdSelected);
                if (res)
                {
                    MessageBox.Show("Xóa thành công");
                    QuanLiOrder_Load(null, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Xóa thát bại");
                }
            }
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            if (oderIdSelected > 0)
            {
                bool res = orderController.updateStatusOrder(oderIdSelected);
                if (res)
                {
                    MessageBox.Show("Cập nhật thành công");
                    QuanLiOrder_Load(null, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Cập nhật thát bại");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string codeOrder = tbCodeOrder.Text;
            List<OrderCar> orderCars = new List<OrderCar>();
            if(orderController.getOrderById(int.Parse(codeOrder)) != null)
            {
                orderCars.Add(orderController.getOrderById(int.Parse(codeOrder)));
            }
            
            if(orderCars.Count > 0)
            {
                dgvOrder.DataSource = orderCars;
                dgvOrder.Columns["carId"].Visible = false;
                dgvOrder.Columns["customerId"].Visible = false;
                //dgvOrder.Columns["carBack"].Visible = false;
                dgvOrder.CellClick += DgvOrder_CellClick;
            }
            else
            {
                MessageBox.Show("Không tìm thấy order");
            }
            
        }
    }
}
