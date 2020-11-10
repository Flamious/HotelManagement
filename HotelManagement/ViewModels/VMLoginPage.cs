using BLL.Interfaces;
using HotelManagement.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.ViewModels
{
    class VMLoginPage : VMBase
    {
        private readonly INavigation navigation;

        private RelayCommand loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new RelayCommand(obj =>
                {
                    //todo logic for login
                    navigation.Navigate(new GuestPage());
                }));
            }
        }

        public VMLoginPage()
        {
            navigation = IoC.Get<INavigation>();
        }
    }
}
