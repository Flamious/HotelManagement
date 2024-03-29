﻿using DAL;
using System;

namespace BLL.Models
{
    public class CheckInModel
    {
        public int CheckInId { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoomCost { get; set; }
        public int ServicesCost { get; set; }
        public int? LastEmployeeId { get; set; }

        public CheckInModel() { }
        public CheckInModel(CheckIn checkIn)
        {
            CheckInId = checkIn.CheckInId;
            RoomId = checkIn.RoomId;
            StartDate = checkIn.StartDate;
            EndDate = checkIn.EndDate;
            RoomCost = checkIn.RoomCost;
            ServicesCost = checkIn.ServicesCost;
            LastEmployeeId = checkIn.LastEmployeeId;
        }
    }
}
