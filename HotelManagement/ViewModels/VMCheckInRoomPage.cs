using BLL.Interfaces;
using BLL.Models;
using BLL.Models.SearchModels;
using HotelManagement.CheckInMaking;
using HotelManagement.CompleteCheckInModel;
using HotelManagement.Navigation;
using HotelManagement.Structures;
using HotelManagement.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.ViewModels
{
    class VMCheckInRoomPage : VMBase
    {
        private readonly ICheckInRoom checkInRoom;
        private readonly ICheckInGuest checkInGuest;
        private readonly INavigation navigation;
        private readonly ICompleteCheckIn completeCheckIn;

        public string RoomPrice => checkInRoom.RoomPrice;
        public string ServicePrice => checkInRoom.ServicePrice;
        public string FinalPrice => checkInRoom.FinalPrice;
        public string IsFreeRoomExist => checkInRoom.IsFreeRoomExist;
        public bool IsEnabled => checkInRoom.IsEnabled;
        public List<RoomCheckInData> FreeRooms => checkInRoom.FreeRooms;
        public List<Roominess> AvailableRominess => checkInRoom.AvailableRoominess;
        public List<ServiceData> Services => checkInRoom.Services;
        public RoomCheckInData CurrentRoom
        {
            get
            {
                return checkInRoom.CurrentRoom;
            }
            set
            {
                checkInRoom.CurrentRoom = value;
            }
        }
        public Roominess CurrentRoominess
        {
            get
            {
                return checkInRoom.Roominess;
            }
            set
            {
                checkInRoom.Roominess = value;
            }
        }
        public ServiceData CurrentService
        {
            set
            {
                checkInRoom.CurrentService = value;
            }
        }
        public List<RoomTypeModel> RoomTypes => checkInRoom.RoomTypes;
        public RoomTypeModel CurrentRoomType
        {
            get
            {
                return checkInRoom.CurrentRoomType;
            }
            set
            {
                checkInRoom.CurrentRoomType = value;
            }
        }
        public DateTime StartDate
        {
            get
            {
                return checkInRoom.StartDate;
            }
            set
            {
                checkInRoom.StartDate = value;
            }
        }
        public DateTime EndDate
        {
            get
            {
                return checkInRoom.EndDate;
            }
            set
            {
                checkInRoom.EndDate = value;
            }
        }
        public string Error => checkInRoom.Error;
        public VMCheckInRoomPage()
        {
            navigation = IoC.Get<INavigation>();
            checkInRoom = IoC.Get<ICheckInRoom>();
            checkInGuest = IoC.Get<ICheckInGuest>();
            completeCheckIn = IoC.Get<ICompleteCheckIn>();
            checkInRoom.RoomInfoChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            checkInRoom.RoomNumberChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
        }

        private RelayCommand addProvisionNumber;
        public RelayCommand AddProvisionNumber
        {
            get
            {
                return addProvisionNumber ?? (addProvisionNumber = new RelayCommand(obj =>
                {
                    string numStr = obj.ToString();
                    checkInRoom.AddServiceProvision(numStr);
                }));
            }
        }
        private RelayCommand forwardCommand;
        public RelayCommand ForwardCommand
        {
            get
            {
                return forwardCommand ?? (forwardCommand = new RelayCommand(obj =>
                {
                    if (!checkInRoom.AddRoom()) return;
                    if (completeCheckIn.Id > 0)
                        navigation.Navigate(new AdmitCheckInPage());
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
                    completeCheckIn.Clear();
                    checkInRoom.Clear();
                    checkInGuest.Clear();
                    navigation.Navigate(new EmployeePage());
                }));
            }
        }
    }


}
