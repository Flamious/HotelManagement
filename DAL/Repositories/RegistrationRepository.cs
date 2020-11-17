using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private HotelDB db;

        public RegistrationRepository(HotelDB dbcontext)
        {
            this.db = dbcontext;
        }
        public bool IsLoginAbsent(string login) => db.Account.FirstOrDefault(i => i.Login == login) == null;
    }
}
