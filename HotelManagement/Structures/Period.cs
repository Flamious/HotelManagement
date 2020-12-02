using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Structures
{
    public class Period
    {
        public int Value { get; set; }
        public string Name { get; set; }

        public Period(int value, string name)
        {
            Value = value;
            Name = name;
        }
    }
}
