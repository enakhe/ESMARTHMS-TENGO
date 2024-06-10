namespace ESMART_HMS.Forms
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
            this.btnHam = new System.Windows.Forms.PictureBox();
            this.menuTransition = new System.Windows.Forms.Timer(this.components);
            this.sidebarTransition = new System.Windows.Forms.Timer(this.components);
            this.menuContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.pnManageGuest = new System.Windows.Forms.Panel();
            this.manageGuest = new System.Windows.Forms.Button();
            this.pnGuest = new System.Windows.Forms.Panel();
            this.btnGuests = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCompanies = new System.Windows.Forms.Button();
            this.pnDashboard = new System.Windows.Forms.Panel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pnRoomBooking = new System.Windows.Forms.Panel();
            this.btnRoomBooking = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCustonerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllCoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomsFacilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomBookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomCheckoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).BeginInit();
            this.menuContainer.SuspendLayout();
            this.pnManageGuest.SuspendLayout();
            this.pnGuest.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnDashboard.SuspendLayout();
            this.pnRoomBooking.SuspendLayout();
            this.sidebar.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnHam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1117, 48);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(51, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 2;
            // 
            // btnHam
            // 
            this.btnHam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHam.Image = ((System.Drawing.Image)(resources.GetObject("btnHam.Image")));
            this.btnHam.Location = new System.Drawing.Point(7, 8);
            this.btnHam.Name = "btnHam";
            this.btnHam.Size = new System.Drawing.Size(44, 32);
            this.btnHam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnHam.TabIndex = 1;
            this.btnHam.TabStop = false;
            this.btnHam.Click += new System.EventHandler(this.btnHam_Click);
            // 
            // menuTransition
            // 
            this.menuTransition.Interval = 10;
            this.menuTransition.Tick += new System.EventHandler(this.menuTransition_Tick);
            // 
            // sidebarTransition
            // 
            this.sidebarTransition.Interval = 10;
            this.sidebarTransition.Tick += new System.EventHandler(this.sidebarTransition_Tick);
            // 
            // menuContainer
            // 
            this.menuContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.menuContainer.Controls.Add(this.pnManageGuest);
            this.menuContainer.Controls.Add(this.pnGuest);
            this.menuContainer.Controls.Add(this.panel2);
            this.menuContainer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuContainer.Location = new System.Drawing.Point(3, 69);
            this.menuContainer.Name = "menuContainer";
            this.menuContainer.Size = new System.Drawing.Size(293, 60);
            this.menuContainer.TabIndex = 3;
            // 
            // pnManageGuest
            // 
            this.pnManageGuest.Controls.Add(this.manageGuest);
            this.pnManageGuest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnManageGuest.Location = new System.Drawing.Point(0, 0);
            this.pnManageGuest.Margin = new System.Windows.Forms.Padding(0);
            this.pnManageGuest.Name = "pnManageGuest";
            this.pnManageGuest.Size = new System.Drawing.Size(290, 60);
            this.pnManageGuest.TabIndex = 2;
            // 
            // manageGuest
            // 
            this.manageGuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.manageGuest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.manageGuest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.manageGuest.FlatAppearance.BorderSize = 0;
            this.manageGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manageGuest.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageGuest.ForeColor = System.Drawing.Color.White;
            this.manageGuest.Image = ((System.Drawing.Image)(resources.GetObject("manageGuest.Image")));
            this.manageGuest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.manageGuest.Location = new System.Drawing.Point(0, 0);
            this.manageGuest.Margin = new System.Windows.Forms.Padding(0);
            this.manageGuest.Name = "manageGuest";
            this.manageGuest.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.manageGuest.Size = new System.Drawing.Size(290, 60);
            this.manageGuest.TabIndex = 3;
            this.manageGuest.Text = "           Manage Guests";
            this.manageGuest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.manageGuest.UseVisualStyleBackColor = false;
            this.manageGuest.Click += new System.EventHandler(this.manageGuest_Click);
            // 
            // pnGuest
            // 
            this.pnGuest.Controls.Add(this.btnGuests);
            this.pnGuest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnGuest.Location = new System.Drawing.Point(0, 60);
            this.pnGuest.Margin = new System.Windows.Forms.Padding(0);
            this.pnGuest.Name = "pnGuest";
            this.pnGuest.Size = new System.Drawing.Size(290, 60);
            this.pnGuest.TabIndex = 2;
            // 
            // btnGuests
            // 
            this.btnGuests.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.btnGuests.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuests.FlatAppearance.BorderSize = 0;
            this.btnGuests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuests.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuests.ForeColor = System.Drawing.Color.White;
            this.btnGuests.Image = ((System.Drawing.Image)(resources.GetObject("btnGuests.Image")));
            this.btnGuests.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuests.Location = new System.Drawing.Point(-12, 0);
            this.btnGuests.Name = "btnGuests";
            this.btnGuests.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnGuests.Size = new System.Drawing.Size(296, 60);
            this.btnGuests.TabIndex = 7;
            this.btnGuests.Text = "          Guests";
            this.btnGuests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuests.UseVisualStyleBackColor = false;
            this.btnGuests.Click += new System.EventHandler(this.btnGuests_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCompanies);
            this.panel2.Location = new System.Drawing.Point(3, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(290, 60);
            this.panel2.TabIndex = 7;
            // 
            // btnCompanies
            // 
            this.btnCompanies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.btnCompanies.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompanies.FlatAppearance.BorderSize = 0;
            this.btnCompanies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompanies.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompanies.ForeColor = System.Drawing.Color.White;
            this.btnCompanies.Image = ((System.Drawing.Image)(resources.GetObject("btnCompanies.Image")));
            this.btnCompanies.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompanies.Location = new System.Drawing.Point(-12, 0);
            this.btnCompanies.Name = "btnCompanies";
            this.btnCompanies.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnCompanies.Size = new System.Drawing.Size(290, 60);
            this.btnCompanies.TabIndex = 8;
            this.btnCompanies.Text = "         Companies";
            this.btnCompanies.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompanies.UseVisualStyleBackColor = false;
            this.btnCompanies.Click += new System.EventHandler(this.btnCompanies_Click);
            // 
            // pnDashboard
            // 
            this.pnDashboard.Controls.Add(this.btnDashboard);
            this.pnDashboard.Location = new System.Drawing.Point(3, 3);
            this.pnDashboard.Name = "pnDashboard";
            this.pnDashboard.Size = new System.Drawing.Size(290, 60);
            this.pnDashboard.TabIndex = 2;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.btnDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 0);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(290, 60);
            this.btnDashboard.TabIndex = 3;
            this.btnDashboard.Text = "           Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // pnRoomBooking
            // 
            this.pnRoomBooking.Controls.Add(this.btnRoomBooking);
            this.pnRoomBooking.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnRoomBooking.Location = new System.Drawing.Point(3, 135);
            this.pnRoomBooking.Name = "pnRoomBooking";
            this.pnRoomBooking.Size = new System.Drawing.Size(293, 60);
            this.pnRoomBooking.TabIndex = 2;
            // 
            // btnRoomBooking
            // 
            this.btnRoomBooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.btnRoomBooking.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRoomBooking.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoomBooking.FlatAppearance.BorderSize = 0;
            this.btnRoomBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoomBooking.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoomBooking.ForeColor = System.Drawing.Color.White;
            this.btnRoomBooking.Image = ((System.Drawing.Image)(resources.GetObject("btnRoomBooking.Image")));
            this.btnRoomBooking.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoomBooking.Location = new System.Drawing.Point(0, 0);
            this.btnRoomBooking.Name = "btnRoomBooking";
            this.btnRoomBooking.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnRoomBooking.Size = new System.Drawing.Size(293, 60);
            this.btnRoomBooking.TabIndex = 3;
            this.btnRoomBooking.Text = "           Room Booking";
            this.btnRoomBooking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoomBooking.UseVisualStyleBackColor = false;
            this.btnRoomBooking.Click += new System.EventHandler(this.btnRoomBooking_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 78);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 635);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.sidebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sidebar.Controls.Add(this.pnDashboard);
            this.sidebar.Controls.Add(this.menuContainer);
            this.sidebar.Controls.Add(this.pnRoomBooking);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.sidebar.Location = new System.Drawing.Point(0, 78);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(51, 635);
            this.sidebar.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerToolStripMenuItem,
            this.manageRoomToolStripMenuItem,
            this.roomBookingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1117, 30);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.AutoSize = false;
            this.customerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCustonerToolStripMenuItem,
            this.viewAllCoToolStripMenuItem});
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(121, 24);
            this.customerToolStripMenuItem.Text = "Manage Guest";
            this.customerToolStripMenuItem.Click += new System.EventHandler(this.customerToolStripMenuItem_Click);
            // 
            // addCustonerToolStripMenuItem
            // 
            this.addCustonerToolStripMenuItem.AutoSize = false;
            this.addCustonerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addCustonerToolStripMenuItem.Image")));
            this.addCustonerToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addCustonerToolStripMenuItem.Name = "addCustonerToolStripMenuItem";
            this.addCustonerToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10, 1, 10, 1);
            this.addCustonerToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.addCustonerToolStripMenuItem.Text = "View all Customers";
            this.addCustonerToolStripMenuItem.Click += new System.EventHandler(this.addCustonerToolStripMenuItem_Click);
            // 
            // viewAllCoToolStripMenuItem
            // 
            this.viewAllCoToolStripMenuItem.Name = "viewAllCoToolStripMenuItem";
            this.viewAllCoToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.viewAllCoToolStripMenuItem.Text = "View all Companies";
            // 
            // manageRoomToolStripMenuItem
            // 
            this.manageRoomToolStripMenuItem.AutoSize = false;
            this.manageRoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roomsToolStripMenuItem,
            this.roomsFacilitiesToolStripMenuItem});
            this.manageRoomToolStripMenuItem.Name = "manageRoomToolStripMenuItem";
            this.manageRoomToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.manageRoomToolStripMenuItem.Text = "Manage Room";
            // 
            // roomsToolStripMenuItem
            // 
            this.roomsToolStripMenuItem.Name = "roomsToolStripMenuItem";
            this.roomsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10, 1, 10, 1);
            this.roomsToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.roomsToolStripMenuItem.Text = "View all Rooms";
            this.roomsToolStripMenuItem.Click += new System.EventHandler(this.roomsToolStripMenuItem_Click);
            // 
            // roomsFacilitiesToolStripMenuItem
            // 
            this.roomsFacilitiesToolStripMenuItem.Name = "roomsFacilitiesToolStripMenuItem";
            this.roomsFacilitiesToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.roomsFacilitiesToolStripMenuItem.Text = "Rooms Facilities";
            // 
            // roomBookingToolStripMenuItem
            // 
            this.roomBookingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookingListToolStripMenuItem,
            this.roomCheckoutToolStripMenuItem,
            this.roomStatusToolStripMenuItem});
            this.roomBookingToolStripMenuItem.Name = "roomBookingToolStripMenuItem";
            this.roomBookingToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.roomBookingToolStripMenuItem.Text = "Room Booking";
            // 
            // bookingListToolStripMenuItem
            // 
            this.bookingListToolStripMenuItem.Name = "bookingListToolStripMenuItem";
            this.bookingListToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.bookingListToolStripMenuItem.Text = "Booking List";
            // 
            // roomCheckoutToolStripMenuItem
            // 
            this.roomCheckoutToolStripMenuItem.Name = "roomCheckoutToolStripMenuItem";
            this.roomCheckoutToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.roomCheckoutToolStripMenuItem.Text = "Room Checkout";
            // 
            // roomStatusToolStripMenuItem
            // 
            this.roomStatusToolStripMenuItem.Name = "roomStatusToolStripMenuItem";
            this.roomStatusToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.roomStatusToolStripMenuItem.Text = "Room Status";
            // 
            // Home
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1117, 713);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).EndInit();
            this.menuContainer.ResumeLayout(false);
            this.pnManageGuest.ResumeLayout(false);
            this.pnGuest.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnDashboard.ResumeLayout(false);
            this.pnRoomBooking.ResumeLayout(false);
            this.sidebar.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnHam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer menuTransition;
        private System.Windows.Forms.Timer sidebarTransition;
        private System.Windows.Forms.FlowLayoutPanel menuContainer;
        private System.Windows.Forms.Panel pnGuest;
        private System.Windows.Forms.Panel pnManageGuest;
        private System.Windows.Forms.Button manageGuest;
        private System.Windows.Forms.Panel pnDashboard;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel pnRoomBooking;
        private System.Windows.Forms.Button btnRoomBooking;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Button btnGuests;
        private System.Windows.Forms.Button btnCompanies;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCustonerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllCoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomsFacilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomBookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookingListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomCheckoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomStatusToolStripMenuItem;
    }
}