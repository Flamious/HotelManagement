using BLL.Models;
using BLL.Models.CheckinModel;
using BLL.Models.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICheckInService
    {
        void CreateCheckIn(CompleteCheckIn checkIn);
        void EditCheckIn(CheckInModel checkIn, List<CheckInServiceModel> connection);
        void DeleteCheckIn(int checkInId);
    }
}
