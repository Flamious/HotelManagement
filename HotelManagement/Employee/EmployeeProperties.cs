using BLL.Interfaces;
using BLL.Models.CheckinModel;
using HotelManagement.CheckInMaking;
using HotelManagement.CompleteCheckInModel;
using HotelManagement.Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Employee
{
    public class EmployeeProperties : IEmployee
    {
        private readonly IDbInfo dbInfo;
        private readonly ICheckInService checkInService;
        private readonly ICompleteCheckIn completeCheckIn;
        private readonly ICheckInRoom checkInRoom;
        private readonly ICheckInGuest checkInGuest;
        public event PropertyChangedEventHandler UserChanged;
        public event PropertyChangedEventHandler ListChanged;
        private List<CheckInInfo> checkIns;
        private List<Period> periods;
        private string username;
        private int? id;
        private int currentPeriodIndex;
        private int currentCheckInIndex;

        public EmployeeProperties()
        {
            dbInfo = BLL.ServiceModules.IoC.Get<IDbInfo>();
            checkInService = BLL.ServiceModules.IoC.Get<ICheckInService>();
            completeCheckIn = IoC.Get<ICompleteCheckIn>();
            checkInRoom = IoC.Get<ICheckInRoom>();
            checkInGuest = IoC.Get<ICheckInGuest>();
            Periods = new List<Period>();
            Periods.Add(new Period(0, "Текущие заселения"));
            Periods.Add(new Period(1, "Предстоящие заселения"));
            Periods.Add(new Period(-1, "Прошедшие заселения"));
            CurrentPeriodIndex = 0;
        }
        public int? Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public int CurrentPeriodIndex
        {
            get
            {
                return currentPeriodIndex;
            }
            set
            {
                currentPeriodIndex = value;
                ListChanged?.Invoke(null, new PropertyChangedEventArgs("CurrentPeriodIndex"));
                LoadList();
            }
        }
        public int CurrentCheckInIndex
        {
            get
            {
                return currentCheckInIndex;
            }
            set
            {
                currentCheckInIndex = value;
                ListChanged?.Invoke(null, new PropertyChangedEventArgs("CurrentCheckInIndex"));
            }
        }
        public List<CheckInInfo> CheckIns
        {
            get
            {
                return checkIns;
            }
            set
            {
                checkIns = value;
                ListChanged?.Invoke(null, new PropertyChangedEventArgs("CheckIns"));
            }
        }
        public List<Period> Periods
        {
            get
            {
                return periods;
            }
            set
            {
                periods = value;
            }
        }
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                UserChanged?.Invoke(null, new PropertyChangedEventArgs("Username"));
            }
        }

        public void LoadList()
        {
            CheckIns = dbInfo.GetCheckInInfo(Periods[CurrentPeriodIndex].Value);
            CurrentCheckInIndex = -1;
        }

        public void DeleteElement()
        {
            checkInService.DeleteCheckIn(CheckIns[CurrentCheckInIndex].Id);
            LoadList();
        }
        public void EditElement()
        {
            completeCheckIn.Id = CheckIns[CurrentCheckInIndex].Id;
            completeCheckIn.LoadData(CheckIns[CurrentCheckInIndex].Id);
            checkInRoom.LoadData();
            checkInGuest.LoadGuests();
        }
    }
}
