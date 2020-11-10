using DAL.Interfaces;

namespace DAL.Repositories
{
    public class DbManager : IDbManager
    {
        private HotelDB db;
        private AccountRepository accountRepository;
        private GuestRepository guestRepository;
        private ModifierRepository modifierRepository;
        private LoginRepository loginRepository;

        public DbManager()
        {
            db = new HotelDB();
        }

        public IRepository<Account> Accounts
        {
            get
            {
                if (accountRepository == null)
                    accountRepository = new AccountRepository(db);
                return accountRepository;
            }
        }

        public IRepository<Guest> Guests
        {
            get
            {
                if (guestRepository == null)
                    guestRepository = new GuestRepository(db);
                return guestRepository;
            }
        }

        public IRepository<Modifier> Modifiers
        {
            get
            {
                if (modifierRepository == null)
                    modifierRepository = new ModifierRepository(db);
                return modifierRepository;
            }
        }


        public ILoginRepository Login
        {
            get
            {
                if (loginRepository == null)
                    loginRepository = new LoginRepository(db);
                return loginRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
