using BLL.Models;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface IConvertationService
    {
        FoundAccount Convert(AccountData accountData);
        FoundGuest Convert(GuestData guestData);
    }
}
