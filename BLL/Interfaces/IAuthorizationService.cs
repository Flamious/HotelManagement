using BLL.Models;

namespace BLL.Interfaces
{
    public interface IAuthorizationService
    {
        FoundAccount FindAccount(string login, string password);
        FoundGuest FindGuest(int accountId);
    }
}
