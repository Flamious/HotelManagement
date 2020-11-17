using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CheckInRepository : IRepository<CheckIn>
    {
        private HotelDB db;

        public CheckInRepository(HotelDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<CheckIn> GetList()
        {
            return db.CheckIn.ToList();
        }

        public CheckIn GetItem(int id)
        {
            return db.CheckIn.Find(id);
        }

        public void Create(CheckIn item)
        {
            db.CheckIn.Add(item);
        }

        public void Update(CheckIn item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            CheckIn item = db.CheckIn.Find(id);
            if (item != null)
                db.CheckIn.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
