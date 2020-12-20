using DAL;
using System;

namespace BLL.Models
{
    public class GuestModel
    {
        public int GuestId { get; set; }
        public string Surname { get; set; }
        public string GuestName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Document { get; set; }
        public GuestModel() { }
        public GuestModel(Guest guest)
        {
            GuestId = guest.GuestId;
            Surname = guest.Surname.TrimEnd(' ');
            GuestName = guest.GuestName.TrimEnd(' ');
            Patronymic = guest.Patronymic.TrimEnd(' ');
            BirthDate = guest.BirthDate;
            PhoneNumber = guest.PhoneNumber.TrimEnd(' ');
            Document = guest.GuestDocument.TrimEnd(' ');
        }
        public GuestModel(GuestModel guest)
        {
            GuestId = guest.GuestId;
            Surname = guest.Surname;
            GuestName = guest.GuestName;
            Patronymic = guest.Patronymic;
            BirthDate = guest.BirthDate;
            PhoneNumber = guest.PhoneNumber;
            Document = guest.Document;
        }
    }
}
