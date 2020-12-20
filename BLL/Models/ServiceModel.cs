using DAL;

namespace BLL.Models
{
    public class ServiceModel
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int PriceForOneProvision { get; set; }
        public ServiceModel() { }
        public ServiceModel(Service service)
        {
            ServiceId = service.ServiceId;
            ServiceName = service.ServiceName;
            PriceForOneProvision = service.PriceForOneProvision;
        }
    }
}
