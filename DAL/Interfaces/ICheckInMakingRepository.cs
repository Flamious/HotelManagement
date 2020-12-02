using DAL.Entities;
using DAL.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICheckInMakingRepository
    {
        List<RoomData> GetAllRooms(string typeName, int rominess);
        List<RoomData> GetOccupiedRooms(DateTime startDate, DateTime endDate, string typeName, int rominess);
        //void CreateCheckIn(CheckIn checkIn, List<GuestData> guests, List<ServiceData> services, int? employeeId);
        CheckIn GetCheckIn(int roomId, DateTime EndDate);
        Guest GetGuest(string document);
    }
}
