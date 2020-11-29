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
        public event PropertyChangedEventHandler GuestInfoChanged;

        private List<GuestModel> guests;
        private List<GuestDocuments> guestDocuments;
        private string surname, guestName, patronymic, phoneNumber;
        private DateTime birthDate;
        private int currentGuestIndex;
        private string document;
        private bool isChild;

        public CheckInGuest()
        {
            completeCheckIn = IoC.Get<ICompleteCheckIn>();
            Guests = new List<GuestModel>();
            guestDocuments = new List<GuestDocuments>();
            CurrentGuestIndex = 0;
            FillFields(true);
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

        public void AddGuest()
        {
            if (currentGuestIndex == Guests.Count)
            {
                Guests.Add(new GuestModel()
                {
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
        }
        public void Back()
        {
            CurrentGuestIndex--;
            FillFields(false);
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
    }
}
