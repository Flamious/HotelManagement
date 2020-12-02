using DAL.Entities;
using DAL.Entities.Data;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CheckInMakingRepository : ICheckInMakingRepository
    {
        private HotelDB db;

        public CheckInMakingRepository(HotelDB dbcontext)
        {
            this.db = dbcontext;
        }
        public List<RoomData> GetAllRooms(string typeName, int rominess)
        {
            return db.Room
                .Where(i => i.NumberOfPlaces == rominess)
                .Join(db.RoomType, i => i.TypeId, j => j.TypeId, (i, j) => new RoomData()
                {
                    RoomId = i.RoomId,
                    RoomNumber = i.RoomNumber,
                    TypeName = j.TypeName
                }).Where(i => i.TypeName == typeName).ToList();
        }
        public List<RoomData> GetOccupiedRooms(DateTime startDate, DateTime endDate, string typeName, int rominess)
        {
            return db.Room
                .Join(db.CheckIn, i => i.RoomId, j => j.RoomId, (i, j) => new
                {
                    Startdate = j.StartDate,
                    EndDate = j.EndDate,
                    RoomId = i.RoomId,
                    RoomNumber = i.RoomNumber,
                    Roominess = i.NumberOfPlaces,
                    TypeId = i.TypeId
                })
                .Where(i => (i.Startdate >= startDate && i.Startdate <= endDate) || (i.EndDate >= startDate && i.EndDate <= endDate))
                .Where(i => i.Roominess == rominess)
                .Join(db.RoomType, i => i.TypeId, j => j.TypeId, (i, j) => new RoomData()
                {
                    RoomId = i.RoomId,
                    RoomNumber = i.RoomNumber,
                    TypeName = j.TypeName
                }).Where(i => i.TypeName == typeName).ToList();
        }
        public CheckIn GetCheckIn(int roomId, DateTime EndDate)
        {
            return db.CheckIn.First(i => i.EndDate == EndDate && i.RoomId == roomId);
        }
        public Guest GetGuest(string document)
        {
            return db.Guest.FirstOrDefault(i => i.GuestDocument == document);
        }
    }
}
