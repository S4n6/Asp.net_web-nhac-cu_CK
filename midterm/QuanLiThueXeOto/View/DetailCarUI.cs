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
    public partial class DetailCarUI : UserControl
    {
        public Car car;
        public DetailCarUI(Car car)
        {
            InitializeComponent();
            this.car = car;

        }

       

        private void btnAddImg_Click(object sender, EventArgs e)
        {
           
        }

        private void OtoUI_Load(object sender, EventArgs e)
        {
            lbBrandCar.Text = car.Brand;
            lbTypeCar.Text = car.Type;
            lbModelCar.Text = car.Seat + "";
            lbStatus.Text = "Trống";
            lbPrice.Text = car.PayMent + " vnđ";
            new CarController().LoadImageToPictureBox(car.IMG, pbImgCar);
        }
    }
}
