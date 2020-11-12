using BLL.Interfaces;
using BLL.Models;
using HotelManagement.Guest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.ViewModels
{
    class VMGuestPage : VMBase
    {
        private readonly IAuthorizationService authorization;
        private readonly IGuest guest;
        #region Guest Info
        public int GuestID => guest.Guest.GuestID;
        public int AccountID => guest.Guest.AccountID;
        public string Surname => guest.Guest.Surname.Trim(' ');
        public string GuestName => guest.Guest.GuestName.Trim(' ');
        public string Patronymic => guest.Guest.Patronymic.Trim(' ');
        public string FullName => guest.Guest.Surname.Trim(' ') + " " + guest.Guest.GuestName.Trim(' ') + " " + guest.Guest.Patronymic.Trim(' ');
        public DateTime BirthDate => guest.Guest.BirthDate;
        public string StringBirthDate => guest.Guest.BirthDate.ToString("dd.MM.yyyy");
        public string PhoneNumber => guest.Guest.PhoneNumber.Trim(' ');
        public string Login => guest.Guest.Login.Trim(' ');
        public string Password
        {
            get
            {
                string password = "";
                for (int i = 0; i < guest.Guest.Password.Trim(' ').Length; i++)
                {
                    password += "*";
                }
                return password;
            }
        }
        #endregion
        #region Closest Check In Info
        public string CheckInState
        {
            get
            {
                if (guest.ClosestCheckIn.StartDateString == "") return "Ближайшее заселение отсутствует";
                if (guest.ClosestCheckIn.StartDate > DateTime.Now) return "Ближайшее заселение";
                if (guest.ClosestCheckIn.StartDate < DateTime.Now) return "Текущее заселение";
                return "";
            }
        }
        public string CheckInId => guest.ClosestCheckIn.CheckInId == -1 ? "" : guest.ClosestCheckIn.CheckInId.ToString();
        public string Room => guest.ClosestCheckIn.RoomNumber == -1 ? "" : guest.ClosestCheckIn.RoomNumber.ToString();
        public string Services => guest.ClosestCheckIn.ServicesString;
        public string Period => guest.ClosestCheckIn.StartDateString == "" ? guest.ClosestCheckIn.StartDateString : guest.ClosestCheckIn.StartDateString + " - " + guest.ClosestCheckIn.EndDateString;
        public string RoomPrice => guest.ClosestCheckIn.RoomPrice == -1 ? "" : guest.ClosestCheckIn.RoomPrice.ToString();
        public string ServicesPrice => guest.ClosestCheckIn.ServicesPrice == -1 ? "" : guest.ClosestCheckIn.ServicesPrice.ToString();
        #endregion
        #region All Previous Checks In Info
        public ICollection<FoundGuestCheckIn> FoundGuestCheckIns => guest.AllCheckIns.OrderBy(i=>i.StartDate).ToList();
        #endregion
        public VMGuestPage()
        {
            authorization = BLL.ServiceModules.IoC.Get<IAuthorizationService>();
            guest = IoC.Get<IGuest>();
            guest.CurrentGuestChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            guest.PreviousChecksInChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            guest.ClosestCheckInChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
        }
    }
}
