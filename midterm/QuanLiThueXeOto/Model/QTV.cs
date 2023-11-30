using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThueXeOto.Model
{
    public class QTV
    {
        public string username { get; set; }
        public string password { get; set; }
        public string fullName { get; set; }

        public string address { get; set; }
        public string phone {  get; set; }
        public string role { get; set; }

        public QTV(string username, string password, string fullName, string address, string phone, string role)
        {
            this.username = username;
            this.password = password;
            this.fullName = fullName;
            this.address = address;
            this.phone = phone;
            this.role = role;
        }
    }
}
