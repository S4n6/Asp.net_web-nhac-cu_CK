using QuanLiThueXeOto.Controller;
using QuanLiThueXeOto.Icon;
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

namespace QuanLiThueXeOto.View
{
    public partial class CreateCar : Form
    {
        CarController carController;
        private bool edit;
        private Car car;
        private bool isChangedImg = false;
        public CreateCar(bool edit, Car car)
        {
            InitializeComponent();
            carController = new CarController();
            this.edit = edit;
            this.car = car;

        }

        private void DetailCar_Load(object sender, EventArgs e)
        {
            if (edit)
            {
                carController.LoadImageToPictureBox(car.IMG, pbCar);
                tbBrandCar.Text = car.Brand.ToString();
                tbPrice.Text = car.PayMent.ToString();
                tbSeat.Text = car.Seat.ToString();
                tbTypeCar.Text = car.Type.ToString();
            }
            else
            {

                pbCar.Image = icon.iconCarCommon;
            }
        }

        private void btnAddImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                isChangedImg = true;
                pbCar.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!edit)
            {
                string type = tbTypeCar.Text;
                string brand = tbBrandCar.Text;
                double payment = Double.Parse(tbPrice.Text);
                int seat = int.Parse(tbSeat.Text);
                Image image = pbCar.Image;
                bool res = carController.createCar(seat, brand, type, payment, image);
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
            else
            {
                string type = tbTypeCar.Text;
                string brand = tbBrandCar.Text;
                double payment = Double.Parse(tbPrice.Text);
                int seat = int.Parse(tbSeat.Text);
                byte[] image = null;
                if (isChangedImg)
                {
                    image = carController.imgToByteArr(pbCar.Image);
                }

             
                bool res = carController.updateCar(seat, brand, type, payment, image, car.Id);
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
            

        }

        
    }
}
