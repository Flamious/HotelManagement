using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
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
            this.navigation = IoC.Get<INavigation>();
            authorization = BLL.ServiceModules.IoC.Get<IAuthorizationService>();
        }
    }
}
