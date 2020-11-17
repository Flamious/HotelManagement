using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.RegistrationModels
{
    public class RegistrationFullData
    {
        public int GuestId { get; set; }
        public int AccountId { get; set; }
        public string Surname { get; set; }
        public string GuestName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Login { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string CheckingPassword { get; set; }
    }
}
