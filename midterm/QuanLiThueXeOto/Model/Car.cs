using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThueXeOto.Model
{
    public class Car
    {
        public int Id { get; set; }
        public int Seat { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public double PayMent { get; set; }
        public DateTime? TimeRentStart { get; set; }
        public DateTime? TimeRentEnd { get; set; }
        public byte[] IMG { get; set; }

        public Car(int id, int seat, string brand, string type, double payment, DateTime? timeRentStart, DateTime? timeRentEnd, byte[] iMG)
        {
            Id = id;
            Seat = seat;
            Brand = brand;
            Type = type;
            TimeRentStart = timeRentStart;
            TimeRentEnd = timeRentEnd;
            PayMent = payment;
            IMG = iMG;
        }

      
    }
}
