using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Infrastructure.Data
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly ESMART_HMSDBEntities _db;

        public RoomTypeRepository(ESMART_HMSDBEntities db)
        {
            _db = db;
        }

        public void AddRoomType(RoomType roomType)
        {
            try
            {
                Random random = new Random();

                roomType.Id = Guid.NewGuid().ToString();
                roomType.RoomTypeId = "RMT" + random.Next(1000, 5000);

                _db.RoomTypes.Add(roomType);
                _db.SaveChanges();
                MessageBox.Show("Successfully added room type information", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public List<RoomTypeViewModel> GetAllRoomTypes()
        {
            try
            {
                var allRoomType = from roomType in _db.RoomTypes.Where(rt => rt.IsTrashed == false)
                                     select new RoomTypeViewModel
                                     {
                                         Id = roomType.Id,
                                         RoomTypeId = roomType.RoomTypeId,
                                         Title = roomType.Title,
                                         DateCreated = roomType.DateCreated,
                                         DateModified = roomType.DateModified,
                                     };
                return allRoomType.OrderBy(r => r.Title).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public RoomType GetRoomTypeById(string Id)
        {
            try
            {
                RoomType roomType = _db.RoomTypes.FirstOrDefault(r => r.Id == Id);
                return roomType;
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
