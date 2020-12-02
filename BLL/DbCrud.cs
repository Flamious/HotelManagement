using BLL.Interfaces;
using BLL.Models;
using DAL;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DbCrud : IDbCrud
    {
        IDbManager db;

        public DbCrud(IDbManager db)
        {
            this.db = db;
        }

        public List<RoomTypeModel> GetAllRoomTypes()
        {
            return db.RoomTypes.GetList().Select(i => new RoomTypeModel(i)).ToList();
        }
        public List<ServiceModel> GetAllServices()
        {
            return db.Services.GetList().Select(i => new ServiceModel(i)).ToList();
        }
        public void CreateGuest(GuestModel guest)
        {
            db.Guests.Create(new Guest()
            {
                Surname = guest.Surname,
                GuestName = guest.GuestName,
                Patronymic = guest.Patronymic,
                BirthDate = guest.BirthDate,
                PhoneNumber = guest.PhoneNumber,
                GuestDocument = guest.Document
            });
            Save();
        }
        public void CreateCheckIn(CheckInModel checkIn)
        {
            db.ChecksIn.Create(new CheckIn()
            {
                StartDate = checkIn.StartDate,
                EndDate = checkIn.EndDate,
                RoomId = checkIn.RoomId,
                RoomCost = checkIn.RoomCost,
                ServicesCost = checkIn.ServicesCost,
                LastEmployeeId = checkIn.LastEmployeeId
            });
            Save();
        }
        public void CreateCheckInGuestConnection(CheckInGuestModel connection)
        {
            db.CheckInGuests.Create(new CheckInGuest()
            {
                CheckInId = connection.CheckInId,
                GuestID = connection.GuestID,
                VisitNumber = 0
            });
            Save();
        }
        public void CreateCheckInServiceConnection(CheckInServiceModel connection)
        {
            db.CheckInServices.Create(new CheckInServices()
            {
                CheckInId = connection.CheckInId,
                ServiceId = connection.ServiceId,
                Number = connection.Number
            });
            Save();
        }
        public void UpdateGuest(GuestModel guest)
        {
            //Guest prevGuest = db.Guests.GetItem(guest.GuestId);
            //prevGuest.Surname = guest.Surname;
            //prevGuest.GuestName = guest.GuestName;
            //prevGuest.Patronymic = guest.Patronymic;
            //prevGuest.BirthDate = guest.BirthDate;
            //prevGuest.PhoneNumber = guest.PhoneNumber;
            //Save();
        }
        public void UpdateCheckIn(CheckInModel checkIn, List<ServiceModel> services, List<GuestModel> guests)
        {
            //CheckIn prevCheckIn = db.ChecksIn.GetItem(checkIn.CheckInId);
            //prevCheckIn.RoomId = checkIn.RoomId;
            //prevCheckIn.RoomCost = checkIn.RoomCost;
            //prevCheckIn.ServicesCost = checkIn.ServicesCost;
            //prevCheckIn.StartDate = checkIn.StartDate;
            //prevCheckIn.EndDate = checkIn.EndDate;
            //Save();
        }

        public void DeleteCheckIn(int checkInId)
        {
            //CheckIn checkIn = db.ChecksIn.GetItem(checkInId);
            //if (checkIn != null)
            //{
            //    db.CheckInServices.Delete(checkIn.CheckInId, true);
            //    db.ChecksIn.Delete(checkIn.CheckInId);
            //    Save();
            //}
        }

        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
