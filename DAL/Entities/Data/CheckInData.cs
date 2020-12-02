using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ServiceData
    {
        public int ServiceId { get; set; }
        public int Number { get; set; }
    }

    public class GuestData
    {
        public int GuestId { get; set; }
        public string Surname { get; set; }
        public string GuestName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsChild { get; set; }
        public string Document { get; set; }
    }
}
