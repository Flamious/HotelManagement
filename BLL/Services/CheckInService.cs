using BLL.Interfaces;
using BLL.Models;
using BLL.Models.SearchModels;
using DAL.Entities.Data;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    class CheckInService : ICheckInService
    {
        IDbManager db;
        public CheckInService(IDbManager repos)
        {
            db = repos;
        }
        public List<RoomCheckInData> GetFreeRooms(DateTime startDate, DateTime endDate, string typeName, int roominess)
        {
            List<RoomData> AllRooms = db.CheckInMaking.GetAllRooms(typeName, roominess);
            List<RoomData> OccupiedRoom = db.CheckInMaking.GetOccupiedRooms(startDate, endDate, typeName, roominess);

            if(!(OccupiedRoom.Count == 0))
            {
                foreach(RoomData room in OccupiedRoom)
                {
                    foreach(RoomData freeRoom in AllRooms.ToArray())
                    {
                        if(freeRoom.RoomId == room.RoomId)
                        {
                            AllRooms.Remove(freeRoom);
                        }
                    }
                }
            }
            List<RoomCheckInData> result = new List<RoomCheckInData>();
            if (AllRooms.Count == 0) return null;
            foreach (RoomData room in AllRooms)
            {
                result.Add(new RoomCheckInData()
                {
                    RoomId = room.RoomId,
                    RoomNumber = room.RoomNumber,
                });
            }
            return result;
        }
    }
}
