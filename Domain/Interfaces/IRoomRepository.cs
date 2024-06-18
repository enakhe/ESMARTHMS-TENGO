using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;
using System.Security.Cryptography;
namespace ESMART_HMS.Domain.Interfaces
{
    public interface IRoomRepository
    {
        void AddRoom(Room room);
        List<RoomViewModel> GetAllRooms();
        RoomViewModel GetRoomById(string Id);
        void UpdateRoom(Room room);
        Room GetRealRoom(string Id);
        void DeleteRoom(string Id);
        List<RoomViewModel> GetAvailableRoom();
    }
}
