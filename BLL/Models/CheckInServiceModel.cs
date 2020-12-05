using DAL;

namespace BLL.Models
{
    public class CheckInServiceModel
    {
        public int CheckInId { get; set; }
        public int ServiceId { get; set; }
        public int Number { get; set; }
        public CheckInServiceModel() { }
        public CheckInServiceModel(CheckInServices checkInServices)
        {
            CheckInId = checkInServices.CheckInId;
            ServiceId = checkInServices.ServiceId;
            Number = checkInServices.Number;
        }
    }
}
