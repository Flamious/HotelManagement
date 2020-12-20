using BLL.Models;
using BLL.Models.SearchModels;
using HotelManagement.Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HotelManagement.CheckInMaking
{
    interface ICheckInRoom
    {
        event PropertyChangedEventHandler RoomInfoChanged;
        event PropertyChangedEventHandler RoomNumberChanged;

        bool IsEnabled { get; set; }
        string IsFreeRoomExist { get; set; }
        string RoomPrice { get; set; }
        string ServicePrice { get; set; }
        string FinalPrice { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        List<RoomTypeModel> RoomTypes { get; set; }
        List<Roominess> AvailableRoominess { get; set; }
        List<ServiceData> Services { get; set; }
        ServiceData CurrentService { get; set; }
        RoomTypeModel CurrentRoomType { get; set; }
        Roominess Roominess { get; set; }
        RoomCheckInData CurrentRoom { get; set; }
        List<RoomCheckInData> FreeRooms { get; set; }
        string Error { get; set; }
        void GetFreeRooms();
        void AddServiceProvision(string numStr);
        bool AddRoom();
        void RefillEverything();
        void LoadData();
        void Clear();
    }
}
