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
        public event PropertyChangedEventHandler PreviousChecksInChanged;
        public event PropertyChangedEventHandler ClosestCheckInChanged;
        private GuestFullData guest;
        private List<GuestCheckInFullData> allCheckIns;
        private GuestCheckInFullData closestCheckin;
        public GuestFullData Guest
        {
            get
            {
                return guest;
            }
            set
            {
                guest = value;
                CurrentGuestChanged?.Invoke(null, new PropertyChangedEventArgs("Guest"));
            }
        }
        public List<GuestCheckInFullData> AllCheckIns
        {
            get
            {
                return allCheckIns;
            }
            set
            {
                allCheckIns = value;
                PreviousChecksInChanged?.Invoke(null, new PropertyChangedEventArgs("AllCheckIns"));
            }
        }
        public GuestCheckInFullData ClosestCheckIn
        {
            get
            {
                return closestCheckin;
            }
            set
            {
                closestCheckin = value;
                ClosestCheckInChanged?.Invoke(null, new PropertyChangedEventArgs("ClosestCheckIn"));
            }
        }
        public void ChangeGuest(GuestFullData guest)
        {
            Guest = guest;
        }
        public void FillPreviousCheckList(List<GuestCheckInFullData> checkIns)
        {
            AllCheckIns = checkIns;
        }
        public void FillClosestCheckIn(GuestCheckInFullData foundGuestCheckIn)
        {
            ClosestCheckIn = foundGuestCheckIn;
        }
    }
}
