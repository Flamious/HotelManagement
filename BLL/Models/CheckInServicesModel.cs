using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CheckInServicesModel
    {
        public int CheckInId { get; set; }
        public int ServiceId { get; set; }
        public int Number { get; set; }
        public CheckInServicesModel() { }
        public CheckInServicesModel(CheckInServices checkInServices)
        {
            CheckInId = checkInServices.CheckInId;
            ServiceId = checkInServices.ServiceId;
            Number = checkInServices.Number;
        }
    }
}
