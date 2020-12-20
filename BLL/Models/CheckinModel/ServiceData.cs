namespace BLL.Models.CheckinModel
{
    public class ServiceData
    {
        public int ServiceId { get; set; }
        public int NumberOfProvision { get; set; }

        public ServiceData() { }
        public ServiceData(CheckInServiceModel checkInServiceModel)
        {
            ServiceId = checkInServiceModel.ServiceId;
            NumberOfProvision = checkInServiceModel.Number;
        }
    }
}
