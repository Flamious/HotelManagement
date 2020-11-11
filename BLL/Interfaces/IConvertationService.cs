using BLL.Models;
using DAL.Entities;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IConvertationService
    {
        FoundAccount Convert(AccountData accountData);
        FoundGuest Convert(GuestData guestData);
        List<FoundGuestCheckIns> Convert(List<CheckInDataGuest> checkInDataGuest);
    }
}
