using BLL.Interfaces;
using BLL.Models.CheckinModel;
using HotelManagement.Employee;
using HotelManagement.Navigation;
using HotelManagement.Pages;
using HotelManagement.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelManagement.ViewModels
{
    class VMEmployee : VMBase
    {
        private readonly INavigation navigation;
        private readonly IEmployee employee;
        public string Username => employee.Username;
        public List<Period> Periods => employee.Periods;
        public int CurrentCheckInIndex
        {
            get
            {
                return employee.CurrentCheckInIndex;
            }
            set
            {
                employee.CurrentCheckInIndex = value;
            }
        }
        public int CurrentPeriodIndex
        {
            get
            {
                return employee.CurrentPeriodIndex;
            }
            set
            {
                employee.CurrentPeriodIndex = value;
            }
        }
        public List<CheckInInfo> CheckIns => employee.CheckIns;
        private RelayCommand openCheckInPageCommand;
        public RelayCommand OpenCheckInPageCommand
        {
            get
            {
                return openCheckInPageCommand ?? (openCheckInPageCommand = new RelayCommand(obj =>
                {
                    navigation.Navigate(new CheckInPage());
                }));
            }
        }
        private RelayCommand deleteCheckIn;
        public RelayCommand DeleteCheckIn
        {
            get
            {
                return deleteCheckIn ?? (deleteCheckIn = new RelayCommand(obj =>
                {
                    if (CurrentCheckInIndex != -1) employee.DeleteElement();
                }));
            }
        }
        public VMEmployee()
        {
            navigation = IoC.Get<INavigation>();
            employee = IoC.Get<IEmployee>();
            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.VisibilityChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            employee.UserChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            employee.ListChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
        }
    }
}
