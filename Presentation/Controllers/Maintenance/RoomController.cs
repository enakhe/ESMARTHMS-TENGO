using ESMART_HMS.Application.UseCases.Maintenance.Room;
using ESMART_HMS.Application.UseCases.Maintenance.Room.Area;
using ESMART_HMS.Application.UseCases.Maintenance.Room.Floor;
using ESMART_HMS.Application.UseCases.Room;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Presentation.Controllers
{
    public class RoomController
    {
        private readonly GetAllRoomUseCase _getAllRoomUseCase;
        private readonly CreateRoomUseCase _createRoomUseCase;
        private readonly GetRoomByIdUseCase _getRoomByIdUseCase;
        private readonly UpdateRoomUseCase _updateRoomUseCase;
        private readonly GetRealRoomUseCase _getRealRoomUseCase;
        private readonly DeleteRoomUseCase _deleteRoomUseCase;
        private readonly GetVacantRoomUseCase _getVacantRoomUseCase;
        private readonly SearchRoomUseCase _searchRoomUseCase;
        private readonly FilterByStatusUseCase _filterByStatusUseCase;
        private readonly FilterByTypeUseCase _filterByTypeUseCase;
        private readonly GetRoomByRoomNoUseCase _getRoomByRoomNoUseCase;

        private readonly CreateAreaUseCase _createAreaUseCase;
        private readonly GetAllAreaUseCase _getAllAreaUseCase;
        private readonly UpdateAreaUseCase _updateAreaUseCase;
        private readonly GetAreaByIdUseCase _getAreaByIdUseCase;
        private readonly DeleteAreaUseCase _deleteAreaUseCase;

        private readonly CreateFloorUseCase _createFloorUseCase;
        private readonly GetAllFloorUseCase _getAllFloorUseCase;
        private readonly UpdateFloorUseCase _updateFloorUseCase;
        private readonly GetFloorByIdUseCase _getFloorByIdUseCase;
        private readonly DeleteFloorUseCase _deleteFloorUseCase;

        public RoomController(GetAllRoomUseCase getAllRoomUseCase, CreateRoomUseCase createRoomUseCase, GetRoomByIdUseCase getRoomByIdUseCase, UpdateRoomUseCase updateRoomUseCase, GetRealRoomUseCase getRealRoomUseCase, DeleteRoomUseCase deleteRoomUseCase, GetVacantRoomUseCase getVacantRoomUseCase, SearchRoomUseCase searchRoomUseCase, FilterByStatusUseCase filterByStatusUseCase, FilterByTypeUseCase filterByTypeUseCase, GetRoomByRoomNoUseCase getRoomByRoomNoUseCase, CreateAreaUseCase createAreaUseCase, GetAllAreaUseCase getAllAreaUseCase, UpdateAreaUseCase updateAreaUseCase, GetAreaByIdUseCase getAreaByIdUseCase, DeleteAreaUseCase deleteAreaUseCase, CreateFloorUseCase createFloorUseCase, GetAllFloorUseCase getAllFloorUseCase, UpdateFloorUseCase updateFloorUseCase, GetFloorByIdUseCase getFloorByIdUseCase, DeleteFloorUseCase deleteFloorUseCase)
        {
            _getAllRoomUseCase = getAllRoomUseCase;
            _createRoomUseCase = createRoomUseCase;
            _getRoomByIdUseCase = getRoomByIdUseCase;
            _updateRoomUseCase = updateRoomUseCase;
            _getRealRoomUseCase = getRealRoomUseCase;
            _deleteRoomUseCase = deleteRoomUseCase;
            _getVacantRoomUseCase = getVacantRoomUseCase;
            _searchRoomUseCase = searchRoomUseCase;
            _filterByStatusUseCase = filterByStatusUseCase;
            _filterByTypeUseCase = filterByTypeUseCase;
            _getRoomByRoomNoUseCase = getRoomByRoomNoUseCase;
            _createAreaUseCase = createAreaUseCase;
            _getAllAreaUseCase = getAllAreaUseCase;
            _updateAreaUseCase = updateAreaUseCase;
            _getAreaByIdUseCase = getAreaByIdUseCase;
            _deleteAreaUseCase = deleteAreaUseCase;
            _createFloorUseCase = createFloorUseCase;
            _getAllFloorUseCase = getAllFloorUseCase;
            _updateFloorUseCase = updateFloorUseCase;
            _getFloorByIdUseCase = getFloorByIdUseCase;
            _deleteFloorUseCase = deleteFloorUseCase;
        }

        public List<RoomViewModel> GetAllRooms()
        {
            List<RoomViewModel> allRooms = _getAllRoomUseCase.Execute();
            return allRooms;
        }

        public void CreateRoom(Room room)
        {
            _createRoomUseCase.Execute(room);
        }

        public RoomViewModel GetRoomById(string Id)
        {
            return _getRoomByIdUseCase.Execute(Id);
        }

        public void UpdateRoom(Room room)
        {
            _updateRoomUseCase.Execute(room);
        }

        public Room GetRealRoom(string Id)
        {
            return _getRealRoomUseCase.Execute(Id);
        }

        public void DeleteRoom(string Id)
        {
            _deleteRoomUseCase.Execute(Id);
        }

        public List<RoomViewModel> GetAvailbleRoom()
        {
            return _getVacantRoomUseCase.Execute();
        }

        public List<RoomViewModel> SearchRoom(string keyword)
        {
            return _searchRoomUseCase.Execute(keyword);
        }

        public List<RoomViewModel> FilterByStatus(string keyword)
        {
            return _filterByStatusUseCase.Execute(keyword);
        }

        public List<RoomViewModel> FilterByType(string keyword)
        {
            return _filterByTypeUseCase.Execute(keyword);
        }

        public Room GetRoomByRoomNo(string roomNo)
        {
            return _getRoomByRoomNoUseCase.Execute(roomNo);
        }

        public void AddArea(Area area)
        {
            _createAreaUseCase.Execute(area);
        }

        public List<Area> GetAllAreas()
        {
            return _getAllAreaUseCase.Execute();
        }

        public void UpdateArea(Area area)
        {
            _updateAreaUseCase.Execute(area);
        }

        public Area GetAreaById(string id)
        {
            return _getAreaByIdUseCase.Execute(id);
        }

        public void DeleteArea(string id)
        {
            _deleteAreaUseCase.Execute(id);
        }

        public void AddFloor(Floor floor)
        {
            _createFloorUseCase.Execute(floor);
        }

        public List<Floor> GetAllFloors()
        {
            return _getAllFloorUseCase.Execute();
        }

        public void UpdateFloor(Floor floor)
        {
            _updateFloorUseCase.Execute(floor);
        }

        public Floor GetFloorById(string id)
        {
            return _getFloorByIdUseCase.Execute(id);
        }

        public void DeleteFloor(string id)
        {
            _deleteFloorUseCase.Execute(id);
        }
    }
}
