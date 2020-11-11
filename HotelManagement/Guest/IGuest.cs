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
        event PropertyChangedEventHandler PreviousChecksInChanged;
        FoundGuest Guest { get; set; }
        List<FoundGuestCheckIns> AllCheckIns { get; set; }
        void ChangeGuest(FoundGuest guest);
        void FillPreviousCheckList(List<FoundGuestCheckIns> checkIns);
    }
}
