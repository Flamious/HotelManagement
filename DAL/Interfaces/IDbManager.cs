namespace DAL.Interfaces
{
    public interface IDbManager
    {
        IRepository<Account> Accounts { get; }
        IRepository<Guest> Guests { get; }
        IRepository<Modifier> Modifiers { get; }
        ILoginRepository Login { get; }
        int Save();
    }
}
