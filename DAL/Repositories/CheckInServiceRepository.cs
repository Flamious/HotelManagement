using DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class CheckInServiceRepository : IDirectory<CheckInServices>
    {
        private HotelDB db;

        public CheckInServiceRepository(HotelDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<CheckInServices> GetList()
        {
            return db.CheckInServices.ToList();
        }

        public CheckInServices GetItem(int checkInId, int serviceId)
        {
            return db.CheckInServices.FirstOrDefault(i => i.CheckInId == checkInId && i.ServiceId == serviceId);
        }
        public void Create(CheckInServices item)
        {
            db.CheckInServices.Add(item);
        }

        public void Update(CheckInServices item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id, bool isCheckInId)
        {
            CheckInServices item;
            while (true)
            {
                if (isCheckInId) item = db.CheckInServices.FirstOrDefault(i => i.CheckInId == id);
                else item = db.CheckInServices.FirstOrDefault(i => i.ServiceId == id);
                if (item != null)
                {
                    db.CheckInServices.Remove(item);
                    Save();
                }
                else
                    break;
            }
        }
        public void Delete(int checkInId, int serviceId)
        {
            CheckInServices item = db.CheckInServices.FirstOrDefault(i => i.CheckInId == checkInId && i.ServiceId == serviceId);
            if (item != null)
                db.CheckInServices.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
