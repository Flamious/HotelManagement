using System;

namespace BLL.Models
{
    public class GuestFullData
    {
        public int GuestID { get; set; }
        public int AccountID { get; set; }
        public string Surname { get; set; }
        public string GuestName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
