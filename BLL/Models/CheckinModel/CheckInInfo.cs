using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
