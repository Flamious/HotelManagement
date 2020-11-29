using BLL.Models;
using HotelManagement.Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.CheckInMaking
{
    public interface ICheckInGuest
    {
        event PropertyChangedEventHandler GuestInfoChanged;
        List<GuestModel> Guests { get; set; }
        int CurrentGuestIndex { get; set; }
        string Document { get; set; }
        bool IsChild { get; set; }
        List<GuestDocuments> GuestDocuments { get; set; }
        string Surname { get; set; }
        string GuestName { get; set; }
        string Patronymic { get; set; }
        DateTime BirthDate { get; set; }
        string PhoneNumber { get; set; }
        void AddGuest();
        void Back();
        void EndAdding();
    }
}
