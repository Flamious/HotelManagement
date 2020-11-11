using BLL.Interfaces;
using BLL.Models;
using HotelManagement.Guest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        public string FullName => guest.Guest.Surname.Trim(' ') + " " + guest.Guest.GuestName[0] + ". " + guest.Guest.Patronymic[0] + ".";
        public DateTime BirthDate => guest.Guest.BirthDate;
        public string StringBirthDate => guest.Guest.BirthDate.ToString("dd.MM.yyyy");
        public string PhoneNumber => guest.Guest.PhoneNumber.Trim(' ');
        public string Login => guest.Guest.Login.Trim(' ');
        public string Password => guest.Guest.Password.Trim(' ');
        #endregion

        #region All Previous Checks In Info
        public ICollection<FoundGuestCheckIns> FoundGuestCheckIns => guest.AllCheckIns;
        #endregion
        public VMGuestPage()
        {
            authorization = BLL.ServiceModules.IoC.Get<IAuthorizationService>();
            guest = IoC.Get<IGuest>();
            guest.CurrentGuestChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            guest.PreviousChecksInChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
        }
    }
}
