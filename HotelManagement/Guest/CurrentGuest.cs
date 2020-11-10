using BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Guest
{
    public class CurrentGuest : IGuest
    {
        public event PropertyChangedEventHandler CurrentGuestChanged;
        private FoundGuest guest;
        public FoundGuest Guest
        {
            get
            {
                return guest;
            }
            set
            {
                guest = value;
                CurrentGuestChanged?.Invoke(null, new PropertyChangedEventArgs("CurrentGuest"));
            }
        }
        public void ChangeGuest(FoundGuest guest)
        {
            Guest = guest;
        }
    }
}
