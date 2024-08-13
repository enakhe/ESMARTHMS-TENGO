using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Domain.Interfaces
{
    public interface IRoomTypeRepository
    {
        void AddRoomType(RoomType roomType);
        void UpdateRoomType(RoomType roomType);
        void DeleteRoomType(string id);
        RoomType GetRoomTypeById(string Id);
        List<RoomTypeViewModel> GetAllRoomTypes();
    }
}
