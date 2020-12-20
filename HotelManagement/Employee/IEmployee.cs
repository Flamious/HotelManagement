using BLL.Models.CheckinModel;
using HotelManagement.Structures;
using System.Collections.Generic;
using System.ComponentModel;

namespace HotelManagement.Employee
{
    public interface IEmployee
    {
        event PropertyChangedEventHandler UserChanged;
        event PropertyChangedEventHandler ListChanged;
        List<CheckInInfo> CheckIns { get; set; }
        List<Period> Periods { get; set; }
        string Username { get; set; }
        int? Id { get; set; }
        int CurrentCheckInIndex { get; set; }
        int CurrentPeriodIndex { get; set; }
        void LoadList();
        void DeleteElement();
        void EditElement();
    }
}
