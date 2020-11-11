using BLL.Models;
using HotelManagement.Guest;
using HotelManagement.Navigation;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace HotelManagement.ViewModels
{
    class VMMainWindow : VMBase
    {
        private readonly INavigation navigation;
        private readonly IGuest guest;

        public Page CurrentPage => navigation.CurrentPage;
        public Visibility CurrentVisibility => navigation.CurrentVisibility;

        private RelayCommand logOutCommand;
        public RelayCommand LogOutCommand
        {
            get
            {
                return logOutCommand ?? (logOutCommand = new RelayCommand(obj =>
                {
                    if(CurrentPage is GuestPage)
                    {
                        guest.ChangeGuest(new FoundGuest());
                        guest.FillPreviousCheckList(new List<FoundGuestCheckIn>());
                        guest.FillClosestCheckIn(new FoundGuestCheckIn());
                    }
                    navigation.Navigate(new LoginPage());
                    navigation.ChangeVisibility(Visibility.Hidden);

                }));
            }
        }
        public VMMainWindow()
        {
            navigation = IoC.Get<INavigation>();
            guest = IoC.Get<IGuest>();
            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.VisibilityChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            guest.CurrentGuestChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.Navigate(new LoginPage());
            navigation.ChangeVisibility(Visibility.Hidden);
        }
    }
}
