using BLL.Interfaces;
using BLL.Models;
using BLL.Models.SearchModels;
using HotelManagement.Converters;
using HotelManagement.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.CompleteCheckInModel
{
    public class CompleteCheckIn : ICompleteCheckIn
    {
        ICheckInService checkInService;
        private CheckInModel checkIn;
        private List<GuestModel> guests;
        private List<ServiceData> services;
        private RoomTypeModel roomType;
        private List<GuestDocuments> guestDocuments;
        private int roominess;
        private int roomNumber;
        public void Clear()
        {
            CheckIn = new CheckInModel();
            Guests.Clear();
            Services.Clear();
            RoomType = new RoomTypeModel();
            GuestDocuments.Clear();
            roominess = roomNumber = -1;
        }
        public CompleteCheckIn()
        {
            checkInService = BLL.ServiceModules.IoC.Get<ICheckInService>();
            checkIn = new CheckInModel();
            guests = new List<GuestModel>();
            services = new List<ServiceData>();
        }
        public int RoomNumber
        {
            get
            {
                return roomNumber;
            }
            set
            {
                roomNumber = value;
            }
        }
        public List<GuestDocuments> GuestDocuments
        {
            get
            {
                return guestDocuments;
            }
            set
            {
                guestDocuments = value;
            }
        }
        public int Roominess
        {
            get
            {
                return roominess;
            }
            set
            {
                roominess = value;
            }
        }
        public CheckInModel CheckIn
        {
            get
            {
                return checkIn;
            }
            set
            {
                checkIn = value;
            }
        }
        public List<GuestModel> Guests
        {
            get
            {
                return guests;
            }
            set
            {
                guests = value;
            }
        }
        public List<ServiceData> Services
        {
            get
            {
                return services;
            }
            set
            {
                services = value;
            }
        }
        public RoomTypeModel RoomType
        {
            get
            {
                return roomType;
            }
            set
            {
                roomType = value;
            }
        }
        public void AddCheckIn()
        {
            List<string> documents = new List<string>();
            foreach (GuestDocuments guestDocument in GuestDocuments)
            {
                documents.Add(guestDocument.Document);
            }
            List<BLL.Models.CheckinModel.ServiceData> services = new List<BLL.Models.CheckinModel.ServiceData>();
            foreach (ServiceData service in Services)
            {
                services.Add(new BLL.Models.CheckinModel.ServiceData()
                {
                    ServiceId = service.ServiceId,
                    NumberOfProvision = service.NumberOfProvision
                });
            }

            BLL.Models.CheckinModel.CompleteCheckIn completeCheckIn = new BLL.Models.CheckinModel.CompleteCheckIn()
            {
                CheckIn = CheckIn,
                GuestDocuments = documents,
                Guests = Guests,
                Services = services
            };
            checkInService.CreateCheckIn(completeCheckIn);
            Clear();
        }
        public void EditCheckIn()
        {

        }

        public string GetServicesToAdmit()
        {
            string result = "";
            if (Services.Count == 0) return "Доп. услуги остутствуют";
            for (int i = 0; i < Services.Count; i++)
            {
                if (Services[i].NumberOfProvision == 0) continue;
                if (i != 0 && result != "") result += "\n";
                result += Services[i].ServiceName + ": " + Services[i].NumberOfProvision;
            }
            return result;
        }
        public List<string> GetGuestsToAdmit()
        {
            string tem;
            List<string> result = new List<string>();
            for (int i = 0; i < Guests.Count; i++)
            {
                tem = "";
                tem += "Фамилия: " + Guests[i].Surname + "\n"
                    + "Имя: " + Guests[i].GuestName + "\n"
                    + "Отчество: " + Guests[i].Patronymic + "\n"
                    + (GuestDocuments[i].IsChild ? "№ Свидетельства о рождении: " : "Серия/номер паспорта: ")
                    + (GuestDocuments[i].IsChild ? GuestDocuments[i].Document : GuestInfoConverter.ConvertPassport(GuestDocuments[i].Document)) + "\n"
                    + (string.IsNullOrEmpty(Guests[i].PhoneNumber) ? "" : "Телефон: " + GuestInfoConverter.ConvertPhone(Guests[i].PhoneNumber));
                result.Add(tem);
            }
            return result;
        }
    }
}
