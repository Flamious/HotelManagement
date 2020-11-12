﻿using BLL.Interfaces;
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

        public List<FoundGuestCheckIn> Convert(List<CheckInDataGuest> checkInDataList)
        {
            if (checkInDataList.Count == 0) return null;
            FoundGuestCheckIn guestCheckIns;
            List<FoundGuestCheckIn> result = new List<FoundGuestCheckIn>();
            foreach (CheckInDataGuest checkInData in checkInDataList)
            {
                guestCheckIns = Convert(checkInData);
                result.Add(guestCheckIns);
            }
            return result;
        }

        public FoundGuestCheckIn Convert(CheckInDataGuest checkInDataGuest)
        {
            if (checkInDataGuest == null) return null;
            FoundGuestCheckIn result = new FoundGuestCheckIn()
            {
                GuestId = checkInDataGuest.GuestId,
                RoomNumber = checkInDataGuest.RoomNumber,
                CheckInId = checkInDataGuest.CheckInId,
                RoomPrice = checkInDataGuest.RoomPrice,
                ServicesPrice = checkInDataGuest.ServicesPrice,
                StartDateString = checkInDataGuest.StartDate.ToString("dd.MM.yyyy"),
                EndDateString = checkInDataGuest.EndDate.ToString("dd.MM.yyyy"),
                StartDate = checkInDataGuest.StartDate,
                EndDate = checkInDataGuest.EndDate,
                Services = new List<FoundService>(),
                ServicesString = ""

            };

            foreach (ServiceDataGuest service in checkInDataGuest.Services)
            {
                if (!(result.ServicesString == "")) result.ServicesString += "\n";
                result.ServicesString += service.ServiceName.Trim(' ') + "(" + service.Number.ToString() + ")";

                result.Services.Add(new FoundService()
                {
                    ServiceId = service.ServiceId,
                    ServiceName = service.ServiceName,
                    Number = service.Number
                });
            }
            return result;
        }
    }
}

