using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using HotelManagement.Guest;
using HotelManagement.Navigation;
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
    class VMLoginPage : VMBase
    {
        private readonly INavigation navigation;
        private readonly IAuthorizationService authorization;
        private readonly IGuest guest;

        private RelayCommand loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new RelayCommand(obj =>
                {
                    var data = obj as LoginData;
                    if (string.IsNullOrEmpty(data.Login) || string.IsNullOrEmpty(data.PasswordBox.Password)) return;
                    AccountFullData account = new AccountFullData();
                    account = authorization.FindAccount(data.Login, data.PasswordBox.Password) ?? null;

                    if (account == null) return;

                    Console.WriteLine(account.Modifier);
                    switch (account.Modifier.Trim(' '))
                    {
                        case "Guest":
                            var currentGuest = authorization.FindGuest(account.AccountID);
                            guest.ChangeGuest(currentGuest);
                            guest.FillPreviousCheckList(authorization.FindAllCheckIns(currentGuest.GuestID) ?? new List<GuestCheckInFullData>());
                            guest.FillClosestCheckIn(authorization.FindClosestCheckIn(currentGuest.GuestID) ?? new GuestCheckInFullData());
                            navigation.Navigate(new GuestPage());
                            break;
                        default:
                            return;
                    }
                    navigation.ChangeVisibility(Visibility.Visible);
                }));
            }
        }

        private RelayCommand openRegistrationCommand;
        public RelayCommand OpenRegistrationCommand
        {
            get
            {
                return openRegistrationCommand ?? (openRegistrationCommand = new RelayCommand(obj =>
                {
                    navigation.Navigate(new RegistrationPage());
                }));
            }
        }
        public VMLoginPage()
        {
            navigation = IoC.Get<INavigation>();
            guest = IoC.Get<IGuest>();
            authorization = BLL.ServiceModules.IoC.Get<IAuthorizationService>();
            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.VisibilityChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            guest.CurrentGuestChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
        }
    }
}
