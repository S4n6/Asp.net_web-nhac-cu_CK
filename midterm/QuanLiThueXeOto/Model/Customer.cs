using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThueXeOto.Model
{
    public class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime birthDay { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public Customer(int id, string name, DateTime birthDay, string address, string phone)
        {
            this.id = id;
            this.name = name;
            this.birthDay = birthDay;
            this.address = address;
            this.phone = phone;
        }
    }
}
