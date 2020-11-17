namespace DAL.Interfaces
{
    public interface IDbManager
    {
        IRepository<Account> Accounts { get; }
        IRepository<Adult> Adults { get; }
        IRepository<CheckIn> ChecksIn { get; }
        IRepository<Guest> Guests { get; }
        IRepository<Modifier> Modifiers { get; }
        IRepository<Service> Services { get; }
        IRepository<Room> Rooms { get; }
        IRepository<RoomType> RoomTypes { get; }
        ILoginRepository Login { get; }
        int Save();
    }
}
