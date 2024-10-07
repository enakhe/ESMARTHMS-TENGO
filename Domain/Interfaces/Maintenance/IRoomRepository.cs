using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;
namespace ESMART_HMS.Domain.Interfaces
{
    public interface IRoomRepository
    {
        void AddRoom(Room room);
        void AddArea(Area area);
        void AddFloor(Floor floor);
        void AddBuilding(Building building);

        void UpdateRoom(Room room);
        void UpdateArea(Area area);
        void UpdateFloor(Floor floor);
        void UpdateBuilding(Building building);

        void DeleteRoom(string Id);
        void DeleteArea(string id);
        void DeleteFloor(string id);
        void DeleteBuilding(string id);
        int GetNoReserved();
        int GetNoBooking();
        int GetNoMaintenance();

        Room GetRealRoom(string Id);
        Room FindByRoomNo(string roomNumber);

        RoomViewModel GetRoomById(string Id);
        Area GetAresById(string id);
        Floor GetFloorById(string id);
        Building GetBuildingById(string id);

        List<Area> GetAllArea();
        List<Floor> GetAllFloors();
        List<RoomViewModel> GetAllRooms();
        List<Building> GetAllBuildings();
        List<Floor> GetFloorsByBuilding(string id);

        List<RoomViewModel> GetVacantRoom();
        List<RoomViewModel> SearchRoom(string keyword);
        List<RoomViewModel> FilterByType(string keyword);
        List<RoomViewModel> FilterByStatus(string keyword);
        List<RoomViewModel> GetRoomsByFilter(string roomTypeId, string status);
    }
}
