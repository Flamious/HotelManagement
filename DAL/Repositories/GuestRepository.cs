using DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class GuestRepository : IRepository<Guest>
    {
        private HotelDB db;

        public GuestRepository(HotelDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Guest> GetList()
        {
            return db.Guest.ToList();
        }

        public Guest GetItem(int id)
        {
            return db.Guest.Find(id);
        }

        public void Create(Guest item)
        {
            db.Guest.Add(item);
        }

        public void Update(Guest item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Guest item = db.Guest.Find(id);
            if (item != null)
                db.Guest.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
