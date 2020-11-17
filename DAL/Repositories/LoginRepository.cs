using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private HotelDB db;

        public LoginRepository(HotelDB dbcontext)
        {
            this.db = dbcontext;
        }
        public AccountData FindAccount(string login, string password)
        {
            return db.Account
                .Join(db.Modifier, i => i.ModifierId, j => j.ModifierId, (i, j) => new AccountData()
                {
                    AccountID = i.AccountId,
                    Login = i.Login,
                    Password = i.Password,
                    Modifier = j.ModifierName
                })
                .FirstOrDefault(i => i.Login == login && i.Password == password);
        }

        public List<CheckInData> FindAllPreviousCheckIns(int guestId)
        {
            return db.CheckIn
                .Where(i => i.GuestId == guestId && i.EndDate < DateTime.Now)
                .Join(db.Room, i => i.RoomId, j => j.RoomId, (i, j) => new CheckInData
                {
                    CheckInId = i.CheckInId,
                    RoomNumber = j.RoomNumber,
                    StartDate = i.StartDate,
                    EndDate = i.EndDate,
                    RoomPrice = i.RoomCost,
                    ServicesPrice = i.ServicesCost,
                    Services = db.Service
                    .Join(db.CheckInServices, k => k.ServiceId, l => l.ServiceId, (k, l) => new
                    {
                        ServicId = k.ServiceId,
                        ServiceName = k.ServiceName,
                        Number = l.Number,
                        CheckInId = l.CheckInId
                    })
                    .Where(k => k.CheckInId == i.CheckInId)
                    .Select(k => new ServiceDataGuest()
                    {
                        ServiceId = k.ServicId,
                        ServiceName = k.ServiceName,
                        Number = k.Number
                    }).ToList()

                }).ToList();
        }
    }
}
