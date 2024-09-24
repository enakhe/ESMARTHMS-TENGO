using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.ViewModels;
using iTextSharp.text.pdf.parser.clipper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ESMART_HMS.Presentation.Forms.Report
{
    public partial class ReservationReportForm : Form
    {
        private DispatcherTimer dispatcherTimer;
        private readonly ReservationController _reservationController;
        private readonly RoomController _roomController;
        private readonly RoomTypeController _roomTypeController;
        public ReservationReportForm(ReservationController reservationController, RoomController roomController, RoomTypeController roomTypeController)
        {
            _roomController = roomController;
            _roomTypeController = roomTypeController;
            _reservationController = reservationController;
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            InitializeTimer();
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

            if (status == "All" && type != "ALL")
            {
                FilterReservationByRtAndDate(type, from, to);
            }
            else if (type == "ALL" && status != "ALL")
            {
                FilterReservationByStAndDate(status, from, to);
            }
            else if (type != "ALL" && status != "All")
            {
                FilterReservation(type, from, to, status);
            }
            else
            {
                FilterReservationByDate(from, to);
            }
        }

        private void FilterReservation(string roomTypeId, DateTime fromTime, DateTime endTime, string paymentStatus)
        { 
            List<ReservationViewModel> filtreredReservation = _reservationController.GetReservationByPaymentStatus(roomTypeId, fromTime, endTime, paymentStatus);
            if (filtreredReservation != null)
            {
                foreach (var reservation in filtreredReservation)
                {
                    reservation.Amount = FormHelper.FormatNumberWithCommas(decimal.Parse(reservation.Amount));
                    reservation.AmountPaid = FormHelper.FormatNumberWithCommas(decimal.Parse(reservation.AmountPaid));
                    reservation.Balance = FormHelper.FormatNumberWithCommas(decimal.Parse(reservation.Balance));

                    reservation.DateCreated = FormHelper.FormatDateTimeWithSuffix(reservation.DateCreated);
                    reservation.DateModified = FormHelper.FormatDateTimeWithSuffix(reservation.DateModified);

                    reservation.CheckInDate = FormHelper.FormatDateTimeWithSuffix(reservation.CheckInDate);
                    reservation.CheckOutDate = FormHelper.FormatDateTimeWithSuffix(reservation.CheckOutDate);
                }
                dgvReservation.DataSource = filtreredReservation;
            }
        }

        private void FilterReservationByRtAndDate(string roomTypeId, DateTime fromTime, DateTime endTime)
        {
            List<ReservationViewModel> filtreredReservation = _reservationController.GetReservationByRoomTypeAndDate(roomTypeId, fromTime, endTime);
            if (filtreredReservation != null)
            {
                foreach (var reservation in filtreredReservation)
                {
                    reservation.Amount = FormHelper.FormatNumberWithCommas(decimal.Parse(reservation.Amount));
                    reservation.AmountPaid = FormHelper.FormatNumberWithCommas(decimal.Parse(reservation.AmountPaid));
                    reservation.Balance = FormHelper.FormatNumberWithCommas(decimal.Parse(reservation.Balance));

                    reservation.DateCreated = FormHelper.FormatDateTimeWithSuffix(reservation.DateCreated);
                    reservation.DateModified = FormHelper.FormatDateTimeWithSuffix(reservation.DateModified);

                    reservation.CheckInDate = FormHelper.FormatDateTimeWithSuffix(reservation.CheckInDate);
                    reservation.CheckOutDate = FormHelper.FormatDateTimeWithSuffix(reservation.CheckOutDate);
                }
                dgvReservation.DataSource = filtreredReservation;
            }
        }

        private void FilterReservationByStAndDate(string status, DateTime fromTime, DateTime endTime)
        {
            List<ReservationViewModel> filtreredReservation = _reservationController.GetReservationByStatusAndDate(status, fromTime, endTime);
            if (filtreredReservation != null)
            {
                foreach (var reservation in filtreredReservation)
                {
                    reservation.Amount = FormHelper.FormatNumberWithCommas(decimal.Parse(reservation.Amount));
                    reservation.AmountPaid = FormHelper.FormatNumberWithCommas(decimal.Parse(reservation.AmountPaid));
                    reservation.Balance = FormHelper.FormatNumberWithCommas(decimal.Parse(reservation.Balance));

                    reservation.DateCreated = FormHelper.FormatDateTimeWithSuffix(reservation.DateCreated);
                    reservation.DateModified = FormHelper.FormatDateTimeWithSuffix(reservation.DateModified);

                    reservation.CheckInDate = FormHelper.FormatDateTimeWithSuffix(reservation.CheckInDate);
                    reservation.CheckOutDate = FormHelper.FormatDateTimeWithSuffix(reservation.CheckOutDate);
                }
                dgvReservation.DataSource = filtreredReservation;
            }
        }

        private void FilterReservationByDate(DateTime fromTime, DateTime endTime)
        {
            List<ReservationViewModel> filtreredReservation = _reservationController.GetReservationDate(fromTime, endTime);
            if (filtreredReservation != null)
            {
                foreach (var reservation in filtreredReservation)
                {
                    reservation.Amount = FormHelper.FormatNumberWithCommas(decimal.Parse(reservation.Amount));
                    reservation.AmountPaid = FormHelper.FormatNumberWithCommas(decimal.Parse(reservation.AmountPaid));
                    reservation.Balance = FormHelper.FormatNumberWithCommas(decimal.Parse(reservation.Balance));

                    reservation.DateCreated = FormHelper.FormatDateTimeWithSuffix(reservation.DateCreated);
                    reservation.DateModified = FormHelper.FormatDateTimeWithSuffix(reservation.DateModified);

                    reservation.CheckInDate = FormHelper.FormatDateTimeWithSuffix(reservation.CheckInDate);
                    reservation.CheckOutDate = FormHelper.FormatDateTimeWithSuffix(reservation.CheckOutDate);
                }
                dgvReservation.DataSource = filtreredReservation;
            }
        }

        private void ReservationReportForm_Load(object sender, EventArgs e)
        {
            dispatcherTimer.Start();
            LoadRoomType();

            txtFrom.Value = DateTime.Now;
            txtTo.Value = DateTime.Now;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportsForm exportForm = new ExportsForm(dgvReservation);
            exportForm.ShowDialog();
        }
    }
}
