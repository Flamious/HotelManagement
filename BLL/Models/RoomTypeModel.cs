using DAL;

namespace BLL.Models
{
    public class RoomTypeModel
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public int PriceForOnePersonPerDay { get; set; }
        public RoomTypeModel() { }
        public RoomTypeModel(RoomType room)
        {
            TypeId = room.TypeId;
            TypeName = room.TypeName;
            PriceForOnePersonPerDay = room.PriceForOnePersonPerDay;
        }
    }
}
