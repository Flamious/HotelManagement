using BLL.Models;
using HotelManagement.Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HotelManagement.CheckInMaking
{
    public interface ICheckInGuest
    {
        event PropertyChangedEventHandler GuestInfoChanged;
        List<GuestModel> Guests { get; set; }
        int CurrentGuestIndex { get; set; }
        string Document { get; set; }
        string Error { get; set; }
        bool IsChild { get; set; }
        bool IsGuestExist { get; }
        List<GuestDocuments> GuestDocuments { get; set; }
        string Surname { get; set; }
        string GuestName { get; set; }
        string Patronymic { get; set; }
        DateTime BirthDate { get; set; }
        string PhoneNumber { get; set; }
        bool AddGuest();
        void LoadGuests();
        void Back();
        void EndAdding();
        void Clear();
        bool FindGuest();
        void ClearFoundGuest();
    }
}
