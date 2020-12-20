using BLL.Models;
using HotelManagement.Structures;
using System.Collections.Generic;

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
        int Id { get; set; }
        void AddCheckIn();
        void EditCheckIn();
        string GetServicesToAdmit();
        List<string> GetGuestsToAdmit();
        void LoadData(int checkInId);
        void Clear();
    }
}
