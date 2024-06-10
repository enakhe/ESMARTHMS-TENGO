using ESMART_HMS.Models;
using ESMART_HMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Repositories
{
    public class RoomRepository
    {
        private readonly ESMART_HMSDBEntities _db;

        public RoomRepository(ESMART_HMSDBEntities db)
        {
            _db = db;
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
                var allRoom = from room in _db.Rooms
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
    }
}
