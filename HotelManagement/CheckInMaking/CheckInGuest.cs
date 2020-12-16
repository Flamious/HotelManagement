using BLL.Interfaces;
using BLL.Models;
using HotelManagement.CompleteCheckInModel;
using HotelManagement.Converters;
using HotelManagement.Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.CheckInMaking
{
    public class CheckInGuest : ICheckInGuest
    {
        private readonly ICompleteCheckIn completeCheckIn;
        private readonly IDbInfo dbInfo;
        public event PropertyChangedEventHandler GuestInfoChanged;

        private List<GuestModel> guests;
        private List<GuestDocuments> guestDocuments;
        private string surname, guestName, patronymic, phoneNumber;
        private DateTime birthDate;
        private int currentGuestIndex;
        private string document, error;
        private bool isChild;

        public CheckInGuest()
        {
            completeCheckIn = IoC.Get<ICompleteCheckIn>();
            dbInfo = BLL.ServiceModules.IoC.Get<IDbInfo>();
            Clear();
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
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                GuestInfoChanged?.Invoke(null, new PropertyChangedEventArgs("Surname"));
            }
        }
        public string GuestName
        {
            get
            {
                return guestName;
            }
            set
            {
                guestName = value;
                GuestInfoChanged?.Invoke(null, new PropertyChangedEventArgs("GuestName"));
            }
        }
        public string Patronymic
        {
            get
            {
                return patronymic;
            }
            set
            {
                patronymic = value;
                GuestInfoChanged?.Invoke(null, new PropertyChangedEventArgs("Patronymic"));
            }
        }
        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }
            set
            {
                birthDate = value;
                GuestInfoChanged?.Invoke(null, new PropertyChangedEventArgs("BirthDate"));
            }
        }
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
                GuestInfoChanged?.Invoke(null, new PropertyChangedEventArgs("PhoneNumber"));
            }
        }
        public int CurrentGuestIndex
        {
            get
            {
                return currentGuestIndex;
            }
            set
            {
                currentGuestIndex = value;
                GuestInfoChanged?.Invoke(null, new PropertyChangedEventArgs("CurrentGuestIndex"));
            }
        }
        public string Document
        {
            get
            {
                return document;
            }
            set
            {
                document = value;
                GuestInfoChanged?.Invoke(null, new PropertyChangedEventArgs("Document"));
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
                GuestInfoChanged?.Invoke(null, new PropertyChangedEventArgs("Error"));
            }
        }
        public bool IsChild
        {
            get
            {
                return isChild;
            }
            set
            {
                isChild = value;
                GuestInfoChanged?.Invoke(null, new PropertyChangedEventArgs("IsChild"));
            }
        }

        public bool AddGuest()
        {
            if (!CheckData()) return false;
            if (currentGuestIndex == Guests.Count)
            {
                Guests.Add(new GuestModel()
                {
                    GuestId = -1,
                    Surname = Surname,
                    GuestName = GuestName,
                    Patronymic = Patronymic,
                    BirthDate = BirthDate,
                    PhoneNumber = PhoneNumber
                });
                GuestDocuments.Add(new GuestDocuments(IsChild, Document));
            }
            else
            {
                Guests[CurrentGuestIndex] = new GuestModel()
                {
                    Surname = Surname,
                    GuestName = GuestName,
                    Patronymic = Patronymic,
                    BirthDate = BirthDate,
                    PhoneNumber = PhoneNumber
                };
                GuestDocuments[CurrentGuestIndex] = new GuestDocuments(IsChild, Document);
            }
            Console.WriteLine(Guests[CurrentGuestIndex].Surname);
            CurrentGuestIndex++;
            if (CurrentGuestIndex == Guests.Count) FillFields(true);
            else FillFields(false);

            return true;
        }
        public void Back()
        {
            if(Guests.Count == 0)
            {
                FillFields(true);
            }
            else
            {
                if (CurrentGuestIndex > 0)
                {
                    CurrentGuestIndex--;
                    FillFields(false);
                }
            }
            Error = "";
        }

        public void EndAdding()
        {
            completeCheckIn.Guests = Guests;
            completeCheckIn.GuestDocuments = GuestDocuments;
        }
        private void FillFields(bool IsNew)
        {
            if (IsNew)
            {
                Surname = string.Empty;
                GuestName = "";
                Patronymic = "";
                PhoneNumber = "";
                Document = "";
                BirthDate = DateTime.Now;
                IsChild = false;
            }
            else
            {
                Surname = Guests[CurrentGuestIndex].Surname;
                GuestName = Guests[CurrentGuestIndex].GuestName;
                Patronymic = Guests[CurrentGuestIndex].Patronymic;
                BirthDate = Guests[CurrentGuestIndex].BirthDate;
                PhoneNumber = Guests[CurrentGuestIndex].PhoneNumber;
                IsChild = GuestDocuments[CurrentGuestIndex].IsChild;
                Document = GuestDocuments[CurrentGuestIndex].Document;
            }

        }

        public void LoadGuests()
        {
            Guests = completeCheckIn.Guests;
            GuestDocuments = completeCheckIn.GuestDocuments;
            CurrentGuestIndex = 0;
            FillFields(false);
        }

        public void Clear()
        {
            Error = "";
            Guests = new List<GuestModel>();
            guestDocuments = new List<GuestDocuments>();
            CurrentGuestIndex = 0;
            FillFields(true);
        }

        public bool FindGuest()
        {
            GuestModel guest = dbInfo.FindGuest(Document);
            if (guest == null) return false;
            if (!dbInfo.CheckGuest(guest.GuestId, completeCheckIn.CheckIn.StartDate, completeCheckIn.CheckIn.EndDate))
            {
                Error = "Гость уже заселен";
                return false;
            }
            if (!CheckList()) return false;
            bool isChildLocal = guest.Document.Length == 10 ? false : true;
            if (currentGuestIndex == Guests.Count)
            {
                Guests.Add(guest);
                GuestDocuments.Add(new GuestDocuments(isChildLocal, guest.Document));
            }
            else
            {
                Guests[CurrentGuestIndex] = guest;
                GuestDocuments[CurrentGuestIndex] = new GuestDocuments(isChildLocal, guest.Document);
            }
            FillFields(false);
            return true;
        }

        public void ClearFoundGuest()
        {
            Guests[CurrentGuestIndex].GuestId = -1;
            FillFields(true);
        }
        public bool IsGuestExist
        {
            get
            {
                if (currentGuestIndex == Guests.Count) return false;
                else
                {
                    if (Guests[CurrentGuestIndex].GuestId > 0) return true;
                    else return false;
                }
            }
        }

        private bool CheckData()
        {
            if (string.IsNullOrEmpty(Surname))
            {
                Error = "Введите фамилию";
                return false;
            }
            if (string.IsNullOrEmpty(GuestName))
            {
                Error = "Введите имя";
                return false;
            }
            if (string.IsNullOrEmpty(Patronymic))
            {
                Error = "Введите отчество";
                return false;
            }
            if (IsChild == true)
            {
                if (Document.Length != 6 || !IsDigitOnly(Document))
                {
                    Error = "Неверно введен документ";
                    return false;
                }
            }
            else
            {
                if (Document.Length != 10 || !IsDigitOnly(Document))
                {
                    Error = "Неверно введен документ";
                    return false;
                }
            }
            if (string.IsNullOrEmpty(PhoneNumber))
            {
                PhoneNumber = "";
            }
            else
            if (PhoneNumber.Length != 11 || !IsDigitOnly(PhoneNumber))
            {
                Error = "Неверно введен телефон";
                return false;
            }

            if (dbInfo.FindGuest(Document) != null)
            {
                if (CurrentGuestIndex == Guests.Count)
                {
                    Error = "Гость уже есть в базе данных.\nИспользуйте поиск";
                    return false;
                }
                else
                {
                    if (Guests[CurrentGuestIndex].GuestId < 0)
                    {
                        Error = "Гость уже есть в базе данных.\nИспользуйте поиск";
                        return false;
                    }
                }
            }
            if (!CheckList()) return false;
            Error = "";
            return true;
        }

        private bool CheckList()
        {

            for (int i = 0; i < Guests.Count; i++)
            {
                if (i == CurrentGuestIndex) continue;
                else
                {
                    if (GuestDocuments[i].Document == Document)
                    {
                        Error = "Гость с такими документами\nуже в списке";
                        if (CurrentGuestIndex != Guests.Count)
                            Guests[CurrentGuestIndex] = new GuestModel() { GuestId = -1 };
                        return false;
                    }
                }
            }
            return true;
        }
        private bool IsDigitOnly(string s)
        {
            foreach(char c in s)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
    }
}
