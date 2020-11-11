using BLL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IAuthorizationService
    {
        FoundAccount FindAccount(string login, string password);
        FoundGuest FindGuest(int accountId);
        List<FoundGuestCheckIns> FindAllCheckIns(int guestId);
    }
}
