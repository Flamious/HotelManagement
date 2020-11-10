using DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class ModifierRepository : IRepository<Modifier>
    {
        private HotelDB db;

        public ModifierRepository(HotelDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Modifier> GetList()
        {
            return db.Modifier.ToList();
        }

        public Modifier GetItem(int id)
        {
            return db.Modifier.Find(id);
        }

        public void Create(Modifier item)
        {
            db.Modifier.Add(item);
        }

        public void Update(Modifier item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Modifier item = db.Modifier.Find(id);
            if (item != null)
                db.Modifier.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
