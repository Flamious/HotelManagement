using BLL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IAuthorizationService
    {
        AccountFullData FindAccount(string login, string password);
        List<CheckInFullData> FindAllCheckIns(int guestId);
    }
}
