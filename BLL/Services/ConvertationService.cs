using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;

namespace BLL.Services
{
    public class ConvertationService : IConvertationService
    {
        public FoundAccount Convert(AccountData accountData)
        {
            return accountData == null ? null : new FoundAccount()
            {
                AccountID = accountData.AccountID,
                Login = accountData.Login,
                Password = accountData.Password,
                Modifier = accountData.Modifier
            };
        }

        public FoundGuest Convert(GuestData guestData)
        {
            return new FoundGuest()
            {
                AccountID = guestData.AccountID,
                GuestID = guestData.GuestID,
                Surname = guestData.Surname,
                GuestName = guestData.GuestName,
                Patronymic = guestData.Patronymic,
                BirthDate = guestData.BirthDate,
                PhoneNumber = guestData.PhoneNumber,
                Login = guestData.Login,
                Password = guestData.Password
            };
        }
    }
}
