using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ESMART_HMSDBEntities _db;
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomRepository(ESMART_HMSDBEntities db, IRoomTypeRepository roomTypeRepository)
        {
            _db = db;
            _roomTypeRepository = roomTypeRepository;
        }

        public void AddRoom(Room room)
        {
            try
            {
                _db.Rooms.Add(room);
                _db.SaveChanges();
                MessageBox.Show("Successfully added room information", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public List<RoomViewModel> GetAllRooms()
        {
            try
            {
                var allRoom = from room in _db.Rooms.Where(r => r.IsTrashed == false).OrderBy(r => r.RoomNo)
                              join roomType in _db.RoomTypes on room.RoomTypeId equals roomType.Id
                              select new RoomViewModel
                              {
                                  Id = room.Id,
                                  RoomId = room.RoomId,
                                  RoomNo = room.RoomNo,
                                  AdultPerRoom = room.AdultPerRoom,
                                  ChildrenPerRoom = room.ChildrenPerRoom,
                                  Description = room.Description,
                                  Rate = room.Rate.ToString(),
                                  Status = room.Status,
                                  CreatedBy = room.ApplicationUser.FullName,
                                  DateCreated = room.DateCreated.ToString(),
                                  DateModified = room.DateModified.ToString(),
                                  RoomType = roomType.Title,
                                  Floor = room.Floor.FloorNo,
                                  Area = room.Area.AreaName,
                                  Capacity = (room.ChildrenPerRoom + room.AdultPerRoom).ToString()
                              };
                return allRoom.OrderBy(r => r.RoomNo).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public RoomViewModel GetRoomById(string Id)
        {
            try
            {
                Room room = _db.Rooms.FirstOrDefault(r => r.Id == Id);
                RoomType roomType = _roomTypeRepository.GetRoomTypeById(room.RoomTypeId);
                RoomViewModel roomViewModel = new RoomViewModel()
                {
                    Id = room.Id,
                    RoomId = room.RoomId,
                    RoomNo = room.RoomNo,
                    AdultPerRoom = room.AdultPerRoom,
                    ChildrenPerRoom = room.ChildrenPerRoom,
                    Description = room.Description,
                    Rate = room.Rate.ToString(),
                    Status = room.Status,
                    DateCreated = room.DateCreated.ToString(),
                    DateModified = room.DateModified.ToString(),
                    RoomType = roomType.Title,
                    Capacity = (room.ChildrenPerRoom + room.AdultPerRoom).ToString()
                };
                return roomViewModel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public void UpdateRoom(Room room)
        {
            try
            {
                _db.Entry(room).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                MessageBox.Show("Successfully edited room information", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public Room GetRealRoom(string Id)
        {
            try
            {
                return _db.Rooms.FirstOrDefault(r => r.Id == Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public void DeleteRoom(string Id)
        {
            try
            {
                var room = _db.Rooms.FirstOrDefault(r => r.Id == Id);
                if (room != null)
                {
                    room.IsTrashed = true;
                    _db.Entry(room).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Room not found", "Not Found", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public List<RoomViewModel> GetVacantRoom()
        {
            try
            {
                var vacantRoom = from room in _db.Rooms.Where(r => r.Status == RoomStatusEnum.Vacant.ToString() && r.IsTrashed == false).OrderBy(r => r.RoomNo)
                                 join roomType in _db.RoomTypes on room.RoomTypeId equals roomType.Id
                                 select new RoomViewModel
                                 {
                                     Id = room.Id,
                                     RoomId = room.RoomId,
                                     RoomNo = room.RoomNo,
                                     AdultPerRoom = room.AdultPerRoom,
                                     ChildrenPerRoom = room.ChildrenPerRoom,
                                     Description = room.Description,
                                     Rate = room.Rate.ToString(),
                                     Status = room.Status,
                                     DateCreated = room.DateCreated.ToString(),
                                     DateModified = room.DateModified.ToString(),
                                     RoomType = roomType.Title,
                                     Capacity = (room.ChildrenPerRoom + room.AdultPerRoom).ToString()
                                 };
                return vacantRoom.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public List<RoomViewModel> SearchRoom(string keyword)
        {
            try
            {
                var searchRooms = from room in _db.Rooms.Where(r => r.RoomNo == keyword)
                                  join roomType in _db.RoomTypes on room.RoomTypeId equals roomType.Id
                                  select new RoomViewModel
                                  {
                                      Id = room.Id,
                                      RoomId = room.RoomId,
                                      RoomNo = room.RoomNo,
                                      AdultPerRoom = room.AdultPerRoom,
                                      ChildrenPerRoom = room.ChildrenPerRoom,
                                      Description = room.Description,
                                      Rate = room.Rate.ToString(),
                                      Status = room.Status,
                                      DateCreated = room.DateCreated.ToString(),
                                      DateModified = room.DateModified.ToString(),
                                      RoomType = roomType.Title,
                                      Capacity = (room.ChildrenPerRoom + room.AdultPerRoom).ToString()
                                  };
                return searchRooms.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }

            return null;
        }

        public List<RoomViewModel> FilterByStatus(string keyword)
        {
            try
            {
                var searchRooms = from room in _db.Rooms.Where(r => r.Status.ToUpper() == keyword).OrderBy(r => r.RoomNo)
                                  join roomType in _db.RoomTypes on room.RoomTypeId equals roomType.Id
                                  select new RoomViewModel
                                  {
                                      Id = room.Id,
                                      RoomId = room.RoomId,
                                      RoomNo = room.RoomNo,
                                      AdultPerRoom = room.AdultPerRoom,
                                      ChildrenPerRoom = room.ChildrenPerRoom,
                                      Description = room.Description,
                                      Rate = room.Rate.ToString(),
                                      Status = room.Status,
                                      DateCreated = room.DateCreated.ToString(),
                                      DateModified = room.DateModified.ToString(),
                                      RoomType = roomType.Title,
                                      Capacity = (room.ChildrenPerRoom + room.AdultPerRoom).ToString()
                                  };
                return searchRooms.OrderBy(room => room.RoomNo).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }

            return null;
        }

        public List<RoomViewModel> FilterByType(string keyword)
        {
            try
            {
                var searchRooms = from room in _db.Rooms.Where(r => r.RoomType.Id == keyword).OrderBy(r => r.RoomNo)
                                  join roomType in _db.RoomTypes on room.RoomTypeId equals roomType.Id
                                  select new RoomViewModel
                                  {
                                      Id = room.Id,
                                      RoomId = room.RoomId,
                                      RoomNo = room.RoomNo,
                                      AdultPerRoom = room.AdultPerRoom,
                                      ChildrenPerRoom = room.ChildrenPerRoom,
                                      Description = room.Description,
                                      Rate = room.Rate.ToString(),
                                      Status = room.Status,
                                      DateCreated = room.DateCreated.ToString(),
                                      DateModified = room.DateModified.ToString(),
                                      RoomType = roomType.Title,
                                      Capacity = (room.ChildrenPerRoom + room.AdultPerRoom).ToString()
                                  };
                return searchRooms.OrderBy(room => room.RoomNo).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }

            return null;
        }

        public Room FindByRoomNo(string roomNumber)
        {
            try
            {
                return _db.Rooms.FirstOrDefault(r => r.RoomNo == roomNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public List<RoomViewModel> GetRoomsByFilter(string roomTypeId, string status)
        {
            var rooms = from room in _db.Rooms.Where(room => room.RoomTypeId == roomTypeId && room.Status == status)
                        join roomType in _db.RoomTypes on room.RoomTypeId equals roomType.Id
                        select new RoomViewModel
                        {
                            Id = room.Id,
                            RoomId = room.RoomId,
                            RoomNo = room.RoomNo,
                            AdultPerRoom = room.AdultPerRoom,
                            ChildrenPerRoom = room.ChildrenPerRoom,
                            Description = room.Description,
                            Rate = room.Rate.ToString(),
                            Status = room.Status,
                            DateCreated = room.DateCreated.ToString(),
                            DateModified = room.DateModified.ToString(),
                            RoomType = roomType.Title,
                            Capacity = (room.ChildrenPerRoom + room.AdultPerRoom).ToString()
                        };

            return rooms.OrderBy(room => room.RoomNo).ToList();
        }




        public void AddArea(Area area)
        {
            try
            {
                _db.Areas.Add(area);
                _db.SaveChanges();
                MessageBox.Show("Successfully added room information", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public List<Area> GetAllArea()
        {
            try
            {
                return _db.Areas.Where(a => a.IsTrashed != true).OrderBy(a => a.AreaNo).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public void UpdateArea(Area area)
        {
            try
            {
                _db.Entry(area).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                MessageBox.Show("Successfully edited area information", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public Area GetAresById(string id)
        {
            try
            {
                return _db.Areas.FirstOrDefault(a => a.Id == id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public void DeleteArea(string id)
        {
            try
            {
                Area area = _db.Areas.FirstOrDefault(a => a.Id == id);
                if (area != null)
                {
                    area.IsTrashed = true;
                    _db.Entry(area).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("area not found", "Not Found", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }



        public void AddFloor(Floor floor)
        {
            try
            {
                _db.Floors.Add(floor);
                _db.SaveChanges();
                MessageBox.Show("Successfully added floor information", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public List<Floor> GetAllFloors()
        {
            try
            {
                return _db.Floors.Where(f => f.IsTrashed != true).OrderBy(f => f.FloorNo).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public void UpdateFloor(Floor floor)
        {
            try
            {
                _db.Entry(floor).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                MessageBox.Show("Successfully edited floor information", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public Floor GetFloorById(string id)
        {
            try
            {
                return _db.Floors.FirstOrDefault(f => f.Id == id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public void DeleteFloor(string id)
        {
            try
            {
                Floor floor = _db.Floors.FirstOrDefault(f => f.Id == id);
                if (floor != null)
                {
                    floor.IsTrashed = true;
                    _db.Entry(floor).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Floor not found", "Not Found", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public List<Floor> GetFloorsByBuilding(string id)
        {
            try
            {
                return _db.Floors.Where(f => f.BuildingId == id).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }




        public void AddBuilding(Building building)
        {
            try
            {
                _db.Buildings.Add(building);
                _db.SaveChanges();
                MessageBox.Show("Successfully added building information", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public List<Building> GetAllBuildings()
        {
            try
            {
                return _db.Buildings.Where(b => b.IsTrashed != true).OrderBy(b => b.BuildingNo).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public void UpdateBuilding(Building building)
        {
            try
            {
                _db.Entry(building).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                MessageBox.Show("Successfully edited building information", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public Building GetBuildingById(string id)
        {
            try
            {
                return _db.Buildings.FirstOrDefault(b => b.Id == id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public void DeleteBuilding(string id)
        {
            try
            {
                Building building = _db.Buildings.FirstOrDefault(b => b.Id == id);
                if (building != null)
                {
                    building.IsTrashed = true;
                    _db.Entry(building).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Building not found", "Not Found", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }
    }
}