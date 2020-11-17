using DAL;
using System;

namespace BLL.Models
{
    public class GuestModel
    {
        public int GuestId { get; set; }
        public int AccountId { get; set; }
        public string Surname { get; set; }
        public string GuestName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public GuestModel() { }
        public GuestModel(Guest guest) 
        {
            //GuestId = guest.GuestId;
            //AccountId = guest.AccountId;
            //Surname = guest.Surname;
            //GuestName = guest.GuestName;
            //Patronymic = guest.Patronymic;
            //BirthDate = guest.BirthDate;
            //PhoneNumber = guest.PhoneNumber;
        }
    }
}
