using BLL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IAuthorizationService
    {
        AccountFullData FindAccount(string login, string password);
        GuestFullData FindGuest(int accountId);
        List<GuestCheckInFullData> FindAllCheckIns(int guestId);
        GuestCheckInFullData FindClosestCheckIn(int guestId);
    }
}
