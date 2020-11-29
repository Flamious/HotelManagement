using HotelManagement.Navigation;
using HotelManagement.Pages;
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

        public VMEmployee()
        {
            navigation = IoC.Get<INavigation>();
            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.VisibilityChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
        }
    }
}
