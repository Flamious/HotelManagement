using System.Collections.Generic;

namespace BLL.Models.CheckinModel
{
    public class CompleteCheckIn
    {
        public CheckInModel CheckIn { get; set; }
        public List<GuestModel> Guests { get; set; }
        public List<ServiceData> Services { get; set; }
        public List<string> GuestDocuments { get; set; }
        RoomTypeModel RoomType { get; set; }
    }
}
