﻿using HotelManagement.CheckInMaking;
using HotelManagement.CompleteCheckInModel;
using HotelManagement.Employee;
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
    class VMAdmit : VMBase
    {
        private readonly INavigation navigation;
        private readonly ICompleteCheckIn completeCheckIn;
        private readonly ICheckInGuest checkInGuest;
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
            employee = IoC.Get<IEmployee>();

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
                    completeCheckIn.AddCheckIn();
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
                    checkInGuest.Back();
                    navigation.Navigate(new GuestPage());
                }));
            }
        }
    }
}
