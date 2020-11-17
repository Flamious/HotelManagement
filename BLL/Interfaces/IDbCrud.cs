﻿using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDbCrud
    {
        List<AccountModel> GetAllAccounts();
        List<GuestModel> GetAllGuests();
        List<ModifierModel> GetAllModifiers();
        List<RoomModel> GetAllRooms();
        List<RoomTypeModel> GetAllRoomTypes();
        List<CheckInModel> GetAllChecksIn();
        List<ServiceModel> GetAllServices();
        List<CheckInServicesModel> GetAllCheckInServices();

        void CreateGuest(GuestModel guest);
        void CreateAccount(AccountModel account);
        void CreateCheckIn(CheckInModel checkIn);
        void CreateCheckInServicesConnection(CheckInServicesModel checkInServices);

        void UpdateGuest(GuestModel guest);
        void UpdateAccount(AccountModel account);
        void UpdateCheckIn(CheckInModel checkIn);
        void UpdateCheckInServicesConnection(CheckInServicesModel checkInServices);

        void DeleteCheckIn(int checkInid);
    }
}