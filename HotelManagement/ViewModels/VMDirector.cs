﻿using BLL.Models.CheckinModel;
using HotelManagement.DirectorPageData;
using System;
using System.Collections.Generic;

namespace HotelManagement.ViewModels
{
    class VMDirector : VMBase
    {
        private readonly IDirector director;
        public string Username => director.Username;
        public DateTime Start
        {
            get
            {
                return director.Start;
            }
            set
            {
                director.Start = value;
            }
        }
        public DateTime End
        {
            get
            {
                return director.End;
            }
            set
            {
                director.End = value;
            }
        }
        public List<CheckInInfo> Report => director.Report.Info;
        public string Guests => director.Guests;
        public string RoomRevenue => director.RoomRevenue;
        public string ServiceRevenue => director.ServiceRevenue;
        public string CompleteRevenue => director.CompleteRevenue;
        public VMDirector()
        {
            director = IoC.Get<IDirector>();
            director.DataChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
        }
        private RelayCommand getReport;
        public RelayCommand GetReport
        {
            get
            {
                return getReport ?? (getReport = new RelayCommand(obj =>
                {
                    director.GetReport();
                }));
            }
        }
        private RelayCommand saveReport;
        public RelayCommand SaveReport
        {
            get
            {
                return saveReport ?? (saveReport = new RelayCommand(obj =>
                {
                    director.SaveReportToFile();
                }));
            }
        }
    }
}
