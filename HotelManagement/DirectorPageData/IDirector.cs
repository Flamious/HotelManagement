﻿using BLL.Models.CheckinModel;
using System;
using System.ComponentModel;

namespace HotelManagement.DirectorPageData
{
    public interface IDirector
    {
        event PropertyChangedEventHandler DataChanged;
        string Username { get; set; }
        CheckInInfoExpanded Report { get; set; }
        DateTime Start { get; set; }
        DateTime End { get; set; }
        string Guests { get; set; }
        string RoomRevenue { get; set; }
        string ServiceRevenue { get; set; }
        string CompleteRevenue { get; set; }
        void GetReport();
        void SaveReportToFile();
        void Clear();

    }
}
