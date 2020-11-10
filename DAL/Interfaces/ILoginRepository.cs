using DAL.Entities;

namespace DAL.Interfaces
{
    public interface ILoginRepository
    {
        AccountData FindAccount(string login, string password);
        GuestData FindGuest(int accountId);
    }
}
