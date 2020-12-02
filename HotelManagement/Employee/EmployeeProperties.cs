using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Employee
{
    public class EmployeeProperties : IEmployee
    {
        public event PropertyChangedEventHandler UserChanged;
        private string username;
        private int? id;
        public int? Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                UserChanged?.Invoke(null, new PropertyChangedEventArgs("Username"));
            }
        }
    }
}
