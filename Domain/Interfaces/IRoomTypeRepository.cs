using ESMART_HMS.Domain.Entities;
using System.Collections.Generic;

namespace ESMART_HMS.Domain.Interfaces
{
    public interface IRoomTypeRepository
    {
        void AddRoomType(RoomType roomType);
        List<RoomType> GetAllRoomTypes();
        RoomType GetRoomTypeById(string Id);
    }
}
