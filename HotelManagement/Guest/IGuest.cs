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
        event PropertyChangedEventHandler ClosestCheckInChanged;
        FoundGuest Guest { get; set; }
        List<FoundGuestCheckIn> AllCheckIns { get; set; }
        FoundGuestCheckIn ClosestCheckIn { get; set; }
        void ChangeGuest(FoundGuest guest);
        void FillPreviousCheckList(List<FoundGuestCheckIn> checkIns);
        void FillClosestCheckIn(FoundGuestCheckIn foundGuestCheckIn);
    }
}
