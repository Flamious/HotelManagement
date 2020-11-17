using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ChildRepository : IRepository<Child>
    {
        private HotelDB db;

        public ChildRepository(HotelDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Child> GetList()
        {
            return db.Child.ToList();
        }

        public Child GetItem(int id)
        {
            return db.Child.Find(id);
        }

        public void Create(Child item)
        {
            db.Child.Add(item);
        }

        public void Update(Child item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Child item = db.Child.Find(id);
            if (item != null)
                db.Child.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
