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
        private FoundGuest guest;
        private List<FoundGuestCheckIns> allCheckIns;
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
        public List<FoundGuestCheckIns> AllCheckIns
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
        public void ChangeGuest(FoundGuest guest)
        {
            Guest = guest;
        }
        public void FillPreviousCheckList(List<FoundGuestCheckIns> checkIns)
        {
            AllCheckIns = checkIns;
        }
    }
}
