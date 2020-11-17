using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AdultRepository : IRepository<Adult>
    {
        private HotelDB db;

        public AdultRepository(HotelDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Adult> GetList()
        {
            return db.Adult.ToList();
        }

        public Adult GetItem(int id)
        {
            return db.Adult.Find(id);
        }

        public void Create(Adult item)
        {
            db.Adult.Add(item);
        }

        public void Update(Adult item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Adult item = db.Adult.Find(id);
            if (item != null)
                db.Adult.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
