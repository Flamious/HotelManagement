using DAL.Entities;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface ILoginRepository
    {
        AccountData FindAccount(string login, string password);
        List<CheckInData> FindAllPreviousCheckIns(int guestId);
    }
}
