using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RoomRepository : IRepository<Room>
    {
        private HotelDB db;

        public RoomRepository(HotelDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Room> GetList()
        {
            return db.Room.ToList();
        }

        public Room GetItem(int id)
        {
            return db.Room.Find(id);
        }

        public void Create(Room item)
        {
            db.Room.Add(item);
        }

        public void Update(Room item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Room item = db.Room.Find(id);
            if (item != null)
                db.Room.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
