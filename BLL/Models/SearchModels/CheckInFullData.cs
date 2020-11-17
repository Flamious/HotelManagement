using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class FoundService
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int Number { get; set; }
    }
    public class CheckInFullData
    {
        public int GuestId { get; set; }
        public int CheckInId { get; set; } = -1;
        public int RoomNumber { get; set; } = -1;
        public int ServicesPrice { get; set; } = -1;
        public int RoomPrice { get; set; } = -1;
        public string StartDateString { get; set; } = "";
        public string EndDateString { get; set; } = "";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ServicesString { get; set; } = "";
        public List<FoundService> Services { get; set; }


    }
}
