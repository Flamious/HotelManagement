using HotelManagement.CheckInMaking;
using HotelManagement.CompleteCheckInModel;
using HotelManagement.Employee;
using HotelManagement.Navigation;
using HotelManagement.Pages;
using HotelManagement.Structures;
using HotelManagement.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelManagement.ViewModels
{
    class VMAdmit : VMBase
    {
        private readonly INavigation navigation;
        private readonly ICompleteCheckIn completeCheckIn;
        private readonly ICheckInGuest checkInGuest;
        private readonly ICheckInRoom checkInRoom;
        private readonly IEmployee employee;

        public string Room
        {
            get
            {
                return "Комната: "
                    + completeCheckIn.RoomNumber.ToString()
                    + "(" + completeCheckIn.RoomType.TypeName.TrimEnd(' ')
                    + ", " + completeCheckIn.Roominess + ")";
            }
        }
        public string Date
        {
            get
            {
                return "Дата проживания: "
                    + completeCheckIn.CheckIn.StartDate.ToString("dd.MM.yyyy")
                    + "-" + completeCheckIn.CheckIn.EndDate.ToString("dd.MM.yyyy");
            }
        }
        public string RoomCost
        {
            get
            {
                return "Комната: " + completeCheckIn.CheckIn.RoomCost.ToString();
            }
        }
        public string ServicesCost
        {
            get
            {
                return "Доп. услуги: " + completeCheckIn.CheckIn.ServicesCost.ToString();
            }
        }
        public string FullCost
        {
            get
            {
                return "Всего: " + (completeCheckIn.CheckIn.RoomCost + completeCheckIn.CheckIn.ServicesCost).ToString();
            }
        }
        public string Services
        {
            get
            {
                return completeCheckIn.GetServicesToAdmit();
            }
        }
        public List<Visibility> Visibilities { get; set; }
        public List<string> GuestsHeaders { get; set; }
        public List<string> GuestsInfo => completeCheckIn.GetGuestsToAdmit();
        public VMAdmit()
        {
            navigation = IoC.Get<INavigation>();
            completeCheckIn = IoC.Get<ICompleteCheckIn>();
            checkInGuest = IoC.Get<ICheckInGuest>();
            checkInRoom = IoC.Get<ICheckInRoom>();
            employee = IoC.Get<IEmployee>();

            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.VisibilityChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            checkInGuest.GuestInfoChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            employee.ListChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            employee.UserChanged += (sender, e) => OnPropertyChanged(e.PropertyName);

            Visibilities = new List<Visibility>();
            GuestsHeaders = new List<string>();

            for (int i = 0; i < completeCheckIn.Guests.Count; i++)
            {
                Visibilities.Add(Visibility.Visible);
                GuestsHeaders.Add(completeCheckIn.Guests[i].Surname + " " + completeCheckIn.Guests[i].GuestName[0] + ". " + completeCheckIn.Guests[i].Patronymic[0] + ".");
            }
            for (int i = completeCheckIn.Guests.Count; i < 4; i++)
            {
                Visibilities.Add(Visibility.Collapsed);
                GuestsHeaders.Add(" ");
            }
        }

        private RelayCommand forwardCommand;
        public RelayCommand ForwardCommand
        {
            get
            {
                return forwardCommand ?? (forwardCommand = new RelayCommand(obj =>
                {
                    completeCheckIn.CheckIn.LastEmployeeId = employee.Id;
                    if (completeCheckIn.Id > 0)
                    {
                        completeCheckIn.EditCheckIn();
                    }
                    else
                        completeCheckIn.AddCheckIn();
                    checkInRoom.Clear();
                    checkInGuest.Clear();
                    completeCheckIn.Clear();
                    employee.LoadList();
                    navigation.Navigate(new EmployeePage());
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
                    if (completeCheckIn.Id > 0)
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
