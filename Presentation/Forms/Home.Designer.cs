namespace ESMART_HMS.Presentation.Forms
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.menuTransition = new System.Windows.Forms.Timer(this.components);
            this.sidebarTransition = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerMainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.roomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageReservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managebookingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restaurantToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.laundryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gymToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spaServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sportFacilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swimmingPoolServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservationReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barItemReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cardMaintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardwareSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importsExportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreDataFromBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taxFileMaintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultAccountSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearDataFiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataFileStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archiveDataFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recycleBinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eSMART_HMSDBDataSet = new ESMART_HMS.ESMART_HMSDBDataSet();
            this.roomBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.roomTableAdapter = new ESMART_HMS.ESMART_HMSDBDataSetTableAdapters.RoomTableAdapter();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eSMART_HMSDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 41);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 676);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.customerToolStripMenuItem,
            this.inventoryToolStripMenuItem,
            this.newOrderToolStripMenuItem,
            this.manageReportsToolStripMenuItem,
            this.accountsToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 10, 0, 10);
            this.menuStrip1.Size = new System.Drawing.Size(1924, 41);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem1});
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(86, 21);
            this.homeToolStripMenuItem.Text = "Dashboard";
            this.homeToolStripMenuItem.Visible = false;
            // 
            // homeToolStripMenuItem1
            // 
            this.homeToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("homeToolStripMenuItem1.Image")));
            this.homeToolStripMenuItem1.Name = "homeToolStripMenuItem1";
            this.homeToolStripMenuItem1.Size = new System.Drawing.Size(117, 26);
            this.homeToolStripMenuItem1.Text = "Home";
            this.homeToolStripMenuItem1.Click += new System.EventHandler(this.homeToolStripMenuItem1_Click);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerMainToolStripMenuItem,
            this.toolStripSeparator1,
            this.roomsToolStripMenuItem,
            this.manageReservationToolStripMenuItem,
            this.managebookingsToolStripMenuItem});
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(86, 21);
            this.customerToolStripMenuItem.Text = "Front Desk";
            // 
            // customerMainToolStripMenuItem
            // 
            this.customerMainToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("customerMainToolStripMenuItem.Image")));
            this.customerMainToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.customerMainToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.customerMainToolStripMenuItem.Name = "customerMainToolStripMenuItem";
            this.customerMainToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.customerMainToolStripMenuItem.Text = "Guests";
            this.customerMainToolStripMenuItem.Click += new System.EventHandler(this.customerMainToolStripMenuItem_Click_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // roomsToolStripMenuItem
            // 
            this.roomsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("roomsToolStripMenuItem.Image")));
            this.roomsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.roomsToolStripMenuItem.Name = "roomsToolStripMenuItem";
            this.roomsToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.roomsToolStripMenuItem.Text = "Rooms";
            this.roomsToolStripMenuItem.Click += new System.EventHandler(this.roomsToolStripMenuItem_Click);
            // 
            // manageReservationToolStripMenuItem
            // 
            this.manageReservationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("manageReservationToolStripMenuItem.Image")));
            this.manageReservationToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.manageReservationToolStripMenuItem.Name = "manageReservationToolStripMenuItem";
            this.manageReservationToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.manageReservationToolStripMenuItem.Text = "Reservations";
            this.manageReservationToolStripMenuItem.Click += new System.EventHandler(this.manageReservationToolStripMenuItem_Click);
            // 
            // managebookingsToolStripMenuItem
            // 
            this.managebookingsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("managebookingsToolStripMenuItem.Image")));
            this.managebookingsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.managebookingsToolStripMenuItem.Name = "managebookingsToolStripMenuItem";
            this.managebookingsToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.managebookingsToolStripMenuItem.Text = "Bookings";
            this.managebookingsToolStripMenuItem.Click += new System.EventHandler(this.managebookingsToolStripMenuItem_Click);
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemsToolStripMenuItem,
            this.barToolStripMenuItem,
            this.restaurantToolStripMenuItem1,
            this.laundryToolStripMenuItem});
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.inventoryToolStripMenuItem.Text = "Inventory";
            // 
            // itemsToolStripMenuItem
            // 
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.itemsToolStripMenuItem.Text = "Items";
            this.itemsToolStripMenuItem.Click += new System.EventHandler(this.itemsToolStripMenuItem_Click);
            // 
            // barToolStripMenuItem
            // 
            this.barToolStripMenuItem.Name = "barToolStripMenuItem";
            this.barToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.barToolStripMenuItem.Text = "Bar";
            this.barToolStripMenuItem.Click += new System.EventHandler(this.barToolStripMenuItem_Click);
            // 
            // restaurantToolStripMenuItem1
            // 
            this.restaurantToolStripMenuItem1.Name = "restaurantToolStripMenuItem1";
            this.restaurantToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.restaurantToolStripMenuItem1.Text = "Restaurant";
            this.restaurantToolStripMenuItem1.Click += new System.EventHandler(this.restaurantToolStripMenuItem1_Click);
            // 
            // laundryToolStripMenuItem
            // 
            this.laundryToolStripMenuItem.Name = "laundryToolStripMenuItem";
            this.laundryToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.laundryToolStripMenuItem.Text = "Laundry";
            // 
            // newOrderToolStripMenuItem
            // 
            this.newOrderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gymToolStripMenuItem,
            this.spaServiceToolStripMenuItem,
            this.sportFacilitiesToolStripMenuItem,
            this.swimmingPoolServiceToolStripMenuItem});
            this.newOrderToolStripMenuItem.Name = "newOrderToolStripMenuItem";
            this.newOrderToolStripMenuItem.Size = new System.Drawing.Size(108, 21);
            this.newOrderToolStripMenuItem.Text = "Other Services";
            // 
            // gymToolStripMenuItem
            // 
            this.gymToolStripMenuItem.Name = "gymToolStripMenuItem";
            this.gymToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.gymToolStripMenuItem.Text = "Gym";
            // 
            // spaServiceToolStripMenuItem
            // 
            this.spaServiceToolStripMenuItem.Name = "spaServiceToolStripMenuItem";
            this.spaServiceToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.spaServiceToolStripMenuItem.Text = "Spa Service";
            // 
            // sportFacilitiesToolStripMenuItem
            // 
            this.sportFacilitiesToolStripMenuItem.Name = "sportFacilitiesToolStripMenuItem";
            this.sportFacilitiesToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.sportFacilitiesToolStripMenuItem.Text = "Sport Facilities";
            // 
            // swimmingPoolServiceToolStripMenuItem
            // 
            this.swimmingPoolServiceToolStripMenuItem.Name = "swimmingPoolServiceToolStripMenuItem";
            this.swimmingPoolServiceToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.swimmingPoolServiceToolStripMenuItem.Text = "Swimming Pool Service";
            // 
            // manageReportsToolStripMenuItem
            // 
            this.manageReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roomReportToolStripMenuItem,
            this.bookingReportToolStripMenuItem,
            this.reservationReportToolStripMenuItem,
            this.transactionReportToolStripMenuItem,
            this.barItemReportToolStripMenuItem});
            this.manageReportsToolStripMenuItem.Name = "manageReportsToolStripMenuItem";
            this.manageReportsToolStripMenuItem.Size = new System.Drawing.Size(67, 21);
            this.manageReportsToolStripMenuItem.Text = "Reports";
            // 
            // roomReportToolStripMenuItem
            // 
            this.roomReportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("roomReportToolStripMenuItem.Image")));
            this.roomReportToolStripMenuItem.Name = "roomReportToolStripMenuItem";
            this.roomReportToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.roomReportToolStripMenuItem.Text = "Room Report";
            this.roomReportToolStripMenuItem.Click += new System.EventHandler(this.roomReportToolStripMenuItem_Click);
            // 
            // bookingReportToolStripMenuItem
            // 
            this.bookingReportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bookingReportToolStripMenuItem.Image")));
            this.bookingReportToolStripMenuItem.Name = "bookingReportToolStripMenuItem";
            this.bookingReportToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.bookingReportToolStripMenuItem.Text = "Booking Report";
            this.bookingReportToolStripMenuItem.Click += new System.EventHandler(this.bookingReportToolStripMenuItem_Click);
            // 
            // reservationReportToolStripMenuItem
            // 
            this.reservationReportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reservationReportToolStripMenuItem.Image")));
            this.reservationReportToolStripMenuItem.Name = "reservationReportToolStripMenuItem";
            this.reservationReportToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.reservationReportToolStripMenuItem.Text = "Reservation Report";
            this.reservationReportToolStripMenuItem.Click += new System.EventHandler(this.reservationReportToolStripMenuItem_Click);
            // 
            // transactionReportToolStripMenuItem
            // 
            this.transactionReportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("transactionReportToolStripMenuItem.Image")));
            this.transactionReportToolStripMenuItem.Name = "transactionReportToolStripMenuItem";
            this.transactionReportToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.transactionReportToolStripMenuItem.Text = "Transaction Report";
            // 
            // barItemReportToolStripMenuItem
            // 
            this.barItemReportToolStripMenuItem.Name = "barItemReportToolStripMenuItem";
            this.barItemReportToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.barItemReportToolStripMenuItem.Text = "Bar Item Report";
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transactionsToolStripMenuItem1});
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(70, 21);
            this.accountsToolStripMenuItem.Text = "Account";
            // 
            // transactionsToolStripMenuItem1
            // 
            this.transactionsToolStripMenuItem1.Name = "transactionsToolStripMenuItem1";
            this.transactionsToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.transactionsToolStripMenuItem1.Text = "Transactions";
            this.transactionsToolStripMenuItem1.Click += new System.EventHandler(this.transactionsToolStripMenuItem1_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemSetupToolStripMenuItem,
            this.roomSettingToolStripMenuItem,
            this.usersSettingToolStripMenuItem,
            this.cardMaintenanceToolStripMenuItem,
            this.hardwareSetupToolStripMenuItem,
            this.importsExportsToolStripMenuItem,
            this.restoreDataFromBackupToolStripMenuItem,
            this.taxFileMaintenanceToolStripMenuItem,
            this.defaultAccountSetupToolStripMenuItem,
            this.clearDataFiToolStripMenuItem,
            this.dataFileStatisticsToolStripMenuItem,
            this.archiveDataFilesToolStripMenuItem,
            this.recycleBinToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(98, 21);
            this.toolsToolStripMenuItem.Text = "Maintenance";
            // 
            // systemSetupToolStripMenuItem
            // 
            this.systemSetupToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("systemSetupToolStripMenuItem.Image")));
            this.systemSetupToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.systemSetupToolStripMenuItem.Name = "systemSetupToolStripMenuItem";
            this.systemSetupToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.systemSetupToolStripMenuItem.Text = "System Setup";
            this.systemSetupToolStripMenuItem.Click += new System.EventHandler(this.systemSetupToolStripMenuItem_Click);
            // 
            // roomSettingToolStripMenuItem
            // 
            this.roomSettingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("roomSettingToolStripMenuItem.Image")));
            this.roomSettingToolStripMenuItem.Name = "roomSettingToolStripMenuItem";
            this.roomSettingToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.roomSettingToolStripMenuItem.Text = "Room Setting";
            this.roomSettingToolStripMenuItem.Click += new System.EventHandler(this.roomSettingToolStripMenuItem_Click);
            // 
            // usersSettingToolStripMenuItem
            // 
            this.usersSettingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("usersSettingToolStripMenuItem.Image")));
            this.usersSettingToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.usersSettingToolStripMenuItem.Name = "usersSettingToolStripMenuItem";
            this.usersSettingToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.usersSettingToolStripMenuItem.Text = "Users Setting";
            this.usersSettingToolStripMenuItem.Click += new System.EventHandler(this.usersSettingToolStripMenuItem_Click);
            // 
            // cardMaintenanceToolStripMenuItem
            // 
            this.cardMaintenanceToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cardMaintenanceToolStripMenuItem.Image")));
            this.cardMaintenanceToolStripMenuItem.Name = "cardMaintenanceToolStripMenuItem";
            this.cardMaintenanceToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.cardMaintenanceToolStripMenuItem.Text = "Card Maintenance";
            this.cardMaintenanceToolStripMenuItem.Click += new System.EventHandler(this.cardMaintenanceToolStripMenuItem_Click);
            // 
            // hardwareSetupToolStripMenuItem
            // 
            this.hardwareSetupToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hardwareSetupToolStripMenuItem.Image")));
            this.hardwareSetupToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.hardwareSetupToolStripMenuItem.Name = "hardwareSetupToolStripMenuItem";
            this.hardwareSetupToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.hardwareSetupToolStripMenuItem.Text = "Hardware Setup";
            // 
            // importsExportsToolStripMenuItem
            // 
            this.importsExportsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importsExportsToolStripMenuItem.Image")));
            this.importsExportsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.importsExportsToolStripMenuItem.Name = "importsExportsToolStripMenuItem";
            this.importsExportsToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.importsExportsToolStripMenuItem.Text = "Imports / Exports";
            // 
            // restoreDataFromBackupToolStripMenuItem
            // 
            this.restoreDataFromBackupToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("restoreDataFromBackupToolStripMenuItem.Image")));
            this.restoreDataFromBackupToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.restoreDataFromBackupToolStripMenuItem.Name = "restoreDataFromBackupToolStripMenuItem";
            this.restoreDataFromBackupToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.restoreDataFromBackupToolStripMenuItem.Text = "Restore Data From Backup";
            // 
            // taxFileMaintenanceToolStripMenuItem
            // 
            this.taxFileMaintenanceToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("taxFileMaintenanceToolStripMenuItem.Image")));
            this.taxFileMaintenanceToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.taxFileMaintenanceToolStripMenuItem.Name = "taxFileMaintenanceToolStripMenuItem";
            this.taxFileMaintenanceToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.taxFileMaintenanceToolStripMenuItem.Text = "Tax File Maintenance";
            // 
            // defaultAccountSetupToolStripMenuItem
            // 
            this.defaultAccountSetupToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("defaultAccountSetupToolStripMenuItem.Image")));
            this.defaultAccountSetupToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.defaultAccountSetupToolStripMenuItem.Name = "defaultAccountSetupToolStripMenuItem";
            this.defaultAccountSetupToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.defaultAccountSetupToolStripMenuItem.Text = "Default Account Setup";
            // 
            // clearDataFiToolStripMenuItem
            // 
            this.clearDataFiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clearDataFiToolStripMenuItem.Image")));
            this.clearDataFiToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.clearDataFiToolStripMenuItem.Name = "clearDataFiToolStripMenuItem";
            this.clearDataFiToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.clearDataFiToolStripMenuItem.Text = "Clear Data Files";
            // 
            // dataFileStatisticsToolStripMenuItem
            // 
            this.dataFileStatisticsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dataFileStatisticsToolStripMenuItem.Image")));
            this.dataFileStatisticsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.dataFileStatisticsToolStripMenuItem.Name = "dataFileStatisticsToolStripMenuItem";
            this.dataFileStatisticsToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.dataFileStatisticsToolStripMenuItem.Text = "Data File Statistics";
            // 
            // archiveDataFilesToolStripMenuItem
            // 
            this.archiveDataFilesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("archiveDataFilesToolStripMenuItem.Image")));
            this.archiveDataFilesToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.archiveDataFilesToolStripMenuItem.Name = "archiveDataFilesToolStripMenuItem";
            this.archiveDataFilesToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.archiveDataFilesToolStripMenuItem.Text = "Archive Data Files";
            // 
            // recycleBinToolStripMenuItem
            // 
            this.recycleBinToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("recycleBinToolStripMenuItem.Image")));
            this.recycleBinToolStripMenuItem.Name = "recycleBinToolStripMenuItem";
            this.recycleBinToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.recycleBinToolStripMenuItem.Text = "Recycle Bin";
            this.recycleBinToolStripMenuItem.Click += new System.EventHandler(this.recycleBinToolStripMenuItem_Click);
            // 
            // eSMART_HMSDBDataSet
            // 
            this.eSMART_HMSDBDataSet.DataSetName = "ESMART_HMSDBDataSet";
            this.eSMART_HMSDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // roomBindingSource
            // 
            this.roomBindingSource.DataMember = "Room";
            this.roomBindingSource.DataSource = this.eSMART_HMSDBDataSet;
            // 
            // roomTableAdapter
            // 
            this.roomTableAdapter.ClearBeforeFill = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel2.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel2.Controls.Add(this.pictureBox2);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(1689, -2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(231, 41);
            this.flowLayoutPanel2.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(109, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Home
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1924, 717);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "E-SMART HMS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Home_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eSMART_HMSDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer menuTransition;
        private System.Windows.Forms.Timer sidebarTransition;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerMainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem swimmingPoolServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spaServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sportFacilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageReportsToolStripMenuItem;
        private ESMART_HMSDBDataSet eSMART_HMSDBDataSet;
        private System.Windows.Forms.BindingSource roomBindingSource;
        private ESMART_HMSDBDataSetTableAdapters.RoomTableAdapter roomTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem manageReservationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managebookingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gymToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem systemSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardwareSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importsExportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreDataFromBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taxFileMaintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultAccountSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearDataFiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataFileStatisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archiveDataFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cardMaintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookingReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservationReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barItemReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restaurantToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem laundryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recycleBinToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}