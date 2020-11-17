using DAL.Interfaces;

namespace DAL.Repositories
{
    public class DbManager : IDbManager
    {
        private HotelDB db;
        private AccountRepository accountRepository;
        private GuestRepository guestRepository;
        private ModifierRepository modifierRepository;
        private CheckInRepository checkInRepository;
        private CheckInServiceRepository checkInServiceRepository;
        private RoomRepository roomRepository;
        private RoomTypeRepository roomTypeRepository;
        private ServiceRepository serviceRepository;
        private LoginRepository loginRepository;
        private RegistrationRepository registrationRepository;

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

        public IRepository<CheckIn> ChecksIn
        {
            get
            {
                if (checkInRepository == null)
                    checkInRepository = new CheckInRepository(db);
                return checkInRepository;
            }
        }
        public IDirectory<CheckInServices> CheckInServices
        {
            get
            {
                if (checkInServiceRepository == null)
                    checkInServiceRepository = new CheckInServiceRepository(db);
                return checkInServiceRepository;
            }
        }
        public IRepository<Room> Rooms
        {
            get
            {
                if (roomRepository == null)
                    roomRepository = new RoomRepository(db);
                return roomRepository;
            }
        }
        public IRepository<RoomType> RoomTypes
        {
            get
            {
                if (roomTypeRepository == null)
                    roomTypeRepository = new RoomTypeRepository(db);
                return roomTypeRepository;
            }
        }
        public IRepository<Service> Services
        {
            get
            {
                if (serviceRepository == null)
                    serviceRepository = new ServiceRepository(db);
                return serviceRepository;
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

        public IRegistrationRepository Registration
        {
            get
            {
                if (registrationRepository == null)
                    registrationRepository = new RegistrationRepository(db);
                return registrationRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
