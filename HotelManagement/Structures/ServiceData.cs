﻿using BLL.Models;

namespace HotelManagement.Structures
{
    public class ServiceData
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int PriceForOneProvision { get; set; }
        public int NumberOfProvision { get; set; }
        public string DisplayedName => ServiceName + "(" + NumberOfProvision.ToString() + ")";
        public ServiceData(ServiceModel service, int numberOfProvision = 0)
        {
            ServiceId = service.ServiceId;
            ServiceName = service.ServiceName.TrimEnd(' ');
            PriceForOneProvision = service.PriceForOneProvision;
            NumberOfProvision = numberOfProvision;
        }
    }
}
