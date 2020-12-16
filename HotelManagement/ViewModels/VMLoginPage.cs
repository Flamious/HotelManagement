﻿using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using HotelManagement.DirectorPageData;
using HotelManagement.Employee;
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
        private readonly IEmployee employee;
        private readonly IDirector director;

        private RelayCommand loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new RelayCommand(obj =>
                {
                    var data = obj as LoginData;
                    if (string.IsNullOrEmpty(data.Login) || string.IsNullOrEmpty(data.PasswordBox.Password)) return;
                    AccountFullData account = authorization.FindAccount(data.Login, data.PasswordBox.Password) ?? null;

                    if (account == null) return;

                    Console.WriteLine(account.Modifier);
                    switch (account.Modifier.Trim(' '))
                    {
                        case "Employee":
                            employee.Username = account.GetFullName();
                            employee.Id = account.AccountId;
                            employee.CurrentPeriodIndex = 0;
                            employee.LoadList();
                            navigation.Navigate(new EmployeePage());
                            navigation.ChangeVisibility(Visibility.Visible);
                            break;
                        case "Director":
                            director.Clear();
                            director.Username = account.GetFullName();
                            navigation.Navigate(new DirectorPage());
                            navigation.ChangeVisibility(Visibility.Visible);
                            break;
                        default:
                            return;
                    }
                }));
            }
        }

        public VMLoginPage()
        {
            navigation = IoC.Get<INavigation>();
            authorization = BLL.ServiceModules.IoC.Get<IAuthorizationService>();
            employee = IoC.Get<IEmployee>();
            director = IoC.Get<IDirector>();
            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.VisibilityChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            employee.UserChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            employee.ListChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
        }
    }
}
