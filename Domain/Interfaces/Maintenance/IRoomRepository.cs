using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;
namespace ESMART_HMS.Domain.Interfaces
{
    public interface IRoomRepository
    {
        void AddRoom(Room room);
        void AddArea(Area area);
        void UpdateRoom(Room room);
        void UpdateArea(Area area);
        void DeleteRoom(string Id);
        void DeleteArea(string id);
        RoomViewModel GetRoomById(string Id);
        Room GetRealRoom(string Id);
        Room FindByRoomNo(string roomNumber);
        Area GetAresById(string id);
        List<Area> GetAllArea();
        List<RoomViewModel> GetAllRooms();
        List<RoomViewModel> GetVacantRoom();
        List<RoomViewModel> SearchRoom(string keyword);
        List<RoomViewModel> FilterByType(string keyword);
        List<RoomViewModel> FilterByStatus(string keyword);
    }
}
