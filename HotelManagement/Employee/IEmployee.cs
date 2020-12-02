using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Employee
{
    public interface IEmployee
    {
        event PropertyChangedEventHandler UserChanged;
        string Username { get; set; }
        int? Id { get; set; }
    }
}
