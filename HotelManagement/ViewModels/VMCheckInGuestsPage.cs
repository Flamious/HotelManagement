using BLL.Models;
using HotelManagement.CheckInMaking;
using HotelManagement.CompleteCheckInModel;
using HotelManagement.Converters;
using HotelManagement.Navigation;
using HotelManagement.Pages;
using HotelManagement.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.ViewModels
{
    class VMCheckInGuestsPage : VMBase
    {
        private readonly INavigation navigation;
        private readonly ICheckInRoom checkInRoom;
        private readonly ICheckInGuest checkInGuest;
        private readonly ICompleteCheckIn completeCheckIn;

        public string Surname
        {
            get
            {
                return checkInGuest.Surname;
            }
            set
            {
                checkInGuest.Surname = value;
            }
        }
        public string GuestName
        {
            get
            {
                return checkInGuest.GuestName;
            }
            set
            {
                checkInGuest.GuestName = value;
            }
        }
        public string Patronymic
        {
            get
            {
                return checkInGuest.Patronymic;
            }
            set
            {
                checkInGuest.Patronymic = value;
            }
        }
        public DateTime BirthDate
        {
            get
            {
                return checkInGuest.BirthDate;
            }
            set
            {
                checkInGuest.BirthDate = value;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return checkInGuest.PhoneNumber;
            }
            set
            {
                checkInGuest.PhoneNumber = value;
            }
        }
        public bool IsChild
        {
            get
            {
                return checkInGuest.IsChild;
            }
            set
            {
                checkInGuest.IsChild = value;
            }
        }
        public string Document
        {
            get
            {
                return checkInGuest.Document;
            }
            set
            {
                checkInGuest.Document = value;
            }
        }
        public VMCheckInGuestsPage()
        {
            navigation = IoC.Get<INavigation>();
            checkInRoom = IoC.Get<ICheckInRoom>();
            checkInGuest = IoC.Get<ICheckInGuest>();
            completeCheckIn = IoC.Get<ICompleteCheckIn>();
            checkInRoom.RoomInfoChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            checkInRoom.RoomNumberChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            checkInGuest.GuestInfoChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
        }

        private RelayCommand forwardCommand;
        public RelayCommand ForwardCommand
        {
            get
            {
                return forwardCommand ?? (forwardCommand = new RelayCommand(obj =>
                {
                    checkInGuest.AddGuest();
                    if (checkInGuest.CurrentGuestIndex >= completeCheckIn.Roominess)
                    {
                        checkInGuest.EndAdding();
                        navigation.Navigate(new AdmitCheckInPage());
                    }
                    else
                        navigation.Navigate(new GuestPage());

                }));
            }
        }
        private RelayCommand backCommand;
        public RelayCommand BackCommand
        {
            get
            {
                return backCommand ?? (backCommand = new RelayCommand(obj =>
                {
                    if (checkInGuest.CurrentGuestIndex == 0)
                    {
                        checkInRoom.RefillEverything();
                        navigation.Navigate(new CheckInPage());
                    }
                    else
                    {
                        checkInGuest.Back();
                        navigation.Navigate(new GuestPage());
                    }
                }));
            }
        }
    }
}
