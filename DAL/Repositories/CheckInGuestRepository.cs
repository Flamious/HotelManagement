using DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class CheckInGuestRepository : IDirectory<CheckInGuest>
    {
        private HotelDB db;

        public CheckInGuestRepository(HotelDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<CheckInGuest> GetList()
        {
            return db.CheckInGuest.ToList();
        }

        public CheckInGuest GetItem(int checkInId, int guestId)
        {
            return db.CheckInGuest.FirstOrDefault(i => i.CheckInId == checkInId && i.GuestID == guestId);
        }

        public void Create(CheckInGuest item)
        {
            db.CheckInGuest.Add(item);
        }

        public void Update(CheckInGuest item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id, bool isCheckInId)
        {
            CheckInGuest item;
            while (true)
            {
                if (isCheckInId) item = db.CheckInGuest.FirstOrDefault(i => i.CheckInId == id);
                else item = db.CheckInGuest.FirstOrDefault(i => i.GuestID == id);
                if (item != null)
                {
                    db.CheckInGuest.Remove(item);
                    Save();
                }
                else
                    break;
            }
        }
        public void Delete(int checkInId, int guestId)
        {
            CheckInGuest item = db.CheckInGuest.FirstOrDefault(i => i.CheckInId == checkInId && i.GuestID == guestId);
            if (item != null)
                db.CheckInGuest.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
