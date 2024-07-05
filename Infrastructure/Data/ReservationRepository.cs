using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Infrastructure.Data
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ESMART_HMSDBEntities _db;
        private readonly FormHelper _formHelper;

        public ReservationRepository(ESMART_HMSDBEntities db, FormHelper formHelper)
        {
            _db = db;
            _formHelper = formHelper;
        }

        public void AddReservation(Reservation reservation)
        {
            try
            {
                _db.Reservations.Add(reservation);
                _db.SaveChanges();
                MessageBox.Show("Successfully added reservation information", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public List<ReservationViewModel> GetReservationViewModel()
        {
            try
            {
                var allReservation = from reservation in _db.Reservations.Where(r => r.IsTrashed == false)
                                     select new ReservationViewModel
                                     {
                                         Id = reservation.Id,
                                         ReservationId = reservation.ReservationId,
                                         GuestId = reservation.GuestId,
                                         RoomId = reservation.RoomId,
                                         Guest = reservation.Guest.FullName,
                                         GuestPhoneNo = reservation.Guest.PhoneNumber,
                                         Room = reservation.Room.RoomNo,
                                         PaymentMethod = reservation.PaymentMethod,
                                         Amount = reservation.Amount.ToString(),
                                         CheckInDate = reservation.CheckInDate,
                                         CheckOutDate = reservation.CheckOutDate,
                                         DateCreated = reservation.DateCreated,
                                         DateModified = reservation.DateModified,
                                     };
                return allReservation.OrderBy(r => r.DateCreated).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
            }
            return null;
        }

        public Reservation GetReservationById(string Id)
        {
            try
            {
                return _db.Reservations.FirstOrDefault(r => r.Id == Id);
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
