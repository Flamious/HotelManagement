using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class AdultModel : GuestModel
    {
        public string PassportNumber { get; set; }
        public string PassportInfo { get; set; }
    }
}
