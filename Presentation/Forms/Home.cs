﻿using ESMART_HMS.Application.LockSDK;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Forms.booking;
using ESMART_HMS.Presentation.Forms.Guests;
using ESMART_HMS.Presentation.Forms.Inventory;
using ESMART_HMS.Presentation.Forms.Maintenance;
using ESMART_HMS.Presentation.Forms.Maintenance.CardMaintenance;
using ESMART_HMS.Presentation.Forms.Maintenance.RoomSetting;
using ESMART_HMS.Presentation.Forms.Maintenance.SystemSetup;
using ESMART_HMS.Presentation.Forms.Report;
using ESMART_HMS.Presentation.Forms.Reservation;
using ESMART_HMS.Presentation.Forms.Restaurant;
using ESMART_HMS.Presentation.Forms.Rooms;
using ESMART_HMS.Presentation.Forms.Store.BarStore;
using ESMART_HMS.Presentation.Forms.Tools.Option;
using ESMART_HMS.Presentation.Forms.Tools.Options.Accounts;
using ESMART_HMS.Presentation.Forms.Transaction;
using ESMART_HMS.Presentation.Middleware;
using ESMART_HMS.Presentation.Sessions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;
using ESMART_HMS.Presentation.Forms.FrontDesk.Room.Building;
using ESMART_HMS.Presentation.Forms.Maintenance.Profile;
using ESMART_HMS.Presentation.Forms.Inventory.Store;

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
        Presentation.Forms.Inventory.Order orderForm;
        SystemSetupFrom systemSetupFrom;
        RoomSettingForm roomSettingForm;
        CardMaintenanceForm cardMaintenanceForm;
        RoomReportForm roomReportForm;
        bookingReportForm bookingReportForm;
        ReservationReportForm reservationReportForm;
        MenuItemForm menuItemForm;
        UserForm userForm;
        RecycledItemForm recycledItemForm;
        ProfileForm profileForm;
        TransactionReport transactionReport;
        StoreForm storeForm; 

        private readonly GuestController _customerController;
        private readonly RoomController _roomController;
        private readonly RoomTypeController _roomTypeController;
        private readonly ReservationController _reservationController;
        private readonly ApplicationUserController _applicationUserController;
        private readonly LicenseController _licenseController;
        private readonly ConfigurationController _configurationController;
        private readonly CardController _cardController;

        private Color vacantColor = Color.LightGreen;
        private Color reservedColor = Color.LightYellow;
        private Color bookedColor = Color.LightBlue;
        private Image _bgImage;
        private DispatcherTimer dispatcherTimer;
        int st = 0;
        string computerName = Environment.MachineName;


        public Home(GuestController customerViewModel, RoomController roomController, RoomTypeController roomTypeController, ReservationController reservationController, ApplicationUserController userController, LicenseController licenseController, ConfigurationController configurationController, CardController cardController)
        {
            _customerController = customerViewModel;
            _roomController = roomController;
            _roomTypeController = roomTypeController;
            _reservationController = reservationController;
            _applicationUserController = userController;
            _licenseController = licenseController;
            _configurationController = configurationController;
            _cardController = cardController;
            InitializeComponent();

            this.BackgroundImage = _bgImage;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.BackColor = Color.White;
            this.Load += new EventHandler(MainForm_Load);
        }

        private void ApplyAuthorization()
        {
            List<string> roles = new List<string> { "Admin", "SuperAdmin" };
            ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
            AuthorizationMiddleware.Protect(user, systemSetupToolStripMenuItem, roles);
            AuthorizationMiddleware.Protect(user, recycleBinToolStripMenuItem, roles);
        }
        private void ApplyAuthorization2()
        {
            List<string> roles = new List<string> { "Admin", "SuperAdmin", "Manager" };
            ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
            AuthorizationMiddleware.Protect(user, roomSettingToolStripMenuItem, roles);
            AuthorizationMiddleware.Protect(user, manageReportsToolStripMenuItem, roles);
            AuthorizationMiddleware.Protect(user, usersSettingToolStripMenuItem, roles);
            AuthorizationMiddleware.Protect(user, cardMaintenanceToolStripMenuItem, roles);
            AuthorizationMiddleware.Protect(user, profileSettingToolStripMenuItem, roles);
            AuthorizationMiddleware.Protect(user, accountsToolStripMenuItem, roles);
            AuthorizationMiddleware.Protect(user, toolsToolStripMenuItem, roles);
        }

        private void ApplyAuthorization3()
        {
            List<string> roles = new List<string> { "Admin", "SuperAdmin", "Front Desk" };
            ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
            AuthorizationMiddleware.Protect(user, customerToolStripMenuItem, roles);
            AuthorizationMiddleware.Protect(user, manageReportsToolStripMenuItem, roles);
            AuthorizationMiddleware.Protect(user, newOrderToolStripMenuItem, roles);
        }

        private void ApplyAuthorization4()
        {
            List<string> roles = new List<string> { "Admin", "SuperAdmin", "Inventory" };
            ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
            AuthorizationMiddleware.Protect(user, inventoryToolStripMenuItem, roles);
        }

        private void ApplyAuthorization5()
        {
            List<string> roles = new List<string> { "Admin", "SuperAdmin", "Accountant" };
            ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
            AuthorizationMiddleware.Protect(user, transactionReportToolStripMenuItem, roles);
            AuthorizationMiddleware.Protect(user, manageReportsToolStripMenuItem, roles);
            AuthorizationMiddleware.Protect(user, accountsToolStripMenuItem, roles);
            AuthorizationMiddleware.Protect(user, systemSetupToolStripMenuItem, roles);
        }

        private void MainForm_Load(object sender, EventArgs e)
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
                customerForm.Dock = DockStyle.Fill;
                customerForm.Show();
            }
            else
            {
                customerForm.Activate();
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

        private void homeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            indexForm = serviceProvider.GetRequiredService<DashboardForm>();
            indexForm.FormClosed += Dashboard_FormClosed;
            indexForm.MdiParent = this;
            indexForm.Dock = DockStyle.Fill;
            indexForm.Show();
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
                systemSetupFrom.Activate();
            }
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
                transactionForm.Dock = DockStyle.Fill;
                transactionForm.Show();
            }
            else
            {
                transactionForm.Activate();
            }
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

        private void Room_FormClosed(object sender, FormClosedEventArgs e)
        {
            roomForm = null;
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
                roomForm.Dock = DockStyle.Fill;
                roomForm.Show();
            }
            else
            {
                roomForm.Activate();
                roomForm.LoadData();
            }
        }

        private void Reservation_FormClosed(object sender, FormClosedEventArgs e)
        {
            reservationForm = null;
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
                roomReportForm.Dock = DockStyle.Fill;
                roomReportForm.Show();
            }
            else
            {
                roomReportForm.Activate();
            }
        }

        private void BookingReport_FormClosed(object sender, FormClosedEventArgs e)
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

        private void MenuItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            menuItemForm = null;
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menuItemForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                menuItemForm = serviceProvider.GetRequiredService<MenuItemForm>();
                menuItemForm.FormClosed += MenuItem_FormClosed;
                menuItemForm.MdiParent = this;
                menuItemForm.Dock = DockStyle.Fill;
                menuItemForm.Show();
            }
            else
            {
                menuItemForm.Activate();
            }
        }

        private void User_FormClosed(object sender, FormClosedEventArgs e)
        {
            userForm = null;
        }

        private void usersSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                userForm = serviceProvider.GetRequiredService<UserForm>();
                userForm.FormClosed += User_FormClosed;
                userForm.ShowDialog();
            }
            else
            {
                userForm.Activate();
            }
        }

        private void BarStore_FormClosed(object sender, FormClosedEventArgs e)
        {
            barStoreForm = null;
        }

        private void barToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (barStoreForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                barStoreForm = serviceProvider.GetRequiredService<BarStoreForm>();
                barStoreForm.FormClosed += BarStore_FormClosed;
                barStoreForm.MdiParent = this;
                barStoreForm.Dock = DockStyle.Fill;
                barStoreForm.Show();
            }
            else
            {
                barStoreForm.Activate();
            }
        }

        private void restaurantToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (restaurantForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                restaurantForm = serviceProvider.GetRequiredService<RestaurantForm>();
                restaurantForm.FormClosed += Restaurant_FormClosed;
                restaurantForm.MdiParent = this;
                restaurantForm.Dock = DockStyle.Fill;
                restaurantForm.Show();
            }
            else
            {
                restaurantForm.Activate();
            }
        }

        private void Recycled_FormClosed(object sender, FormClosedEventArgs e)
        {
            recycledItemForm = null;
        }

        private void recycleBinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (recycledItemForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                recycledItemForm = serviceProvider.GetRequiredService<RecycledItemForm>();
                recycledItemForm.FormClosed += Recycled_FormClosed;
                recycledItemForm.MdiParent = this;
                recycledItemForm.Dock = DockStyle.Fill;
                recycledItemForm.Show();
            }
            else
            {
                recycledItemForm.Activate();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to close the application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            LockApp lockApp = serviceProvider.GetRequiredService<LockApp>();
            lockApp.ShowDialog();
        }


        private void InitializeTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
        }

        private void Home_Load(object sender, EventArgs e)
        {
            InitializeTimer();
            dispatcherTimer.Start();
        }

        private void btnRecycle_Click(object sender, EventArgs e)
        {
            StringBuilder card_snr = new StringBuilder();
            st = LockSDKHeaders.TP_CancelCard(card_snr);
            if (st == 1)
            {
                MessageBox.Show("Successfully recycled card", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            var loginForm = serviceProvider.GetRequiredService<LoginForm>();
            var loginResult = loginForm.ShowDialog();
        }

        private void profileSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            LockApp lockApp = serviceProvider.GetRequiredService<LockApp>();
            if (lockApp.ShowDialog() == DialogResult.OK)
            {
                profileForm = serviceProvider.GetRequiredService<ProfileForm>();
                profileForm.ShowDialog();
            }
        }

        private void Order_FormClosed(object sender, FormClosedEventArgs e)
        {
            orderForm = null;
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (orderForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                orderForm = serviceProvider.GetRequiredService<Presentation.Forms.Inventory.Order>();
                orderForm.FormClosed += Order_FormClosed;
                orderForm.MdiParent = this;
                orderForm.Dock = DockStyle.Fill;
                orderForm.Show();
            }
            else
            {
                orderForm.Activate();
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            indexForm = serviceProvider.GetRequiredService<DashboardForm>();
            indexForm.FormClosed += Dashboard_FormClosed;
            indexForm.MdiParent = this;
            indexForm.Dock = DockStyle.Fill;
            indexForm.Show();
        }

        private void TransactionReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            transactionForm = null;
        }

        private void transactionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (transactionReport == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                transactionReport = serviceProvider.GetRequiredService<TransactionReport>();
                transactionReport.FormClosed += TransactionReport_FormClosed;
                transactionReport.MdiParent = this;
                transactionReport.Dock = DockStyle.Fill;
                transactionReport.Show();
            }
            else
            {
                transactionReport.Activate();
            }
        }

        private void Store_FormClosed(object sender, FormClosedEventArgs e)
        {
            storeForm = null;
        }

        private void storeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (storeForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                storeForm = serviceProvider.GetRequiredService<StoreForm>();
                storeForm.FormClosed += Store_FormClosed;
                storeForm.MdiParent = this;
                storeForm.Dock = DockStyle.Fill;
                storeForm.Show();
            }
            else
            {
                storeForm.Activate();
            }
        }

        private void barItemReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
