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
        private FoundGuest guest;
        private List<FoundGuestCheckIn> allCheckIns;
        private FoundGuestCheckIn closestCheckin;
        public FoundGuest Guest
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
        public List<FoundGuestCheckIn> AllCheckIns
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
        public FoundGuestCheckIn ClosestCheckIn
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
        public void ChangeGuest(FoundGuest guest)
        {
            Guest = guest;
        }
        public void FillPreviousCheckList(List<FoundGuestCheckIn> checkIns)
        {
            AllCheckIns = checkIns;
        }
        public void FillClosestCheckIn(FoundGuestCheckIn foundGuestCheckIn)
        {
            ClosestCheckIn = foundGuestCheckIn;
        }
    }
}
