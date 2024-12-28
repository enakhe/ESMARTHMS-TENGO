using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Infrastructure.Data
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ESMART_HMSDBEntities _db;
        private string _connectionString = "data source=localhost;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True";
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
            var reservations = _db.Reservations.Where(r => r.IsTrashed == false && r.Status != RoomStatusEnum.CheckedIn.ToString());
                var allReservation = from reservation in reservations
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
                                         AmountPaid = reservation.AmountPaid.ToString(),
                                         Balance = (reservation.Amount - reservation.AmountPaid).ToString(),
                                         CheckInDate = reservation.CheckInDate.ToString(),
                                         CheckOutDate = reservation.CheckOutDate.ToString(),
                                         CreatedBy = reservation.ApplicationUser.FullName,
                                         DateCreated = reservation.DateCreated.ToString(),
                                         DateModified = reservation.DateModified.ToString(),
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

        public void UpdateRoomStatuses()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // SQL query to update room status to 'vacant' where the check-out date has passed
                string updateVacantQuery = @"
                UPDATE Room
                SET Status = 'Vacant'
                WHERE RoomId IN (
                    SELECT RoomId
                    FROM Reservation
                    WHERE CheckOutDate < @CurrentDate
                    AND Status != 'vacant'
                )";

                // SQL query to update room status to 'reserved' where the check-in date has passed but check-out date is still in the future
                string updateReservedQuery = @"
                UPDATE Room
                SET Status = 'Reserved'
                WHERE RoomId IN (
                    SELECT RoomId
                    FROM Reservation
                    WHERE CheckInDate < @CurrentDate
                    AND CheckOutDate > @CurrentDate
                    AND Status != 'Reserved'
                )";

                using (var command = new SqlCommand(updateVacantQuery, connection))
                {
                    command.Parameters.AddWithValue("@CurrentDate", DateTime.Now);
                    command.ExecuteNonQuery();
                }

                using (var command = new SqlCommand(updateReservedQuery, connection))
                {
                    command.Parameters.AddWithValue("@CurrentDate", DateTime.Now);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ReservationViewModel> GetReservationByPaymentStatus(string roomTypeId, DateTime fromTime, DateTime endTime, string paymentStatus)
        {
            try
            {
                var allReservation = from reservation in _db.Reservations.Where(r => r.Room.RoomTypeId == roomTypeId && (
                                        (r.DateCreated <= endTime && r.DateCreated >= fromTime && r.IsTrashed == false && r.Status == paymentStatus) ||
                                        (r.DateCreated == null)
                                     ))
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
                                         AmountPaid = reservation.AmountPaid.ToString(),
                                         Balance = (reservation.Amount - reservation.AmountPaid).ToString(),
                                         CheckInDate = reservation.CheckInDate.ToString(),
                                         CheckOutDate = reservation.CheckOutDate.ToString(),
                                         CreatedBy = reservation.ApplicationUser.FullName,
                                         DateCreated = reservation.DateCreated.ToString(),
                                         DateModified = reservation.DateModified.ToString(),
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

        public List<ReservationViewModel> GetReservationByRoomTypeAndDate(string roomTypeId, DateTime fromTime, DateTime endTime)
        {
            try
            {
                var allReservation = from reservation in _db.Reservations.Where(r => r.Room.RoomTypeId == roomTypeId && (
                                        (r.DateCreated <= endTime && r.DateCreated >= fromTime && r.IsTrashed == false) ||
                                        (r.DateCreated == null)
                                     ))
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
                                         AmountPaid = reservation.AmountPaid.ToString(),
                                         Balance = (reservation.Amount - reservation.AmountPaid).ToString(),
                                         CheckInDate = reservation.CheckInDate.ToString(),
                                         CheckOutDate = reservation.CheckOutDate.ToString(),
                                         CreatedBy = reservation.ApplicationUser.FullName,
                                         DateCreated = reservation.DateCreated.ToString(),
                                         DateModified = reservation.DateModified.ToString(),
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

        public List<ReservationViewModel> GetReservationByStatuseAndDate(string status, DateTime fromTime, DateTime endTime)
        {
            try
            {
                var allReservation = from reservation in _db.Reservations.Where(r => r.Status == status && (
                                        (r.DateCreated <= endTime && r.DateCreated >= fromTime && r.IsTrashed == false) ||
                                        (r.DateCreated == null)
                                     ))
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
                                         AmountPaid = reservation.AmountPaid.ToString(),
                                         Balance = (reservation.Amount - reservation.AmountPaid).ToString(),
                                         CheckInDate = reservation.CheckInDate.ToString(),
                                         CheckOutDate = reservation.CheckOutDate.ToString(),
                                         CreatedBy = reservation.ApplicationUser.FullName,
                                         DateCreated = reservation.DateCreated.ToString(),
                                         DateModified = reservation.DateModified.ToString(),
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

        public List<ReservationViewModel> GetReservationByDate(DateTime fromTime, DateTime endTime)
        {
            try
            {
                var allReservation = from reservation in _db.Reservations.Where(r => (
                                        (r.DateCreated <= endTime && r.DateCreated >= fromTime && r.IsTrashed == false) ||
                                        (r.DateCreated == null)
                                     ))
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
                                         AmountPaid = reservation.AmountPaid.ToString(),
                                         Balance = (reservation.Amount - reservation.AmountPaid).ToString(),
                                         CheckInDate = reservation.CheckInDate.ToString(),
                                         CheckOutDate = reservation.CheckOutDate.ToString(),
                                         CreatedBy = reservation.ApplicationUser.FullName,
                                         DateCreated = reservation.DateCreated.ToString(),
                                         DateModified = reservation.DateModified.ToString(),
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

        public void UpdateReservation(Reservation reservation)
        {
            try
            {
                _db.Entry(reservation).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }
        public void DeleteReservation(string id)
        {
            try
            {
                Reservation reservation = GetReservationById(id);
                reservation.IsTrashed = true;
                _db.Entry(reservation).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("An error occured when recycling reservation", ex);
            }
        }

        public List<ReservationViewModel> GetRecycledReservation()
        {
            try
            {
                var allReservation = from reservation in _db.Reservations.Where(r => r.IsTrashed == true && r.Status != RoomStatusEnum.CheckedIn.ToString())
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
                                         AmountPaid = reservation.AmountPaid.ToString(),
                                         Balance = (reservation.Amount - reservation.AmountPaid).ToString(),
                                         CheckInDate = reservation.CheckInDate.ToString(),
                                         CheckOutDate = reservation.CheckOutDate.ToString(),
                                         CreatedBy = reservation.ApplicationUser.FullName,
                                         DateCreated = reservation.DateCreated.ToString(),
                                         DateModified = reservation.DateModified.ToString(),
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
    }
}
