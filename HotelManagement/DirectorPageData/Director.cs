using BLL.Interfaces;
using BLL.Models.CheckinModel;
using System;
using System.ComponentModel;

namespace HotelManagement.DirectorPageData
{
    public class Director : IDirector
    {
        private readonly IDbInfo dbInfo;
        public event PropertyChangedEventHandler DataChanged;
        private CheckInInfoExpanded info;
        private DateTime start, end;
        private string username, guests, roomRev, serviceRev, completeRev;
        public Director()
        {
            Clear();
            dbInfo = BLL.ServiceModules.IoC.Get<IDbInfo>();
        }
        public CheckInInfoExpanded Report
        {
            get
            {
                return info;
            }
            set
            {
                info = value;
                Guests = info.GuestNumber.ToString();
                RoomRevenue = info.TotalRoomRevenue.ToString();
                ServiceRevenue = info.TotalServiceRevenue.ToString();
                CompleteRevenue = (info.TotalRoomRevenue + info.TotalServiceRevenue).ToString();
                DataChanged?.Invoke(null, new PropertyChangedEventArgs("Report"));
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
                DataChanged?.Invoke(null, new PropertyChangedEventArgs("Username"));
            }
        }
        public DateTime Start
        {
            get
            {
                return start;
            }
            set
            {
                start = value;
            }
        }
        public DateTime End
        {
            get
            {
                return end;
            }
            set
            {
                end = value;
            }
        }

        public string Guests
        {
            get
            {
                return guests;
            }
            set
            {
                guests = "Всего гостей: " + value;
                DataChanged?.Invoke(null, new PropertyChangedEventArgs("Guests"));
            }
        }
        public string RoomRevenue
        {
            get
            {
                return roomRev;
            }
            set
            {
                roomRev = "Прибыль с комнат: " + value;
                DataChanged?.Invoke(null, new PropertyChangedEventArgs("RoomRevenue"));
            }
        }
        public string ServiceRevenue
        {
            get
            {
                return roomRev;
            }
            set
            {
                roomRev = "Прибыль с доп. услуг: " + value;
                DataChanged?.Invoke(null, new PropertyChangedEventArgs("ServiceRevenue"));
            }
        }
        public string CompleteRevenue
        {
            get
            {
                return roomRev;
            }
            set
            {
                roomRev = "Общая прибыль: " + value;
                DataChanged?.Invoke(null, new PropertyChangedEventArgs("CompleteRevenue"));
            }
        }

        public void GetReport() => Report = dbInfo.GetReport(start, end);
        public void Clear()
        {
            Username = "";
            start = DateTime.Now.AddYears(-1);
            end = DateTime.Now;
            Report = new CheckInInfoExpanded();
        }
    }
}
