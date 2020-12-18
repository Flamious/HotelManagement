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
        IDirectory<CheckInGuest> CheckInGuests { get; }
        IRepository<Room> Rooms { get; }
        IRepository<RoomType> RoomTypes { get; }
        int Save();
    }
}
