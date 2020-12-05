using BLL.Interfaces;
using BLL.Models;
using BLL.Models.CheckinModel;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DbInfoService : IDbInfo
    {
        IDbManager db;
        public DbInfoService(IDbManager repos)
        {
            db = repos;
        }
        public List<CheckInInfo> GetCheckInInfo(int period)
        {
            List<CheckInInfo> result = (from ci in db.ChecksIn.GetList()
                                        join g in db.Rooms.GetList() on ci.RoomId equals g.RoomId
                                        join ac in db.Accounts.GetList() on ci.LastEmployeeId equals ac.AccountId
                                        join m in db.Modifiers.GetList() on ac.ModifierId equals m.ModifierId
                                        where period == -1 ? ci.EndDate.AddDays(1).AddSeconds(-1) < DateTime.Now : period == 0 ? (ci.StartDate < DateTime.Now && ci.EndDate.AddDays(1).AddSeconds(-1) > DateTime.Now) : ci.StartDate > DateTime.Now
                                        select new CheckInInfo()
                                        {
                                            Id = ci.CheckInId,
                                            Dates = ci.StartDate.ToString("dd.MM.yyyy") + "-" + ci.EndDate.ToString("dd.MM.yyyy"),
                                            Room = g.RoomNumber,
                                            LastEmployee = ac.Surname.TrimEnd(' ') + " " + ac.Username[0] + ". " + ac.Patronymic[0] + ". [id: " + ac.AccountId + "]",
                                            Prices = "Комната: " + ci.RoomCost + "\n" +
                                            "Доп. услуги: " + ci.ServicesCost + "\n" +
                                            "Всего: " + (ci.ServicesCost + ci.RoomCost)
                                        }).ToList();
            foreach (CheckInInfo info in result)
            {
                List<string> guests = (from g in db.Guests.GetList()
                                       join c in db.CheckInGuests.GetList() on g.GuestId equals c.GuestID
                                       where c.CheckInId == info.Id
                                       select g.Surname.TrimEnd(' ') + " " + g.GuestName[0] + ". " + g.Patronymic[0] + ".\n"
                              ).ToList();
                string guestResult = "";
                foreach (string str in guests)
                {
                    guestResult += str;
                }
                info.Guests = guestResult.TrimEnd('\n');

                List<string> services = (from g in db.Services.GetList()
                                         join c in db.CheckInServices.GetList() on g.ServiceId equals c.ServiceId
                                         where c.CheckInId == info.Id
                                         select g.ServiceName.TrimEnd(' ') + " (" + c.Number + ")" + "\n"
                              ).ToList();
                string serviceResult = "";
                foreach (string str in services)
                {
                    serviceResult += str;
                }
                info.Services = serviceResult.TrimEnd('\n');
            }

            return result;
        }


        public List<GuestModel> FindGuests(int checkInId)
        {
            return db.CheckInGuests.GetList()
                .Where(i => i.CheckInId == checkInId)
                .Join(db.Guests.GetList(), i => i.GuestID, j => j.GuestId, (i, j) => new GuestModel
                {
                    GuestId = j.GuestId,
                    Surname = j.Surname.TrimEnd(' '),
                    GuestName = j.GuestName.TrimEnd(' '),
                    Patronymic = j.Patronymic.TrimEnd(' '),
                    BirthDate = j.BirthDate,
                    PhoneNumber = j.PhoneNumber.TrimEnd(' '),
                    Document = j.GuestDocument.TrimEnd(' ')
                })
                .ToList();
        }

        public List<CheckInServiceModel> FindServices(int checkInId)
        {
            return db.CheckInServices.GetList()
                .Where(i => i.CheckInId == checkInId)
                .Select(i => new CheckInServiceModel(i))
                .ToList();
        }

        public GuestModel FindGuest(string document)
        {
            return db.Guests.GetList()
               .Select(i => new GuestModel(i))
               .FirstOrDefault(i => i.Document == document);

        }
        public bool CheckGuest(int id, DateTime startDate, DateTime endDate)
        {
            List<CheckInModel> checksIn = (from cib in db.CheckInGuests.GetList()
                                           join ci in db.ChecksIn.GetList() on cib.CheckInId equals ci.CheckInId
                                           where cib.GuestID == id
                                           select new CheckInModel()
                                           {
                                               StartDate = ci.StartDate,
                                               EndDate = ci.EndDate
                                           }).ToList();
            endDate = endDate.AddDays(1).AddSeconds(-1);

            foreach(CheckInModel checkIn in checksIn)
            {
                if (checkIn.StartDate >= startDate && checkIn.StartDate <= endDate) return false;
                if (checkIn.EndDate >= startDate && checkIn.EndDate <= endDate) return false;
            }
            return true;
        }
    }
}
