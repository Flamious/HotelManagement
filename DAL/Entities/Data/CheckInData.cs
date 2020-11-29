using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ServiceData
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int Number { get; set; }
    }

    public class CheckInData
    {
        public int GuestId { get; set; }
        public int CheckInId { get; set; }
        public int RoomNumber { get; set; }
        public int ServicesPrice { get; set; }
        public int RoomPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<ServiceData> Services { get; set; }
    }
}
