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
    public class CurrentRegistration : IRegistration
    {
        public event PropertyChangedEventHandler GuestDataChanged;
        public event PropertyChangedEventHandler ErrorChanged;
        private GuestFullData guestFullData;
        private string error;
        public GuestFullData GuestFullData
        {
            get
            {
                return guestFullData;
            }
            set
            {
                guestFullData = value;
                GuestDataChanged?.Invoke(null, new PropertyChangedEventArgs("GuestFullData"));
            }
        }
        public string Error
        {
            get
            {
                return error;
            }
            set
            {
                error = value;
                ErrorChanged?.Invoke(null, new PropertyChangedEventArgs("Error"));
            }
        }
        public void AddGuest(RegistrationData registration)
        {

        }
        public void UpdateGuest()
        {

        }
        public void ChangeError(string error)
        {
            Error = error;
        }
    }
}
