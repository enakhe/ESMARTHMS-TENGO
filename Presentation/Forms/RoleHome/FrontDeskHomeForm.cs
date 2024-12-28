using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.Forms.Guests;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Configuration;
using ESMART_HMS.Presentation.Forms.Rooms;
using ESMART_HMS.Presentation.Forms.booking;
using ESMART_HMS.Presentation.Forms.Reservation;
using ESMART_HMS.Presentation.Forms.Report;

namespace ESMART_HMS.Presentation.Forms.RoleHome
{
    public partial class FrontDeskHomeForm : Form
    {

        GuestForm guestForm;
        RoomForm roomForm;
        ReservationForm reservationForm;
        bookingForm bookingForm;

        RoomReportForm roomReportForm;
        bookingReportForm bookingReportForm;
        ReservationReportForm reservationReportForm;

        private readonly LicenseController _licenseController;
        private readonly ConfigurationController _configurationController;

        public FrontDeskHomeForm(LicenseController licenseController, ConfigurationController configurationController)
        {
            _licenseController = licenseController;
            _configurationController = configurationController;
            InitializeComponent();
        }

        private void FrontDeskHomeForm_Load(object sender, EventArgs e)
        {
            MdiClient client = this.Controls.OfType<MdiClient>().FirstOrDefault();
            if (client != null)
            {
                client.BackColor = Color.White;
            }

            LicenseInfo licenseInfo = _licenseController.GetLicenseInfo();
            Configuration configuration = _configurationController.GetConfigurationValue("Trial Mode");

            if (licenseInfo != null)
            {
                if (licenseInfo.HotelName != null)
                {
                    this.Text = $"ESMART Hotel Management Software ({licenseInfo.HotelName})";
                }
            }
            else if (configuration != null)
            {
                if (configuration.Value.ToString() == "True")
                {
                    this.Text = $"ESMART Hotel Management Software (Free Trial)";
                }
            }

            string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "background.jpg");

            try
            {
                this.BackgroundImage = new Bitmap(imagePath);
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (guestForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                guestForm = serviceProvider.GetRequiredService<GuestForm>();
                guestForm.FormClosed += Guest_FormClosed;
                guestForm.MdiParent = this;
                guestForm.Dock = DockStyle.Fill;
                guestForm.Show();
            }
            else
            {
                guestForm.Activate();
            }
        }

        private void Guest_FormClosed(object sender, FormClosedEventArgs e)
        {
            guestForm = null;
        }

        private void roomsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (roomForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                roomForm = serviceProvider.GetRequiredService<RoomForm>();
                roomForm.FormClosed += Room_FormClosed;
                roomForm.MdiParent = this;
                roomForm.Dock = DockStyle.Fill;
                roomForm.Show();
            }
            else
            {
                roomForm.Activate();
                roomForm.LoadData();
            }
        }

        private void Room_FormClosed(object sender, FormClosedEventArgs e)
        {
            roomForm = null;
        }

        private void reservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (reservationForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                reservationForm = serviceProvider.GetRequiredService<ReservationForm>();
                reservationForm.FormClosed += Reservation_FormClosed;
                reservationForm.MdiParent = this;
                reservationForm.Dock = DockStyle.Fill;
                reservationForm.Show();
            }
            else
            {
                reservationForm.Activate();
            }
        }

        private void Reservation_FormClosed(object sender, FormClosedEventArgs e)
        {
            reservationForm = null;
        }

        private void bookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bookingForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                bookingForm = serviceProvider.GetRequiredService<bookingForm>();
                bookingForm.FormClosed += booking_FormClosed;
                bookingForm.MdiParent = this;
                bookingForm.Dock = DockStyle.Fill;
                bookingForm.Show();
            }
            else
            {
                bookingForm.Activate();
            }
        }

        private void booking_FormClosed(object sender, FormClosedEventArgs e)
        {
            bookingForm = null;
        }

        private void roomReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (roomReportForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                roomReportForm = serviceProvider.GetRequiredService<RoomReportForm>();
                roomReportForm.FormClosed += RoomReport_FormClosed;
                roomReportForm.MdiParent = this;
                roomReportForm.Dock = DockStyle.Fill;
                roomReportForm.Show();
            }
            else
            {
                roomReportForm.Activate();
            }
        }

        private void RoomReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            roomReportForm = null;
        }

        private void bookingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bookingReportForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                bookingReportForm = serviceProvider.GetRequiredService<bookingReportForm>();
                bookingReportForm.FormClosed += BookingReport_FormClosed;
                bookingReportForm.MdiParent = this;
                bookingReportForm.Dock = DockStyle.Fill;
                bookingReportForm.Show();
            }
            else
            {
                bookingReportForm.Activate();
            }
        }

        private void BookingReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            bookingReportForm = null;
        }

        private void reservationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (reservationReportForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                reservationReportForm = serviceProvider.GetRequiredService<ReservationReportForm>();
                reservationReportForm.FormClosed += ReservationReport_FormClosed;
                reservationReportForm.MdiParent = this;
                reservationReportForm.Dock = DockStyle.Fill;
                reservationReportForm.Show();
            }
            else
            {
                reservationReportForm.Activate();
            }
        }

        private void ReservationReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            reservationReportForm = null;
        }
    }
}
