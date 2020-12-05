using BLL.Models;
using BLL.Models.CheckinModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDbInfo
    {
        List<CheckInInfo> GetCheckInInfo(int period);
        List<GuestModel> FindGuests(int checkInId);
        List<CheckInServiceModel> FindServices(int checkInId);
        GuestModel FindGuest(string docuement);
        bool CheckGuest(int id, DateTime startDate, DateTime endDate);
    }
}
