using BLL.Models;
using BLL.Models.CheckinModel;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ICheckInService
    {
        void CreateCheckIn(CompleteCheckIn checkIn);
        void EditCheckIn(CheckInModel checkIn, List<CheckInServiceModel> connection);
        void DeleteCheckIn(int checkInId);
    }
}
