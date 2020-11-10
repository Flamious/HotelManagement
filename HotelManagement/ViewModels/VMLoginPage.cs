using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using HotelManagement.Guest;
using HotelManagement.Navigation;
using HotelManagement.Structures;
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
                    FoundAccount account = new FoundAccount();
                    account = authorization.FindAccount(data.Login, data.PasswordBox.Password) ?? null;

                    if (account == null) return;

                    Console.WriteLine(account.Modifier);
                    switch (account.Modifier.Trim(' '))
                    {
                        case "Guest":
                            guest.ChangeGuest(authorization.FindGuest(account.AccountID));
                            navigation.Navigate(new GuestPage());
                            break;
                        default:
                            return;
                    }
                    navigation.ChangeVisibility(Visibility.Visible);
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
