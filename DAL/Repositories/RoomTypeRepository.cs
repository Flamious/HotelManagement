using DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class RoomTypeRepository : IRepository<RoomType>
    {
        private HotelDB db;

        public RoomTypeRepository(HotelDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<RoomType> GetList()
        {
            return db.RoomType.ToList();
        }

        public RoomType GetItem(int id)
        {
            return db.RoomType.Find(id);
        }

        public void Create(RoomType item)
        {
            db.RoomType.Add(item);
        }

        public void Update(RoomType item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            RoomType item = db.RoomType.Find(id);
            if (item != null)
                db.RoomType.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
