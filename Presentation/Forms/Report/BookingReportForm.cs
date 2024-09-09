using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Report
{
    public partial class BookingReportForm : Form
    {
        private readonly BookingController _bookingController;
        private readonly RoomController _roomController;
        private readonly RoomTypeController _roomTypeController;
        public BookingReportForm(BookingController bookingController, RoomController roomController, RoomTypeController roomTypeController)
        {
            _bookingController = bookingController;
            InitializeComponent();
            _roomController = roomController;
            _roomTypeController = roomTypeController;
        }

        private void BookingReportForm_Load(object sender, EventArgs e)
        {
            LoadRoomType();

            txtFrom.Value = DateTime.Now;
            txtTo.Value = DateTime.Now;
        }

        private void LoadRoomType()
        {
            try
            {
                var allRooms = _roomController.GetAllRooms();
                var allRoomTypes = new List<RoomTypeViewModel>();
                var roomTypes = _roomTypeController.GetAllRoomType();

                if (roomTypes != null)
                {
                    RoomTypeViewModel all = new RoomTypeViewModel()
                    {
                        Id = "ALL",
                        RoomTypeId = "ALL",
                        Title = "ALL",
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                    };
                    allRoomTypes.Add(all);

                    foreach (var roomType in roomTypes)
                    {
                        allRoomTypes.Add(roomType);
                    }

                    txtType.DataSource = allRoomTypes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void LoadBooking()
        {
            List<BookingViewModel> allBookings = _bookingController.GetAllBookings();
            if (allBookings != null)
            {
                foreach (var booking in allBookings)
                {
                    booking.TotalAmount = FormHelper.FormatNumberWithCommas(decimal.Parse(booking.TotalAmount));

                    booking.DateCreated = FormHelper.FormatDateTimeWithSuffix(booking.DateCreated);
                    booking.DateModified = FormHelper.FormatDateTimeWithSuffix(booking.DateModified);

                    booking.CheckInDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckInDate);
                    booking.CheckOutDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckOutDate);
                }
                dgvBooking.DataSource = allBookings;
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtStatus.SelectedItem.ToString(), txtType.SelectedValue.ToString(), txtFrom.Text, txtTo.Text);
            if (isNull == false)
            {
                string status = txtStatus.SelectedItem.ToString();
                string type = txtType.SelectedValue.ToString();
                DateTime from = txtFrom.Value;
                DateTime to = txtTo.Value;

                if (status == "Checked In" && type == "ALL")
                {
                    List<BookingViewModel> filteredBooking = _bookingController.GetBookingByDate(from, to);
                    if (filteredBooking != null)
                    {
                        foreach (var booking in filteredBooking)
                        {
                            booking.TotalAmount = FormHelper.FormatNumberWithCommas(decimal.Parse(booking.TotalAmount));

                            booking.DateCreated = FormHelper.FormatDateTimeWithSuffix(booking.DateCreated);
                            booking.DateModified = FormHelper.FormatDateTimeWithSuffix(booking.DateModified);

                            booking.CheckInDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckInDate);
                            booking.CheckOutDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckOutDate);
                        }
                        dgvBooking.DataSource = filteredBooking;
                    }
                }
                else if (status == "Checked Out" && type == "ALL")
                {
                    List<BookingViewModel> filteredBooking = _bookingController.GetCheckedOutBookingByDate(from, to);
                    if (filteredBooking != null)
                    {
                        foreach (var booking in filteredBooking)
                        {
                            booking.TotalAmount = FormHelper.FormatNumberWithCommas(decimal.Parse(booking.TotalAmount));

                            booking.DateCreated = FormHelper.FormatDateTimeWithSuffix(booking.DateCreated);
                            booking.DateModified = FormHelper.FormatDateTimeWithSuffix(booking.DateModified);

                            booking.CheckInDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckInDate);
                            booking.CheckOutDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckOutDate);
                        }
                        dgvBooking.DataSource = filteredBooking;
                    }
                }
                else if (status == "Checked In")
                {
                    List<BookingViewModel> filteredBooking = _bookingController.GetActiveBookingByFilter(type, from, to);
                    if (filteredBooking != null)
                    {
                        foreach (var booking in filteredBooking)
                        {
                            booking.TotalAmount = FormHelper.FormatNumberWithCommas(decimal.Parse(booking.TotalAmount));

                            booking.DateCreated = FormHelper.FormatDateTimeWithSuffix(booking.DateCreated);
                            booking.DateModified = FormHelper.FormatDateTimeWithSuffix(booking.DateModified);

                            booking.CheckInDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckInDate);
                            booking.CheckOutDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckOutDate);
                        }
                        dgvBooking.DataSource = filteredBooking;
                    }
                } 
                else if (status == "Checked Out")
                {
                    List<BookingViewModel> filteredBooking = _bookingController.GetInActiveBookingByfilter(type, from, to);
                    if (filteredBooking != null)
                    {
                        foreach (var booking in filteredBooking)
                        {
                            booking.TotalAmount = FormHelper.FormatNumberWithCommas(decimal.Parse(booking.TotalAmount));

                            booking.DateCreated = FormHelper.FormatDateTimeWithSuffix(booking.DateCreated);
                            booking.DateModified = FormHelper.FormatDateTimeWithSuffix(booking.DateModified);

                            booking.CheckInDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckInDate);
                            booking.CheckOutDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckOutDate);
                        }
                        dgvBooking.DataSource = filteredBooking;
                    }
                }
                else if (status == "All" && type != "ALL")
                {
                    List<BookingViewModel> filteredBooking = _bookingController.GetRoomTypeBooking(type, from, to);
                    if (filteredBooking != null)
                    {
                        foreach (var booking in filteredBooking)
                        {
                            booking.TotalAmount = FormHelper.FormatNumberWithCommas(decimal.Parse(booking.TotalAmount));

                            booking.DateCreated = FormHelper.FormatDateTimeWithSuffix(booking.DateCreated);
                            booking.DateModified = FormHelper.FormatDateTimeWithSuffix(booking.DateModified);

                            booking.CheckInDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckInDate);
                            booking.CheckOutDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckOutDate);
                        }
                        dgvBooking.DataSource = filteredBooking;
                    }
                } 
                else if (status == "All" && type == "ALL")
                {
                    List<BookingViewModel> filteredBooking = _bookingController.GetAllBookingByDate(from, to);
                    if (filteredBooking != null)
                    {
                        foreach (var booking in filteredBooking)
                        {
                            booking.TotalAmount = FormHelper.FormatNumberWithCommas(decimal.Parse(booking.TotalAmount));

                            booking.DateCreated = FormHelper.FormatDateTimeWithSuffix(booking.DateCreated);
                            booking.DateModified = FormHelper.FormatDateTimeWithSuffix(booking.DateModified);

                            booking.CheckInDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckInDate);
                            booking.CheckOutDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckOutDate);
                        }
                        dgvBooking.DataSource = filteredBooking;
                    }
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportsForm exportForm = new ExportsForm(dgvBooking);
            exportForm.ShowDialog();
        }
    }
}
