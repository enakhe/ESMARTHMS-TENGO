using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Domain.Interfaces
{
    public interface IRoomTypeRepository
    {
        void AddRoomType(RoomType roomType);
        List<RoomTypeViewModel> GetAllRoomTypes();
        RoomType GetRoomTypeById(string Id);
    }
}
