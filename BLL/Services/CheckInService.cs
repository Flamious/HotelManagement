﻿using BLL.Interfaces;
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
        ICheckInMakingRepository checkInMaking;
        public CheckInService(IDbManager repos)
        {
            db = repos;
            crud = IoC.Get<IDbCrud>();
            checkInMaking = IoC.Get<ICheckInMakingRepository>();
        }


        public List<RoomCheckInData> GetFreeRooms(DateTime startDate, DateTime endDate, string typeName, int roominess)
        {
            List<RoomData> AllRooms = db.CheckInMaking.GetAllRooms(typeName, roominess);
            List<RoomData> OccupiedRoom = db.CheckInMaking.GetOccupiedRooms(startDate, endDate, typeName, roominess);

            if (!(OccupiedRoom.Count == 0))
            {
                foreach (RoomData room in OccupiedRoom)
                {
                    foreach (RoomData freeRoom in AllRooms.ToArray())
                    {
                        if (freeRoom.RoomId == room.RoomId)
                        {
                            AllRooms.Remove(freeRoom);
                        }
                    }
                }
            }
            List<RoomCheckInData> result = new List<RoomCheckInData>();
            if (AllRooms.Count == 0) return null;
            foreach (RoomData room in AllRooms)
            {
                result.Add(new RoomCheckInData()
                {
                    RoomId = room.RoomId,
                    RoomNumber = room.RoomNumber,
                });
            }
            return result;
        }
        public void CreateCheckIn(CompleteCheckIn checkIn)
        {
            //CheckIn newCheckIn = new CheckIn()
            //{
            //    StartDate = checkIn.CheckIn.StartDate,
            //    EndDate = checkIn.CheckIn.EndDate,
            //    RoomCost = checkIn.CheckIn.RoomCost,
            //    ServicesCost = checkIn.CheckIn.ServicesCost,
            //    LastEmployeeId = checkIn.CheckIn.LastEmployeeId,
            //    RoomId = checkIn.CheckIn.RoomId
            //};
            //List<DAL.Entities.GuestData> guestData = new List<DAL.Entities.GuestData>();
            //foreach (GuestModel guestModel in checkIn.Guests)
            //{
            //    guestData.Add(new DAL.Entities.GuestData()
            //    {
            //        Surname = guestModel.Surname,
            //        GuestName = guestModel.GuestName,
            //        Patronymic = guestModel.Patronymic,
            //        BirthDate = guestModel.BirthDate,
            //        PhoneNumber = guestModel.PhoneNumber,
            //        Document = guestModel.PhoneNumber,
            //        IsChild = guestModel is ChildModel
            //    });
            //}
            //List<DAL.Entities.ServiceData> serviceData = new List<DAL.Entities.ServiceData>();
            //foreach(ServiceData service in checkIn.Services)
            //{
            //    serviceData.Add(new DAL.Entities.ServiceData()
            //    {
            //        ServiceId = service.ServiceId,
            //        Number = service.NumberOfProvision
            //    });
            //}
            //checkInService.CreateCheckIn(newCheckIn, guestData, serviceData, checkIn.CheckIn.LastEmployeeId);

            crud.CreateCheckIn(new CheckInModel()
            {
                StartDate = checkIn.CheckIn.StartDate,
                EndDate = checkIn.CheckIn.EndDate,
                RoomId = checkIn.CheckIn.RoomId,
                RoomCost = checkIn.CheckIn.RoomCost,
                ServicesCost = checkIn.CheckIn.ServicesCost,
                LastEmployeeId = checkIn.CheckIn.LastEmployeeId
            });

            int checkInId = checkInMaking.GetCheckIn(checkIn.CheckIn.RoomId, checkIn.CheckIn.EndDate).CheckInId;
            for (int i = 0; i < checkIn.Guests.Count; i++)
            {
                int guestId;
                if (checkInMaking.GetGuest(checkIn.GuestDocuments[i]) == null)
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
                guestId = checkInMaking.GetGuest(checkIn.GuestDocuments[i]).GuestId;

                crud.CreateCheckInGuestConnection(new CheckInGuestModel()
                {
                    CheckInId = checkInId,
                    GuestID = guestId,
                    VisitNumber = 0
                });
            }

            foreach (ServiceData service in checkIn.Services)
            {
                crud.CreateCheckInServiceConnection(new CheckInServiceModel()
                {
                    ServiceId = service.ServiceId,
                    CheckInId = checkInId,
                    Number = service.NumberOfProvision
                });
            }
        }
    }
}

