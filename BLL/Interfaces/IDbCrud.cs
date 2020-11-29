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
        void CreateGuest(GuestModel guest);
        void CreateCheckIn(CheckInModel checkIn);
        void CreateCheckInGuestConnection(CheckInGuestModel connection);
        void CreateCheckInServiceConnection(CheckInServiceModel connection);
        void UpdateGuest(GuestModel guest);
        void UpdateCheckIn(CheckInModel checkIn, List<ServiceModel> services, List<GuestModel> guests);
        void DeleteCheckIn(int checkInid);
    }
}
