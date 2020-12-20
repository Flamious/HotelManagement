using System.Collections.Generic;

namespace BLL.Models.CheckinModel
{
    public class CheckInInfo
    {
        public int Id { get; set; }
        public int Room { get; set; }
        public string Dates { get; set; }
        public string Guests { get; set; }
        public string Services { get; set; }
        public string Prices { get; set; }
        public string LastEmployee { get; set; }
    }

    public class CheckInInfoExpanded
    {
        public List<CheckInInfo> Info { get; set; }
        public int TotalRoomRevenue { get; set; }
        public int TotalServiceRevenue { get; set; }
        public int CompleteRevenue => TotalRoomRevenue + TotalServiceRevenue;
        public int GuestNumber { get; set; }
        public CheckInInfoExpanded()
        {
            Info = new List<CheckInInfo>();
            TotalRoomRevenue = 0;
            TotalServiceRevenue = 0;
        }

    }
}
