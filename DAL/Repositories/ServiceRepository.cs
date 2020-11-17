using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ServiceRepository : IRepository<Service>
    {
        private HotelDB db;

        public ServiceRepository(HotelDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Service> GetList()
        {
            return db.Service.ToList();
        }

        public Service GetItem(int id)
        {
            return db.Service.Find(id);
        }

        public void Create(Service item)
        {
            db.Service.Add(item);
        }

        public void Update(Service item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Service item = db.Service.Find(id);
            if (item != null)
                db.Service.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
