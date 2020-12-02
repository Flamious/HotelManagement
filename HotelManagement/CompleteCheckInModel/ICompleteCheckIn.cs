using BLL.Models;
using BLL.Models.SearchModels;
using HotelManagement.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.CompleteCheckInModel
{
    public interface ICompleteCheckIn
    {
        CheckInModel CheckIn { get; set; }
        List<GuestModel> Guests { get; set; }
        List<ServiceData> Services { get; set; }
        List<GuestDocuments> GuestDocuments { get; set; }
        RoomTypeModel RoomType { get; set; }
        int RoomNumber { get; set; }
        int Roominess { get; set; }
        void AddCheckIn();
        void EditCheckIn();
        string GetServicesToAdmit();
        List<string> GetGuestsToAdmit();
        void Clear();
    }
}
