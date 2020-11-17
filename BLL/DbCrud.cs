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

        public List<AccountModel> GetAllAccounts()
        {
            return db.Accounts.GetList().Select(i => new AccountModel(i)).ToList();
        }
        public List<CheckInModel> GetAllChecksIn()
        {
            return db.ChecksIn.GetList().Select(i => new CheckInModel(i)).ToList();
        }
        public List<CheckInServicesModel> GetAllCheckInServices()
        {
            return db.CheckInServices.GetList().Select(i => new CheckInServicesModel(i)).ToList();
        }
        public List<RoomModel> GetAllRooms()
        {
            return db.Rooms.GetList().Select(i => new RoomModel(i)).ToList();
        }
        public List<RoomTypeModel> GetAllRoomTypes()
        {
            return db.RoomTypes.GetList().Select(i => new RoomTypeModel(i)).ToList();
        }
        public List<ServiceModel> GetAllServices()
        {
            return db.Services.GetList().Select(i => new ServiceModel(i)).ToList();
        }
        public List<ModifierModel> GetAllModifiers()
        {
            return db.Modifiers.GetList().Select(i => new ModifierModel(i)).ToList();
        }

        public void CreateAccount(AccountModel account)
        {
            db.Accounts.Create(new Account()
            {
                Login = account.Login,
                ModifierId = account.ModifierId,
                Password = account.Password
            });
            Save();
        }
        public void CreateCheckIn(CheckInModel checkIn)
        {
            db.ChecksIn.Create(new CheckIn()
            {
                GuestId = checkIn.GuestId,
                EndDate = checkIn.EndDate,
                RoomCost = checkIn.RoomCost,
                RoomId = checkIn.RoomId,
                ServicesCost = checkIn.ServicesCost,
                StartDate = checkIn.StartDate
            });
            Save();
        }
        public void CreateCheckInServicesConnection(CheckInServicesModel checkInServices)
        {
            db.CheckInServices.Create(new CheckInServices()
            {
                CheckInId = checkInServices.CheckInId,
                ServiceId = checkInServices.ServiceId,
                Number = checkInServices.Number
            });
            Save();
        }

        public void UpdateAccount(AccountModel account)
        {
            Account prevAccount = db.Accounts.GetItem(account.AccountId);
            prevAccount.Login = account.Login;
            prevAccount.Password = account.Password;
            prevAccount.ModifierId = account.ModifierId;
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
            Save();
        }
        public void UpdateCheckInServicesConnection(CheckInServicesModel checkInServices)
        {
            CheckInServices prevDictionary = db.CheckInServices.GetItem(checkInServices.CheckInId, checkInServices.ServiceId);
            prevDictionary.Number = checkInServices.Number;
            Save();
        }

        public void DeleteCheckIn(int checkInId)
        {
            CheckIn checkIn = db.ChecksIn.GetItem(checkInId);
            if (checkIn != null)
            {
                db.CheckInServices.Delete(checkIn.CheckInId, true);
                db.ChecksIn.Delete(checkIn.CheckInId);
                Save();
            }
        }

        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
