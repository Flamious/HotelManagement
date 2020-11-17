using BLL.Models;
using DAL.Entities;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IConvertationService
    {
        AccountFullData Convert(AccountData accountData);
        List<GuestCheckInFullData> Convert(List<CheckInDataGuest> checkInDataGuest);
        GuestCheckInFullData Convert(CheckInDataGuest checkInDataGuest);
    }
}
