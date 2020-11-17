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
        GuestFullData Guest { get; set; }
        List<GuestCheckInFullData> AllCheckIns { get; set; }
        GuestCheckInFullData ClosestCheckIn { get; set; }
        void ChangeGuest(GuestFullData guest);
        void FillPreviousCheckList(List<GuestCheckInFullData> checkIns);
        void FillClosestCheckIn(GuestCheckInFullData foundGuestCheckIn);
    }
}
