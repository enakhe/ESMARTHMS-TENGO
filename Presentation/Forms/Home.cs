using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Forms.booking;
using ESMART_HMS.Presentation.Forms.Guests;
using ESMART_HMS.Presentation.Forms.Maintenance.CardMaintenance;
using ESMART_HMS.Presentation.Forms.Maintenance.RoomSetting;
using ESMART_HMS.Presentation.Forms.Maintenance.SystemSetup;
using ESMART_HMS.Presentation.Forms.Report;
using ESMART_HMS.Presentation.Forms.Reservation;
using ESMART_HMS.Presentation.Forms.Restaurant;
using ESMART_HMS.Presentation.Forms.Rooms;
using ESMART_HMS.Presentation.Forms.Store.BarStore;
using ESMART_HMS.Presentation.Forms.Tools.Option;
using ESMART_HMS.Presentation.Forms.Transaction;
using ESMART_HMS.Presentation.Middleware;
using ESMART_HMS.Presentation.Sessions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms
{
    public partial class Home : Form
    {
        DashboardForm indexForm;
        GuestForm customerForm;
        RoomForm roomForm;
        ReservationForm reservationForm;
        bookingForm bookingForm;
        OptionsFrom optionsFrom;
        TransactionForm transactionForm;
        BarStoreForm barStoreForm;
        RestaurantForm restaurantForm;

        // Maintenance
        SystemSetupFrom systemSetupFrom;
        RoomSettingForm roomSettingForm;
        CardMaintenanceForm cardMaintenanceForm;

        // Report
        RoomReportForm roomReportForm;
        bookingReportForm bookingReportForm;
        ReservationReportForm reservationReportForm;

        private readonly GuestController _customerController;
        private readonly RoomController _roomController;
        private readonly RoomTypeController _roomTypeController;
        private readonly ReservationController _reservationController;
        private readonly ApplicationUserController _applicationUserController;

        private Color vacantColor = Color.LightGreen;
        private Color reservedColor = Color.LightYellow;
        private Color bookedColor = Color.LightBlue;
        private Image _bgImage;

        public Home(GuestController customerViewModel, RoomController roomController, RoomTypeController roomTypeController, ReservationController reservationController, ApplicationUserController userController)
        {
            _customerController = customerViewModel;
            _roomController = roomController;
            _roomTypeController = roomTypeController;
            _reservationController = reservationController;
            _applicationUserController = userController;
            InitializeComponent();
            LoadBackgroundImage();

            this.BackgroundImage = _bgImage;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.BackColor = Color.White;
            this.Load += new EventHandler(MainForm_Load);
        }

        private void LoadBackgroundImage()
        {
            _bgImage = new Bitmap(@"C:\Users\izuag\OneDrive\Desktop\ESMART\ESMART_HMS\Files\background.jpg");
            this.DoubleBuffered = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MdiClient client = this.Controls.OfType<MdiClient>().FirstOrDefault();
            if (client != null)
            {
                client.BackColor = Color.White;
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            indexForm = null;
        }

        private void Guest_FormClosed(object sender, FormClosedEventArgs e)
        {
            customerForm = null;
        }

        private void customerMainToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (customerForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                customerForm = serviceProvider.GetRequiredService<GuestForm>();
                customerForm.FormClosed += Guest_FormClosed;
                customerForm.MdiParent = this;
                customerForm.BackgroundImage = _bgImage;
                customerForm.BackgroundImageLayout = ImageLayout.Stretch;
                customerForm.Dock = DockStyle.Fill;
                customerForm.Show();
            }
            else
            {
                customerForm.Activate();
            }
        }

        private void Room_FormClosed(object sender, FormClosedEventArgs e)
        {
            roomForm = null;
        }

        private void Option_FormClosed(object sender, FormClosedEventArgs e)
        {
            optionsFrom = null;
        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
            bool IsAuthorized = AuthorizationMiddleware.IsAuthorized(user, "SuperAdmin");
            if (IsAuthorized)
            {
                if (optionsFrom == null)
                {
                    optionsFrom = new OptionsFrom();
                    optionsFrom.FormClosed += Option_FormClosed;
                    optionsFrom.ShowDialog();
                }
                else
                {
                    optionsFrom.Activate();
                }
            }
            else
            {
                MessageBox.Show("You are not authorized to view this resource", "Not Authorized", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void booking_FormClosed(object sender, FormClosedEventArgs e)
        {
            bookingForm = null;
        }

        private void Transaction_FormClosed(object sender, FormClosedEventArgs e)
        {
            transactionForm = null;
        }

        private void BarStore_FormClosed(object sender, FormClosedEventArgs e)
        {
            barStoreForm = null;
        }

        private void storeForToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (barStoreForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                barStoreForm = serviceProvider.GetRequiredService<BarStoreForm>();
                barStoreForm.FormClosed += BarStore_FormClosed;
                barStoreForm.MdiParent = this;
                barStoreForm.BackgroundImage = _bgImage;
                barStoreForm.BackgroundImageLayout = ImageLayout.Stretch;
                barStoreForm.Dock = DockStyle.Fill;
                barStoreForm.Show();
            }
            else
            {
                barStoreForm.Activate();
            }
        }

        private void homeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            indexForm = serviceProvider.GetRequiredService<DashboardForm>();
            indexForm.FormClosed += Dashboard_FormClosed;
            indexForm.MdiParent = this;
            indexForm.Dock = DockStyle.Fill;
            indexForm.BackgroundImage = _bgImage;
            indexForm.BackgroundImageLayout = ImageLayout.Stretch;
            indexForm.Show();
        }


        private void Reservation_FormClosed(object sender, FormClosedEventArgs e)
        {
            reservationForm = null;
        }

        private void addEditReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void SystemSetup_FormClosed(object sender, FormClosedEventArgs e)
        {
            systemSetupFrom = null;
        }

        private void systemSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (systemSetupFrom == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                systemSetupFrom = serviceProvider.GetRequiredService<SystemSetupFrom>();
                systemSetupFrom.FormClosed += SystemSetup_FormClosed;
                systemSetupFrom.ShowDialog();
            }
            else
            {
                reservationForm.Activate();
            }
        }

        private void viewRoomsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void transactionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (transactionForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                transactionForm = serviceProvider.GetRequiredService<TransactionForm>();
                transactionForm.FormClosed += Transaction_FormClosed;
                transactionForm.MdiParent = this;
                transactionForm.BackgroundImage = _bgImage;
                transactionForm.BackgroundImageLayout = ImageLayout.Stretch;
                transactionForm.Dock = DockStyle.Fill;
                transactionForm.Show();
            }
            else
            {
                transactionForm.Activate();
            }
        }

        private void addEditbookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RoomSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            roomSettingForm = null;
        }

        private void roomSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (roomSettingForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                roomSettingForm = serviceProvider.GetRequiredService<RoomSettingForm>();
                roomSettingForm.FormClosed += RoomSetting_FormClosed;
                roomSettingForm.ShowDialog();
            }
            else
            {
                reservationForm.Activate();
            }
        }

        private void CardMaintenance_FormClosed(object sender, FormClosedEventArgs e)
        {
            cardMaintenanceForm = null;
        }

        private void cardMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cardMaintenanceForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                cardMaintenanceForm = serviceProvider.GetRequiredService<CardMaintenanceForm>();
                cardMaintenanceForm.FormClosed += CardMaintenance_FormClosed;
                cardMaintenanceForm.ShowDialog();
            }
            else
            {
                reservationForm.Activate();
            }
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (roomForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                roomForm = serviceProvider.GetRequiredService<RoomForm>();
                roomForm.FormClosed += Room_FormClosed;
                roomForm.MdiParent = this;
                roomForm.BackgroundImage = _bgImage;
                roomForm.BackgroundImageLayout = ImageLayout.Stretch;
                roomForm.Dock = DockStyle.Fill;
                roomForm.Show();
            }
            else
            {
                roomForm.Activate();
                roomForm.LoadData();
            }
        }

        private void manageReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (reservationForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                reservationForm = serviceProvider.GetRequiredService<ReservationForm>();
                reservationForm.FormClosed += Reservation_FormClosed;
                reservationForm.MdiParent = this;
                reservationForm.BackgroundImage = _bgImage;
                reservationForm.BackgroundImageLayout = ImageLayout.Stretch;
                reservationForm.Dock = DockStyle.Fill;
                reservationForm.Show();
            }
            else
            {
                reservationForm.Activate();
            }
        }

        private void managebookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bookingForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                bookingForm = serviceProvider.GetRequiredService<bookingForm>();
                bookingForm.FormClosed += booking_FormClosed;
                bookingForm.MdiParent = this;
                bookingForm.BackgroundImage = _bgImage;
                bookingForm.BackgroundImageLayout = ImageLayout.Stretch;
                bookingForm.Dock = DockStyle.Fill;
                bookingForm.Show();
            }
            else
            {
                bookingForm.Activate();
            }
        }

        private void RoomReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            roomReportForm = null;
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
                roomReportForm.BackgroundImage = _bgImage;
                roomReportForm.BackgroundImageLayout = ImageLayout.Stretch;
                roomReportForm.Dock = DockStyle.Fill;
                roomReportForm.Show();
            }
            else
            {
                roomReportForm.Activate();
            }
        }

        private void bookingReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            bookingReportForm = null;
        }

        private void bookingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bookingReportForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                bookingReportForm = serviceProvider.GetRequiredService<bookingReportForm>();
                bookingReportForm.FormClosed += bookingReport_FormClosed;
                bookingReportForm.MdiParent = this;
                bookingReportForm.BackgroundImage = _bgImage;
                bookingReportForm.BackgroundImageLayout = ImageLayout.Stretch;
                bookingReportForm.Dock = DockStyle.Fill;
                bookingReportForm.Show();
            }
            else
            {
                bookingReportForm.Activate();
            }
        }

        private void ReservationReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            reservationReportForm = null;
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
                reservationReportForm.BackgroundImage = _bgImage;
                reservationReportForm.BackgroundImageLayout = ImageLayout.Stretch;
                reservationReportForm.Dock = DockStyle.Fill;
                reservationReportForm.Show();
            }
            else
            {
                reservationReportForm.Activate();
            }
        }

        private void Restaurant_FormClosed(object sender, FormClosedEventArgs e)
        {
            restaurantForm = null;
        }

        private void storeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (restaurantForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                restaurantForm = serviceProvider.GetRequiredService<RestaurantForm>();
                restaurantForm.FormClosed += Restaurant_FormClosed;
                restaurantForm.MdiParent = this;
                restaurantForm.BackgroundImage = _bgImage;
                restaurantForm.BackgroundImageLayout = ImageLayout.Stretch;
                restaurantForm.Dock = DockStyle.Fill;
                restaurantForm.Show();
            }
            else
            {
                restaurantForm.Activate();
            }
        }
    }
}
