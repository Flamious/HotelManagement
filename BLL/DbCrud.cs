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

        public CheckInModel GetCheckIn(int id)
        {
            return new CheckInModel(db.ChecksIn.GetItem(id));
        }
        public RoomModel GetRoom(int id)
        {
            return new RoomModel(db.Rooms.GetItem(id));
        }
        public ServiceModel GetService(int id)
        {
            return new ServiceModel(db.Services.GetItem(id));
        }
        public RoomTypeModel GetRoomType(int id)
        {
            return new RoomTypeModel(db.RoomTypes.GetItem(id));
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
        public void UpdateCheckIn(CheckInModel checkIn)
        {
            CheckIn prevCheckIn = db.ChecksIn.GetItem(checkIn.CheckInId);
            prevCheckIn.RoomId = checkIn.RoomId;
            prevCheckIn.RoomCost = checkIn.RoomCost;
            prevCheckIn.ServicesCost = checkIn.ServicesCost;
            prevCheckIn.StartDate = checkIn.StartDate;
            prevCheckIn.EndDate = checkIn.EndDate;
            prevCheckIn.LastEmployeeId = checkIn.LastEmployeeId;

            
            Save();
        }
        public void UpdateCheckInService(List<CheckInServiceModel> connections)
        {
            db.CheckInServices.Delete(connections[0].CheckInId, true);
            foreach (CheckInServiceModel checkInService in connections)
            {
                if (checkInService.Number > 0)
                    db.CheckInServices.Create(new CheckInServices()
                    {
                        ServiceId = checkInService.ServiceId,
                        CheckInId = checkInService.CheckInId,
                        Number = checkInService.Number
                    });
            }
            Save();
        }
        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }

    }
}
