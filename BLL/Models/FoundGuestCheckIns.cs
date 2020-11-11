using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    //public class FoundService
    //{
    //    public string ServiceName { get; set; }
    //    public int Number { get; set; }
    //}
    public class FoundGuestCheckIns
    {
        public int CheckInId { get; set; }
        public int RoomNumber { get; set; }
        public int ServicesPrice { get; set; }
        public int RoomPrice { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        //public List<FoundService> Services { get; set; }
        public string Services { get; set; } = "";

    }
}
