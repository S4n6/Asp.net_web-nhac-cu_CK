using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace QuanLiThueXeOto.Model
{
    public class OrderCar
    {
        public int orderId { get; set; }
        public int carId { get; set; }
        public int customerId { get; set; }
        public double payMent { get; set; }
        public string locationStart { get; set; }
        public string locationEnd { get; set; }
        public DateTime timeStart { get; set; }
        public DateTime timeEnd { get; set; }
        public bool carBack { get; set; }
        public OrderCar(int orderId, int carId, int customerId, double payMent, string locationStart, string locationEnd, DateTime timeStart, DateTime timeEnd, bool carBack)
        {
            this.orderId = orderId;
            this.carId = carId;
            this.customerId = customerId;
            this.payMent = payMent;
            this.locationStart = locationStart;
            this.locationEnd = locationEnd;
            this.timeStart = timeStart;
            this.timeEnd = timeEnd;
            this.carBack = carBack;
        }



    }
}
