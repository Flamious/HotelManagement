using BLL.Models;
using BLL.Models.CheckinModel;
using BLL.Models.SearchModels;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IDbInfo
    {
        List<CheckInInfo> GetCheckInInfo(int period);
        CheckInInfoExpanded GetReport(DateTime start, DateTime end);
        List<GuestModel> FindGuests(int checkInId);
        List<CheckInServiceModel> FindServices(int checkInId);
        GuestModel FindGuest(string docuement);
        bool CheckGuest(int id, DateTime startDate, DateTime endDate);
        List<RoomCheckInData> GetFreeRooms(DateTime startDate, DateTime endDate, string typeName, int roominess);
        bool IsOldRoomFree(DateTime oldStart, DateTime oldEnd, DateTime start, DateTime end, int roomId, int checkInId, int roominess, RoomTypeModel type);
    }
}
