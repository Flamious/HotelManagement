using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using System.Collections.Generic;

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

        public List<FoundGuestCheckIns> Convert(List<CheckInDataGuest> checkInDataList)
        {
            if (checkInDataList.Count == 0) return null;
            FoundGuestCheckIns guestCheckIns;
            List<FoundGuestCheckIns> result = new List<FoundGuestCheckIns>();
            foreach (CheckInDataGuest checkInData in checkInDataList)
            {
                guestCheckIns = new FoundGuestCheckIns()
                {
                    CheckInId = checkInData.CheckInId,
                    RoomNumber = checkInData.RoomNumber,
                    RoomPrice = checkInData.RoomPrice,
                    ServicesPrice = checkInData.ServicesPrice,
                    StartDate = checkInData.StartDate.ToString("dd.MM.yyyy"),
                    EndDate = checkInData.EndDate.ToString("dd.MM.yyyy")
                };

                foreach (ServiceDataGuest service in checkInData.Services)
                {
                    if (!(guestCheckIns.Services == "")) guestCheckIns.Services += "\n"; 
                    guestCheckIns.Services += service.ServiceName.Trim(' ') + "(" + service.Number.ToString() + ")";
                }
                result.Add(guestCheckIns);
            }

            return result;
        }
    }
}
