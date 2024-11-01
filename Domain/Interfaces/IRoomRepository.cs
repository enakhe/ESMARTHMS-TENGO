using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;
namespace ESMART_HMS.Domain.Interfaces
{
    public interface IRoomRepository
    {
        void AddRoom(Room room);
        void UpdateRoom(Room room);
        void DeleteRoom(string Id);
        RoomViewModel GetRoomById(string Id);
        Room GetRealRoom(string Id);
        List<RoomViewModel> GetAllRooms();
        List<RoomViewModel> GetVacantRoom();
        List<RoomViewModel> SearchRoom(string keyword);
        List<RoomViewModel> FilterByType(string keyword);
        List<RoomViewModel> FilterByStatus(string keyword);
    }
}
