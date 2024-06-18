using ESMART_HMS.Domain.Entities;
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
                Random random = new Random();

                room.Id = Guid.NewGuid().ToString();
                room.RoomId = "RM" + random.Next(1000, 5000);

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
                var allRoom = from room in _db.Rooms.Where(r => r.IsTrashed == false)
                              join roomType in _db.RoomTypes on room.RoomTypeId equals roomType.Id
                              select new RoomViewModel
                              {
                                  Id = room.Id,
                                  RoomId = room.RoomId,
                                  RoomName = room.RoomName,
                                  RoomCardNo = room.RoomCardNo,
                                  RoomLockNo = room.RoomLockNo,
                                  AdultPerRoom = room.AdultPerRoom,
                                  ChildrenPerRoom = room.ChildrenPerRoom,
                                  Description = room.Description,
                                  Rate = room.Rate,
                                  IsAvailable = room.IsAvailable,
                                  DateCreated = room.DateCreated,
                                  DateModified = room.DateModified,
                                  RoomTypeName = roomType.Title,
                              };
                return allRoom.ToList();
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
                    RoomName = room.RoomName,
                    RoomCardNo = room.RoomCardNo,
                    RoomLockNo = room.RoomLockNo,
                    AdultPerRoom = room.AdultPerRoom,
                    ChildrenPerRoom = room.ChildrenPerRoom,
                    Description = room.Description,
                    Rate = room.Rate,
                    IsAvailable = room.IsAvailable,
                    DateCreated = room.DateCreated,
                    DateModified = room.DateModified,
                    RoomTypeName = roomType.Title,
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

        public List<RoomViewModel> GetAvailableRoom()
        {
            try
            {
                var availableRoom = from room in _db.Rooms.Where(r => r.IsAvailable == true && r.IsTrashed == false)
                              join roomType in _db.RoomTypes on room.RoomTypeId equals roomType.Id
                              select new RoomViewModel
                              {
                                  Id = room.Id,
                                  RoomId = room.RoomId,
                                  RoomName = room.RoomName,
                                  RoomCardNo = room.RoomCardNo,
                                  RoomLockNo = room.RoomLockNo,
                                  AdultPerRoom = room.AdultPerRoom,
                                  ChildrenPerRoom = room.ChildrenPerRoom,
                                  Description = room.Description,
                                  Rate = room.Rate,
                                  IsAvailable = room.IsAvailable,
                                  DateCreated = room.DateCreated,
                                  DateModified = room.DateModified,
                                  RoomTypeName = roomType.Title,
                              };
                return availableRoom.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }
    }
}