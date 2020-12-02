using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
