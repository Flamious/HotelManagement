using BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Guest
{
    public interface IGuest
    {
        event PropertyChangedEventHandler CurrentGuestChanged;
        FoundGuest Guest { get; set; }
        void ChangeGuest(FoundGuest guest);
    }
}
