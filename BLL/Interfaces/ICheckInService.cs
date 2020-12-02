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
        List<RoomCheckInData> GetFreeRooms(DateTime startDate, DateTime endDate, string typeName, int roominess);
        void CreateCheckIn(CompleteCheckIn checkIn); 
    }
}
