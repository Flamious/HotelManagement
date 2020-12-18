using BLL.Interfaces;
using BLL.Models;
using BLL.Models.CheckinModel;
using BLL.Models.SearchModels;
using BLL.ServiceModules;
using DAL;
using DAL.Entities.Data;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    class CheckInService : ICheckInService
    {
        IDbManager db;
        IDbCrud crud;
        public CheckInService()
        {
            db = IoC.Get<IDbManager>();
            crud = IoC.Get<IDbCrud>();
        }
        public void CreateCheckIn(CompleteCheckIn checkIn)
        {

            crud.CreateCheckIn(new CheckInModel()
            {
                StartDate = checkIn.CheckIn.StartDate,
                EndDate = checkIn.CheckIn.EndDate,
                RoomId = checkIn.CheckIn.RoomId,
                RoomCost = checkIn.CheckIn.RoomCost,
                ServicesCost = checkIn.CheckIn.ServicesCost,
                LastEmployeeId = checkIn.CheckIn.LastEmployeeId
            });

            int checkInId = db.ChecksIn.GetList().First(i => i.EndDate == checkIn.CheckIn.EndDate && i.RoomId == checkIn.CheckIn.RoomId).CheckInId;
            for (int i = 0; i < checkIn.Guests.Count; i++)
            {
                int guestId;
                if(db.Guests.GetList().FirstOrDefault(j => j.GuestDocument == checkIn.GuestDocuments[i]) == null)
                {
                    crud.CreateGuest(new GuestModel
                    {
                        Surname = checkIn.Guests[i].Surname,
                        GuestName = checkIn.Guests[i].GuestName,
                        Patronymic = checkIn.Guests[i].Patronymic,
                        BirthDate = checkIn.Guests[i].BirthDate,
                        PhoneNumber = checkIn.Guests[i].PhoneNumber,
                        Document = checkIn.GuestDocuments[i]
                    });
                }
                guestId = db.Guests.GetList().FirstOrDefault(j => j.GuestDocument == checkIn.GuestDocuments[i]).GuestId;

                crud.CreateCheckInGuestConnection(new CheckInGuestModel()
                {
                    CheckInId = checkInId,
                    GuestID = guestId,
                    VisitNumber = 0
                });
            }

            foreach (ServiceData service in checkIn.Services)
            {
                if (service.NumberOfProvision > 0)
                    crud.CreateCheckInServiceConnection(new CheckInServiceModel()
                    {
                        ServiceId = service.ServiceId,
                        CheckInId = checkInId,
                        Number = service.NumberOfProvision
                    });
            }
        }
        public void EditCheckIn(CheckInModel checkIn, List<CheckInServiceModel> connection)
        {
            crud.UpdateCheckIn(checkIn);
            crud.UpdateCheckInService(connection);
        }
        public void DeleteCheckIn(int checkInId)
        {
            db.CheckInGuests.Delete(checkInId, true);
            db.CheckInServices.Delete(checkInId, true);
            db.ChecksIn.Delete(checkInId);
        }

    }
}

