using BLL.Models;
using DAL.Entities;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IConvertationService
    {
        AccountFullData Convert(AccountData accountData);
        List<CheckInFullData> Convert(List<CheckInDataGuest> checkInDataGuest);
        CheckInFullData Convert(CheckInDataGuest checkInDataGuest);
    }
}
