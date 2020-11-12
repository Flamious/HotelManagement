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
        public List<GuestModel> GetAllGuests()
        {
            return db.Guests.GetList().Select(i => new GuestModel(i)).ToList();
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

        void CreateGuest(GuestModel guest);
        void CreateAccount(AccountModel account);
        void CreateCheckIn(CheckInModel checkIn);
        void CreateCheckInServicesConnection(CheckInServicesModel checkInServices);

        void UpdateGuest(GuestModel guest);
        void UpdateAccount(AccountModel account);
        void UpdateCheckIn(CheckInModel checkIn);
        void UpdateCheckInServicesConnection(CheckInServicesModel checkInServices);

        void DeleteCheckIn(int checkInid)
        {
            CheckIn checkIn = db.ChecksIn.GetItem(checkInid);
            if (checkIn != null)
            {
                List<int> rates = db.Record_Books.GetList().Where(i => i.Student_ID == id).Select(i => i.Record_Book_ID).ToList();
                foreach (int record_book_ID in rates)
                {
                    Record_Book record_Book = db.Record_Books.GetItem(record_book_ID);
                    if (record_Book != null)
                    {
                        db.Record_Books.Delete(record_Book.Record_Book_ID);
                    }
                }
                db.Students.Delete(checkIn.Student_ID);
                Save();
            }
        }
    }
}
