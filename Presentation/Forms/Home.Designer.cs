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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuTransition = new System.Windows.Forms.Timer(this.components);
            this.sidebarTransition = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerMainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllCoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomsFacilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomBookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageStoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storeForToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foodIngredientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swimmingPoolServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laundryServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spaServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sportFacilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eSMART_HMSDBDataSet = new ESMART_HMS.ESMART_HMSDBDataSet();
            this.roomBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.roomTableAdapter = new ESMART_HMS.ESMART_HMSDBDataSetTableAdapters.RoomTableAdapter();
            this.manageReservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageBookingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addEditReservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookedReservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEditBookingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservationListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomCheckoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomReservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eSMART_HMSDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 75);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(51, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 99);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 618);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(47)))), ((int)(((byte)(172)))));
            this.sidebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.sidebar.Location = new System.Drawing.Point(0, 99);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(125, 618);
            this.sidebar.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.customerToolStripMenuItem,
            this.manageRoomToolStripMenuItem,
            this.roomReservationToolStripMenuItem,
            this.roomBookingToolStripMenuItem,
            this.manageStoreToolStripMenuItem,
            this.newOrderToolStripMenuItem,
            this.transactionsToolStripMenuItem,
            this.manageReportsToolStripMenuItem,
            this.accountsToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1924, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem1});
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.homeToolStripMenuItem.Text = "Dashboard";
            // 
            // homeToolStripMenuItem1
            // 
            this.homeToolStripMenuItem1.Name = "homeToolStripMenuItem1";
            this.homeToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.homeToolStripMenuItem1.Text = "Home";
            this.homeToolStripMenuItem1.Click += new System.EventHandler(this.homeToolStripMenuItem1_Click);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerMainToolStripMenuItem,
            this.viewAllCoToolStripMenuItem,
            this.toolStripSeparator1,
            this.manageReservationToolStripMenuItem,
            this.manageBookingsToolStripMenuItem});
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.customerToolStripMenuItem.Text = "Front Desk";
            // 
            // customerMainToolStripMenuItem
            // 
            this.customerMainToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.customerMainToolStripMenuItem.Name = "customerMainToolStripMenuItem";
            this.customerMainToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.customerMainToolStripMenuItem.Text = "Manage Guests";
            this.customerMainToolStripMenuItem.Click += new System.EventHandler(this.customerMainToolStripMenuItem_Click_1);
            // 
            // viewAllCoToolStripMenuItem
            // 
            this.viewAllCoToolStripMenuItem.Name = "viewAllCoToolStripMenuItem";
            this.viewAllCoToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.viewAllCoToolStripMenuItem.Text = "Manage Companies";
            // 
            // manageRoomToolStripMenuItem
            // 
            this.manageRoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roomsToolStripMenuItem,
            this.roomsFacilitiesToolStripMenuItem});
            this.manageRoomToolStripMenuItem.Name = "manageRoomToolStripMenuItem";
            this.manageRoomToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.manageRoomToolStripMenuItem.Text = "Manage Room";
            // 
            // roomsToolStripMenuItem
            // 
            this.roomsToolStripMenuItem.Name = "roomsToolStripMenuItem";
            this.roomsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.roomsToolStripMenuItem.Text = "View all Rooms";
            this.roomsToolStripMenuItem.Click += new System.EventHandler(this.roomsToolStripMenuItem_Click);
            // 
            // roomsFacilitiesToolStripMenuItem
            // 
            this.roomsFacilitiesToolStripMenuItem.Name = "roomsFacilitiesToolStripMenuItem";
            this.roomsFacilitiesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.roomsFacilitiesToolStripMenuItem.Text = "Rooms Facilities";
            // 
            // roomBookingToolStripMenuItem
            // 
            this.roomBookingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookingListToolStripMenuItem});
            this.roomBookingToolStripMenuItem.Name = "roomBookingToolStripMenuItem";
            this.roomBookingToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.roomBookingToolStripMenuItem.Text = "Manage Booking";
            // 
            // bookingListToolStripMenuItem
            // 
            this.bookingListToolStripMenuItem.Name = "bookingListToolStripMenuItem";
            this.bookingListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bookingListToolStripMenuItem.Text = "Booking List";
            this.bookingListToolStripMenuItem.Click += new System.EventHandler(this.bookingListToolStripMenuItem_Click);
            // 
            // manageStoreToolStripMenuItem
            // 
            this.manageStoreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.storeForToolStripMenuItem,
            this.foodIngredientToolStripMenuItem});
            this.manageStoreToolStripMenuItem.Name = "manageStoreToolStripMenuItem";
            this.manageStoreToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.manageStoreToolStripMenuItem.Text = " Manage Store";
            // 
            // storeForToolStripMenuItem
            // 
            this.storeForToolStripMenuItem.Name = "storeForToolStripMenuItem";
            this.storeForToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.storeForToolStripMenuItem.Text = "Store For Bars";
            this.storeForToolStripMenuItem.Click += new System.EventHandler(this.storeForToolStripMenuItem_Click);
            // 
            // foodIngredientToolStripMenuItem
            // 
            this.foodIngredientToolStripMenuItem.Name = "foodIngredientToolStripMenuItem";
            this.foodIngredientToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.foodIngredientToolStripMenuItem.Text = "Food Ingredient";
            // 
            // newOrderToolStripMenuItem
            // 
            this.newOrderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.swimmingPoolServiceToolStripMenuItem,
            this.laundryServiceToolStripMenuItem,
            this.spaServiceToolStripMenuItem,
            this.sportFacilitiesToolStripMenuItem});
            this.newOrderToolStripMenuItem.Name = "newOrderToolStripMenuItem";
            this.newOrderToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.newOrderToolStripMenuItem.Text = "New Order";
            // 
            // swimmingPoolServiceToolStripMenuItem
            // 
            this.swimmingPoolServiceToolStripMenuItem.Name = "swimmingPoolServiceToolStripMenuItem";
            this.swimmingPoolServiceToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.swimmingPoolServiceToolStripMenuItem.Text = "Swimming Pool Service";
            // 
            // laundryServiceToolStripMenuItem
            // 
            this.laundryServiceToolStripMenuItem.Name = "laundryServiceToolStripMenuItem";
            this.laundryServiceToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.laundryServiceToolStripMenuItem.Text = "Laundry Service";
            // 
            // spaServiceToolStripMenuItem
            // 
            this.spaServiceToolStripMenuItem.Name = "spaServiceToolStripMenuItem";
            this.spaServiceToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.spaServiceToolStripMenuItem.Text = "Spa Service";
            // 
            // sportFacilitiesToolStripMenuItem
            // 
            this.sportFacilitiesToolStripMenuItem.Name = "sportFacilitiesToolStripMenuItem";
            this.sportFacilitiesToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.sportFacilitiesToolStripMenuItem.Text = "Sport Facilities";
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transactionListToolStripMenuItem});
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.transactionsToolStripMenuItem.Text = "Manage Transactions";
            // 
            // transactionListToolStripMenuItem
            // 
            this.transactionListToolStripMenuItem.Name = "transactionListToolStripMenuItem";
            this.transactionListToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.transactionListToolStripMenuItem.Text = "Transaction List";
            this.transactionListToolStripMenuItem.Click += new System.EventHandler(this.transactionListToolStripMenuItem_Click);
            // 
            // manageReportsToolStripMenuItem
            // 
            this.manageReportsToolStripMenuItem.Name = "manageReportsToolStripMenuItem";
            this.manageReportsToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.manageReportsToolStripMenuItem.Text = "Manage Reports";
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem,
            this.rolesToolStripMenuItem});
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.accountsToolStripMenuItem.Text = "Manage Accounts";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.usersToolStripMenuItem.Text = "Users";
            // 
            // rolesToolStripMenuItem
            // 
            this.rolesToolStripMenuItem.Name = "rolesToolStripMenuItem";
            this.rolesToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.rolesToolStripMenuItem.Text = "Roles";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.toolsToolStripMenuItem.Text = "Settings ";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("optionToolStripMenuItem.Image")));
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionToolStripMenuItem.Text = "Options";
            this.optionToolStripMenuItem.Click += new System.EventHandler(this.optionToolStripMenuItem_Click);
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
            // manageReservationToolStripMenuItem
            // 
            this.manageReservationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEditReservationToolStripMenuItem,
            this.bookedReservationToolStripMenuItem});
            this.manageReservationToolStripMenuItem.Name = "manageReservationToolStripMenuItem";
            this.manageReservationToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            // 
            // manageBookingsToolStripMenuItem
            // 
            this.manageBookingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEditBookingsToolStripMenuItem});
            this.manageBookingsToolStripMenuItem.Name = "manageBookingsToolStripMenuItem";
            this.manageBookingsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.manageBookingsToolStripMenuItem.Text = "Manage Bookings";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // addEditReservationToolStripMenuItem
            // 
            this.addEditReservationToolStripMenuItem.Name = "addEditReservationToolStripMenuItem";
            this.addEditReservationToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.addEditReservationToolStripMenuItem.Text = "Add / Edit Reservation";
            this.addEditReservationToolStripMenuItem.Click += new System.EventHandler(this.addEditReservationToolStripMenuItem_Click);
            // 
            // bookedReservationToolStripMenuItem
            // 
            this.bookedReservationToolStripMenuItem.Name = "bookedReservationToolStripMenuItem";
            this.bookedReservationToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.bookedReservationToolStripMenuItem.Text = "Booked Reservation";
            // 
            // addEditBookingsToolStripMenuItem
            // 
            this.addEditBookingsToolStripMenuItem.Name = "addEditBookingsToolStripMenuItem";
            this.addEditBookingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addEditBookingsToolStripMenuItem.Text = "Add / Edit Bookings";
            // 
            // reservationListToolStripMenuItem
            // 
            this.reservationListToolStripMenuItem.Name = "reservationListToolStripMenuItem";
            this.reservationListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reservationListToolStripMenuItem.Text = "Reservation List";
            this.reservationListToolStripMenuItem.Click += new System.EventHandler(this.reservationListToolStripMenuItem_Click);
            // 
            // roomCheckoutToolStripMenuItem
            // 
            this.roomCheckoutToolStripMenuItem.Name = "roomCheckoutToolStripMenuItem";
            this.roomCheckoutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.roomCheckoutToolStripMenuItem.Text = "Booked Reservation";
            // 
            // roomStatusToolStripMenuItem
            // 
            this.roomStatusToolStripMenuItem.Name = "roomStatusToolStripMenuItem";
            this.roomStatusToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.roomStatusToolStripMenuItem.Text = "Room Status";
            // 
            // roomReservationToolStripMenuItem
            // 
            this.roomReservationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reservationListToolStripMenuItem,
            this.roomCheckoutToolStripMenuItem,
            this.roomStatusToolStripMenuItem});
            this.roomReservationToolStripMenuItem.Name = "roomReservationToolStripMenuItem";
            this.roomReservationToolStripMenuItem.Size = new System.Drawing.Size(133, 20);
            this.roomReservationToolStripMenuItem.Text = "Manange Reservation";
            // 
            // Home
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1924, 717);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "E-SMART HMS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Home_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eSMART_HMSDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer menuTransition;
        private System.Windows.Forms.Timer sidebarTransition;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerMainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllCoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomsFacilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomBookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookingListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageStoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem storeForToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foodIngredientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem swimmingPoolServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laundryServiceToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem manageBookingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEditReservationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookedReservationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEditBookingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomReservationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservationListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomCheckoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomStatusToolStripMenuItem;
    }
}