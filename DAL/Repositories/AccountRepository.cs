using DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        private HotelDB db;

        public AccountRepository(HotelDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Account> GetList()
        {
            return db.Account.ToList();
        }

        public Account GetItem(int id)
        {
            return db.Account.Find(id);
        }

        public void Create(Account item)
        {
            db.Account.Add(item);
        }

        public void Update(Account item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Account item = db.Account.Find(id);
            if (item != null)
                db.Account.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
