using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDbCrud
    {
        List<RoomTypeModel> GetAllRoomTypes();
        List<ServiceModel> GetAllServices();
        CheckInModel GetCheckIn(int id);
        RoomModel GetRoom(int id);
        ServiceModel GetService(int id);
        RoomTypeModel GetRoomType(int id);
        void CreateGuest(GuestModel guest);
        void CreateCheckIn(CheckInModel checkIn);
        void CreateCheckInGuestConnection(CheckInGuestModel connection);
        void CreateCheckInServiceConnection(CheckInServiceModel connection);
        void UpdateCheckIn(CheckInModel checkIn);
        void UpdateCheckInService(List<CheckInServiceModel> connections);
    }
}
