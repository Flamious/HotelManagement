using BLL.Interfaces;
using BLL.Models.CheckinModel;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using Xceed.Words.NET;

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
                return serviceRev;
            }
            set
            {
                serviceRev = "Прибыль с доп. услуг: " + value;
                DataChanged?.Invoke(null, new PropertyChangedEventArgs("ServiceRevenue"));
            }
        }
        public string CompleteRevenue
        {
            get
            {
                return completeRev;
            }
            set
            {
                completeRev = "Общая прибыль: " + value;
                DataChanged?.Invoke(null, new PropertyChangedEventArgs("CompleteRevenue"));
            }
        }

        public void GetReport() => Report = dbInfo.GetReport(start, end);
        public void SaveReportToFile()
        {
            GetReport();
            string template = "../../Reports/template.docx";
            string report = "../../Reports/Reports/" + Start.ToString("dd.MM.yyyy") + "-" + End.ToString("dd.MM.yyyy") + ".docx";

            try
            {
                if (File.Exists(report))
                    File.Delete(report);
                File.Copy(template, report);
            }
            catch
            {
                MessageBoxResult result = MessageBox.Show("Отсутствует файл шаблона", "Ошибка", MessageBoxButton.OK);
                return;
            }

            DocX doc = DocX.Load(report);
            doc.ReplaceText("CURRENT_DATE", DateTime.Now.ToString("dd.MM.yyyy"));
            doc.ReplaceText("CHECKS_IN", Report.Info.Count.ToString());
            doc.ReplaceText("GUESTS", Report.GuestNumber.ToString());
            doc.ReplaceText("TOTAL_REVENUE", Report.CompleteRevenue.ToString());
            doc.ReplaceText("ROOM_REVENUE", Report.TotalRoomRevenue.ToString());
            doc.ReplaceText("SERVICE_REVENUE", Report.TotalServiceRevenue.ToString());
            doc.ReplaceText("PERIOD", Start.ToString("dd.MM.yyyy") + "-" + End.ToString("dd.MM.yyyy"));
            doc.ReplaceText("DIRECTOR_NAME", Username.Split('[')[0].TrimEnd(' '));
            var table = doc.AddTable(Report.Info.Count + 1, 6);
            table.Rows[0].Cells[0].Paragraphs[0].Append("Id");
            table.Rows[0].Cells[1].Paragraphs[0].Append("Даты");
            table.Rows[0].Cells[2].Paragraphs[0].Append("Комната");
            table.Rows[0].Cells[3].Paragraphs[0].Append("Гости");
            table.Rows[0].Cells[4].Paragraphs[0].Append("Доп. услуги");
            table.Rows[0].Cells[5].Paragraphs[0].Append("Сумма");

            for (int i = 0; i < Report.Info.Count; i++)
            {
                table.Rows[i + 1].Cells[0].Paragraphs[0].Append(Report.Info[i].Id.ToString());
                table.Rows[i + 1].Cells[1].Paragraphs[0].Append(Report.Info[i].Dates);
                table.Rows[i + 1].Cells[3].Paragraphs[0].Append(Report.Info[i].Room.ToString());
                table.Rows[i + 1].Cells[4].Paragraphs[0].Append(Report.Info[i].Guests);
                table.Rows[i + 1].Cells[5].Paragraphs[0].Append(Report.Info[i].Services);
                table.Rows[i + 1].Cells[2].Paragraphs[0].Append(Report.Info[i].Prices);
            }

            doc.ReplaceTextWithObject("TABLE_PLACE", table);
            doc.Save();
        }
        public void Clear()
        {
            Username = "";
            start = DateTime.Now.AddYears(-1);
            end = DateTime.Now;
            Report = new CheckInInfoExpanded();
        }
    }
}
