using BLL.Interfaces;
using BLL.Models;
using BLL.Models.RegistrationModels;
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
    class VMRegistrationPage : VMBase
    {
        private readonly INavigation navigation;
        private readonly IRegistration registration;
        private readonly IRegistrationService registrationService;
        private readonly IAuthorizationService authorization;
        private readonly IGuest guest;

        private bool IsNewGuest { get; set; }
        public string Error => registration.Error;
        public GuestFullData guestData => registration.GuestFullData;

        public VMRegistrationPage()
        {
            navigation = IoC.Get<INavigation>();
            registration = IoC.Get<IRegistration>();
            guest = IoC.Get<IGuest>();
            authorization = BLL.ServiceModules.IoC.Get<IAuthorizationService>();
            registrationService = BLL.ServiceModules.IoC.Get<IRegistrationService>();
            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.VisibilityChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            registration.GuestDataChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            registration.ErrorChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            guest.CurrentGuestChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            registration.Error = "";
            IsNewGuest = true;
            registration.GuestFullData = new GuestFullData()
            {
                BirthDate = DateTime.Now
            };
        }

        private RelayCommand forwardCommand;
        public RelayCommand ForwardCommand
        {
            get
            {
                return forwardCommand ?? (forwardCommand = new RelayCommand(obj =>
                {
                    RegistrationData data = obj as RegistrationData;
                    registration.Error = registrationService.AddNewAccount(new RegistrationFullData()
                    {
                        GuestName = guestData.GuestName,
                        Surname = guestData.Surname,
                        Patronymic = guestData.Patronymic,
                        BirthDate = guestData.BirthDate,
                        PhoneNumber = guestData.PhoneNumber,
                        Login = guestData.Login,
                        CurrentPassword = "",
                        CheckingPassword = data.CheckingPassword.Password,
                        NewPassword = data.NewPassword.Password
                    });
                    if(string.IsNullOrEmpty(Error))
                    {
                        AccountFullData account = new AccountFullData();
                        account = authorization.FindAccount(guestData.Login, data.NewPassword.Password) ?? null;

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
                    }
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
                    if (IsNewGuest)
                    {
                        navigation.Navigate(new LoginPage());
                    }
                }));
            }
        }
    }
}
