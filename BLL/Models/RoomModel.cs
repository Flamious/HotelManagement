using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class RoomModel
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int NumberOfPlaces { get; set; }
        public int TypeId { get; set; }
        public RoomModel() { }
        public RoomModel(Room room)
        {
            RoomId = room.RoomId;
            RoomNumber = room.RoomNumber;
            NumberOfPlaces = room.NumberOfPlaces;
            TypeId = room.TypeId;
        }
    }
}
