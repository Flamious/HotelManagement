using BLL.Interfaces;
using BLL.Models;
using BLL.Models.SearchModels;
using HotelManagement.CompleteCheckInModel;
using HotelManagement.Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace HotelManagement.CheckInMaking
{
    public class CheckInRoom : ICheckInRoom
    {
        public event PropertyChangedEventHandler RoomInfoChanged;
        public event PropertyChangedEventHandler RoomNumberChanged;
        private readonly IDbCrud dbCrud;
        private readonly IDbInfo dbInfo;
        private readonly ICompleteCheckIn completeCheckIn;
        public CheckInRoom()
        {
            dbInfo = BLL.ServiceModules.IoC.Get<IDbInfo>();
            dbCrud = BLL.ServiceModules.IoC.Get<IDbCrud>();
            completeCheckIn = IoC.Get<ICompleteCheckIn>();
            Clear();
        }
        private bool isEnabled;
        private string isFreeRoomExist;
        private DateTime startDate, oldStart;
        private DateTime endDate, oldEnd;
        private List<RoomTypeModel> roomTypes;
        private List<ServiceData> services;
        private ServiceData currentService;
        private RoomTypeModel currentRoomType;
        private RoomCheckInData currentRoom, lastRoom = null;
        private List<RoomCheckInData> freeRooms;
        private List<Roominess> availableRoominess;
        private Roominess rominess;
        private string error;
        private string roomPrice;
        private string servicePrice;
        private string finalPrice;
        public string RoomPrice
        {
            get
            {
                return roomPrice;
            }
            set
            {
                roomPrice = value;
                RoomInfoChanged?.Invoke(null, new PropertyChangedEventArgs("RoomPrice"));
            }
        }
        public string ServicePrice
        {
            get
            {
                return servicePrice;
            }
            set
            {
                servicePrice = value;
                RoomInfoChanged?.Invoke(null, new PropertyChangedEventArgs("ServicePrice"));
            }
        }
        public string FinalPrice
        {
            get
            {
                return finalPrice;
            }
            set
            {
                finalPrice = value;
                RoomInfoChanged?.Invoke(null, new PropertyChangedEventArgs("FinalPrice"));
            }
        }
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                isEnabled = value;
                RoomInfoChanged?.Invoke(null, new PropertyChangedEventArgs("IsEnabled"));
            }
        }
        public string IsFreeRoomExist
        {
            get
            {
                return isFreeRoomExist;
            }
            set
            {
                isFreeRoomExist = value;
                RoomInfoChanged?.Invoke(null, new PropertyChangedEventArgs("IsFreeRoomExist"));
            }
        }
        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
                RoomInfoChanged?.Invoke(null, new PropertyChangedEventArgs("StartDate"));
                GetFreeRooms();
            }
        }
        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                if (completeCheckIn.Id > 0)
                {
                    endDate = value;
                    RoomInfoChanged?.Invoke(null, new PropertyChangedEventArgs("EndDate"));
                }
                else
                {
                    endDate = value;
                    RoomInfoChanged?.Invoke(null, new PropertyChangedEventArgs("EndDate"));
                    GetFreeRooms();
                }
            }
        }
        public List<RoomTypeModel> RoomTypes
        {
            get
            {
                return roomTypes;
            }
            set
            {
                roomTypes = value;
                RoomInfoChanged?.Invoke(null, new PropertyChangedEventArgs("RoomTypes"));
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
                RoomInfoChanged?.Invoke(null, new PropertyChangedEventArgs("Services"));
            }
        }
        public ServiceData CurrentService
        {
            get
            {
                return currentService;
            }
            set
            {
                currentService = value;
                if (value == null)
                {
                    IsEnabled = false;
                    SetPrices();
                }
                else
                {
                    IsEnabled = true;
                }
                RoomInfoChanged?.Invoke(null, new PropertyChangedEventArgs("CurrentService"));
            }
        }
        public RoomTypeModel CurrentRoomType
        {
            get
            {
                return currentRoomType;
            }
            set
            {
                currentRoomType = value;
                RoomInfoChanged?.Invoke(null, new PropertyChangedEventArgs("CurrentRoomType"));
                GetFreeRooms();
            }
        }
        public Roominess Roominess
        {
            get
            {
                return rominess;
            }
            set
            {
                rominess = value;
                RoomInfoChanged?.Invoke(null, new PropertyChangedEventArgs("Rominess"));
                GetFreeRooms();
            }
        }
        public RoomCheckInData CurrentRoom
        {
            get
            {
                return currentRoom;
            }
            set
            {
                currentRoom = value;
                RoomNumberChanged?.Invoke(null, new PropertyChangedEventArgs("CurrentRoom"));
            }
        }
        public List<RoomCheckInData> FreeRooms
        {
            get
            {
                return freeRooms;
            }
            set
            {
                freeRooms = value;
                RoomNumberChanged?.Invoke(null, new PropertyChangedEventArgs("FreeRooms"));
                if (value == null)
                {
                    IsFreeRoomExist = "Нет комнат";
                }
                else IsFreeRoomExist = "Номер комнаты";
            }
        }
        public string Error
        {
            get
            {
                return error;
            }
            set
            {
                error = value;
                RoomInfoChanged?.Invoke(null, new PropertyChangedEventArgs("Error"));
            }
        }
        public List<Roominess> AvailableRoominess
        {
            get
            {
                return availableRoominess;
            }
            set
            {
                availableRoominess = value;
                RoomInfoChanged?.Invoke(null, new PropertyChangedEventArgs("AvailableRoominess"));
            }
        }
        public void GetFreeRooms()
        {
            try
            {
                if (EndDate <= StartDate) throw new Exception("Начальная дата должна быть меньше конечной");
                if (CurrentRoomType == null || Roominess == null) throw new Exception("");
                Error = "";
                FreeRooms = dbInfo.GetFreeRooms(StartDate, EndDate, CurrentRoomType.TypeName, Roominess.Number);
                if (FreeRooms == null) FreeRooms = new List<RoomCheckInData>();
                if (lastRoom != null)
                    if (dbInfo.IsOldRoomFree(oldStart, oldEnd, StartDate, EndDate, lastRoom.RoomId, completeCheckIn.CheckIn.CheckInId, Roominess.Number, CurrentRoomType))
                    {
                        FreeRooms.Add(lastRoom);
                        FreeRooms = new List<RoomCheckInData>(FreeRooms);
                    }
            }
            catch (Exception e)
            {
                Error = e.Message;
                FreeRooms = null;
                return;
            }
            finally
            {
                SetPrices();
            }
        }

        public void AddServiceProvision(string numStr)
        {
            try
            {
                int num;
                if (CurrentService == null) throw new Exception("Доп. услуга не выбрана");
                if (!int.TryParse(numStr, out num)) throw new Exception("Неверный формат");
                if (num < 0) throw new Exception("Число меньше нуля");
                foreach (ServiceData service in Services)
                {
                    if (service.ServiceId == CurrentService.ServiceId)
                    {
                        service.NumberOfProvision = num;
                        break;
                    }
                }
                Services = new List<ServiceData>(Services);
                CurrentService = null;
            }
            catch (Exception e)
            {
                Error = e.Message;
                return;
            }
        }
        private void SetPrices()
        {
            ServicePrice = "Цена доп. услуг: " + GetServicesPrice().ToString();
            RoomPrice = "Цена комнаты: " + GetRoomPrice().ToString();
            FinalPrice = "Всего: " + (GetRoomPrice() + GetServicesPrice()).ToString();
        }
        private int GetRoomPrice()
        {
            if (CurrentRoomType == null || Roominess == null || EndDate < StartDate) return 0;
            return Roominess.Number * CurrentRoomType.PriceForOnePersonPerDay * (EndDate - StartDate).Days;
        }
        private int GetServicesPrice()
        {
            int result = 0;
            if (Services != null)
                foreach (ServiceData service in Services)
                {
                    result += service.NumberOfProvision * service.PriceForOneProvision;
                }
            return result;
        }

        public bool AddRoom()
        {
            if (CurrentRoom == null)
            {
                Error = "Комната не выбрана";
                return false;
            }
            if(completeCheckIn.Id > 0)
                if(oldEnd < EndDate)
                {
                    Error = "Нельзя увеличивать период.\nСоздайте новое заселение";
                    return false;
                }
            if(StartDate>=EndDate)
            {
                Error = "Начальная дата должна быть меньше конечной";
                return false;
            }
            completeCheckIn.CheckIn = new CheckInModel()
            {
                RoomCost = GetRoomPrice(),
                StartDate = StartDate,
                EndDate = EndDate,
                RoomId = CurrentRoom.RoomId,
                ServicesCost = GetServicesPrice()
            };
            completeCheckIn.Roominess = Roominess.Number;
            completeCheckIn.RoomType = CurrentRoomType;
            completeCheckIn.Services = Services;
            completeCheckIn.RoomNumber = CurrentRoom.RoomNumber;
            return true;
        }
        public void RefillEverything()
        {
            CurrentRoomType = RoomTypes.Find(i => i.TypeId == completeCheckIn.RoomType.TypeId);
            Roominess = AvailableRoominess.Find(i => i.Number == completeCheckIn.Roominess);
            StartDate = completeCheckIn.CheckIn.StartDate;
            EndDate = completeCheckIn.CheckIn.EndDate;
            GetFreeRooms();
            CurrentRoom = FreeRooms.Find(i => i.RoomId == completeCheckIn.CheckIn.RoomId);
            Services = dbCrud.GetAllServices().Select(i => new ServiceData(i)).ToList();
            foreach (ServiceData service in completeCheckIn.Services)
            {
                Services.Find(i => i.ServiceId == service.ServiceId).NumberOfProvision = service.NumberOfProvision;
            }
        }
        public void LoadData()
        {
            oldEnd = completeCheckIn.CheckIn.EndDate;
            oldStart = completeCheckIn.CheckIn.StartDate;
            lastRoom = new RoomCheckInData()
            {
                RoomId = completeCheckIn.CheckIn.RoomId,
                RoomNumber = completeCheckIn.RoomNumber
            };

            RefillEverything();
        }
        public void Clear()
        {
            RoomTypes = dbCrud.GetAllRoomTypes();
            AvailableRoominess = new List<Roominess>();
            for (int i = 0; i < 4; i++) AvailableRoominess.Add(new Roominess() { Number = i + 1 });
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(1);
            Services = dbCrud.GetAllServices().Select(i => new ServiceData(i)).ToList();
            IsFreeRoomExist = "Введите данные";
            lastRoom = null;
        }
    }
}
