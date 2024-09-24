using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Windows.Forms;
using System.Windows.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ESMART_HMS.Presentation.Forms.Report
{
    public partial class bookingReportForm : Form
    {
        private readonly bookingController _bookingController;
        private readonly RoomController _roomController;
        private readonly RoomTypeController _roomTypeController;
        private DispatcherTimer dispatcherTimer;

        public bookingReportForm(bookingController bookingController, RoomController roomController, RoomTypeController roomTypeController)
        {
            _bookingController = bookingController;
            _roomController = roomController;
            _roomTypeController = roomTypeController;
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            string status = txtStatus.SelectedItem?.ToString();
            string type = txtType.SelectedValue.ToString();
            DateTime from = txtFrom.Value;
            DateTime to = txtTo.Value;

            LoadRoomType();
            if (status != null)
            {
                if (status == "Checked In" && type == "ALL")
                {
                    GetBookingByDate(status, type, from, to);
                }
                else if (status == "Checked Out" && type == "ALL")
                {
                    GetCheckedOutBookingByDate(status, type, from, to);
                }
                else if (status == "Checked In")
                {
                    GetActiveBooking(status, type, from, to);
                }
                else if (status == "Checked Out")
                {
                    GetInActiveBooking(status, type, from, to);
                }
                else if (status == "All" && type != "ALL")
                {
                    GetAllBookings(status, type, from, to);
                }
                else if (status == "All" && type == "ALL")
                {
                    GetAllBookingByDate(status, type, from, to);
                }
            }
            
        }

        private void bookingReportForm_Load(object sender, EventArgs e)
        {
            dispatcherTimer.Start();
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

        public void GetBookingByDate(string status, string type, DateTime from, DateTime to)
        {
            if (status == "Checked In" && type == "ALL")
            {
                List<BookingViewModel> filteredbooking = _bookingController.GetbookingByDate(from, to);
                if (filteredbooking != null)
                {
                    foreach (var booking in filteredbooking)
                    {
                        booking.TotalAmount = FormHelper.FormatNumberWithCommas(decimal.Parse(booking.TotalAmount));

                        booking.DateCreated = FormHelper.FormatDateTimeWithSuffix(booking.DateCreated);
                        booking.DateModified = FormHelper.FormatDateTimeWithSuffix(booking.DateModified);

                        booking.CheckInDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckInDate);
                        booking.CheckOutDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckOutDate);
                    }
                    dgvbooking.DataSource = filteredbooking;
                }
            }
        }

        public void GetCheckedOutBookingByDate(string status, string type, DateTime from, DateTime to)
        {
            if (status == "Checked Out" && type == "ALL")
            {
                List<BookingViewModel> filteredbooking = _bookingController.GetCheckedOutbookingByDate(from, to);
                if (filteredbooking != null)
                {
                    foreach (var booking in filteredbooking)
                    {
                        booking.TotalAmount = FormHelper.FormatNumberWithCommas(decimal.Parse(booking.TotalAmount));

                        booking.DateCreated = FormHelper.FormatDateTimeWithSuffix(booking.DateCreated);
                        booking.DateModified = FormHelper.FormatDateTimeWithSuffix(booking.DateModified);

                        booking.CheckInDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckInDate);
                        booking.CheckOutDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckOutDate);
                    }
                    dgvbooking.DataSource = filteredbooking;
                }
            }
        }

        public void GetActiveBooking(string status, string type, DateTime from, DateTime to)
        {
            if (status == "Checked In")
            {
                List<BookingViewModel> filteredbooking = _bookingController.GetActivebookingByFilter(type, from, to);
                if (filteredbooking != null)
                {
                    foreach (var booking in filteredbooking)
                    {
                        booking.TotalAmount = FormHelper.FormatNumberWithCommas(decimal.Parse(booking.TotalAmount));

                        booking.DateCreated = FormHelper.FormatDateTimeWithSuffix(booking.DateCreated);
                        booking.DateModified = FormHelper.FormatDateTimeWithSuffix(booking.DateModified);

                        booking.CheckInDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckInDate);
                        booking.CheckOutDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckOutDate);
                    }
                    dgvbooking.DataSource = filteredbooking;
                }
            }
        }

        public void GetInActiveBooking(string status, string type, DateTime from, DateTime to)
        {
            if (status == "Checked Out")
            {
                List<BookingViewModel> filteredbooking = _bookingController.GetInActivebookingByfilter(type, from, to);
                if (filteredbooking != null)
                {
                    foreach (var booking in filteredbooking)
                    {
                        booking.TotalAmount = FormHelper.FormatNumberWithCommas(decimal.Parse(booking.TotalAmount));

                        booking.DateCreated = FormHelper.FormatDateTimeWithSuffix(booking.DateCreated);
                        booking.DateModified = FormHelper.FormatDateTimeWithSuffix(booking.DateModified);

                        booking.CheckInDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckInDate);
                        booking.CheckOutDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckOutDate);
                    }
                    dgvbooking.DataSource = filteredbooking;
                }
            }
        }

        private void GetAllBookings(string status, string type, DateTime from, DateTime to)
        {
            if (status == "All" && type != "ALL")
            {
                List<BookingViewModel> filteredbooking = _bookingController.GetRoomTypebooking(type, from, to);
                if (filteredbooking != null)
                {
                    foreach (var booking in filteredbooking)
                    {
                        booking.TotalAmount = FormHelper.FormatNumberWithCommas(decimal.Parse(booking.TotalAmount));

                        booking.DateCreated = FormHelper.FormatDateTimeWithSuffix(booking.DateCreated);
                        booking.DateModified = FormHelper.FormatDateTimeWithSuffix(booking.DateModified);

                        booking.CheckInDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckInDate);
                        booking.CheckOutDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckOutDate);
                    }
                    dgvbooking.DataSource = filteredbooking;
                }
            }
        }

        private void GetAllBookingByDate(string status, string type, DateTime from, DateTime to)
        {
            if (status == "All" && type == "ALL")
            {
                List<BookingViewModel> filteredbooking = _bookingController.GetAllbookingByDate(from, to);
                if (filteredbooking != null)
                {
                    foreach (var booking in filteredbooking)
                    {
                        booking.TotalAmount = FormHelper.FormatNumberWithCommas(decimal.Parse(booking.TotalAmount));

                        booking.DateCreated = FormHelper.FormatDateTimeWithSuffix(booking.DateCreated);
                        booking.DateModified = FormHelper.FormatDateTimeWithSuffix(booking.DateModified);

                        booking.CheckInDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckInDate);
                        booking.CheckOutDate = FormHelper.FormatDateTimeWithSuffix(booking.CheckOutDate);
                    }
                    dgvbooking.DataSource = filteredbooking;
                }
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
                    GetBookingByDate(status, type, from, to);
                }
                else if (status == "Checked Out" && type == "ALL")
                {
                    GetCheckedOutBookingByDate(status, type, from, to);
                }
                else if (status == "Checked In")
                {
                    GetActiveBooking(status, type, from, to);
                }
                else if (status == "Checked Out")
                {
                    GetInActiveBooking(status, type, from, to);
                }
                else if (status == "All" && type != "ALL")
                {
                    GetAllBookings(status, type, from, to);
                }
                else if (status == "All" && type == "ALL")
                {
                    GetAllBookingByDate(status, type, from, to);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportsForm exportForm = new ExportsForm(dgvbooking);
            exportForm.ShowDialog();
        }
    }
}
