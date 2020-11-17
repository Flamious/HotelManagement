namespace DAL.Interfaces
{
    public interface IDbManager
    {
        IRepository<Account> Accounts { get; }
        IRepository<Guest> Guests { get; }
        IRepository<Modifier> Modifiers { get; }
        IRepository<CheckIn> ChecksIn { get; }
        IRepository<Service> Services { get; }
        IDirectory<CheckInServices> CheckInServices { get; }
        IRepository<Room> Rooms { get; }
        IRepository<RoomType> RoomTypes { get; }
        ILoginRepository Login { get; }
        int Save();
    }
}
