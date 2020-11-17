using BLL.Models;
using HotelManagement.Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Guest
{
    public interface IRegistration
    {
        event PropertyChangedEventHandler GuestDataChanged;
        event PropertyChangedEventHandler ErrorChanged;
        GuestFullData GuestFullData { get; set; }
        string Error { get; set; }
        void AddGuest(RegistrationData registration);
        void UpdateGuest();
        void ChangeError(string error);
    }
}
