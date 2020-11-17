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
        void CreateGuest(GuestModel guest);
        void CreateCheckIn(CheckInModel checkIn, List<ServiceModel> services, List<GuestModel> guests);
        void UpdateGuest(GuestModel guest);
        void UpdateCheckIn(CheckInModel checkIn, List<ServiceModel> services, List<GuestModel> guests);
        void DeleteCheckIn(int checkInid);
    }
}
