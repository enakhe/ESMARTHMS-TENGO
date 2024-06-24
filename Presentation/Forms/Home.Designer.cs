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
            this.btnHam = new System.Windows.Forms.PictureBox();
            this.menuTransition = new System.Windows.Forms.Timer(this.components);
            this.sidebarTransition = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerMainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllCoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomsFacilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomReservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservationListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomCheckoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).BeginInit();
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
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(47)))), ((int)(((byte)(172)))));
            this.sidebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.roomReservationToolStripMenuItem});
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
            this.customerMainToolStripMenuItem,
            this.viewAllCoToolStripMenuItem});
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(121, 24);
            this.customerToolStripMenuItem.Text = "Manage Guest";
            // 
            // customerMainToolStripMenuItem
            // 
            this.customerMainToolStripMenuItem.AutoSize = false;
            this.customerMainToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("customerMainToolStripMenuItem.Image")));
            this.customerMainToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.customerMainToolStripMenuItem.Name = "customerMainToolStripMenuItem";
            this.customerMainToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10, 1, 10, 1);
            this.customerMainToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.customerMainToolStripMenuItem.Text = "View all Customers";
            this.customerMainToolStripMenuItem.Click += new System.EventHandler(this.customerMainToolStripMenuItem_Click_1);
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
            this.roomsToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.roomsToolStripMenuItem.Text = "View all Rooms";
            this.roomsToolStripMenuItem.Click += new System.EventHandler(this.roomsToolStripMenuItem_Click);
            // 
            // roomsFacilitiesToolStripMenuItem
            // 
            this.roomsFacilitiesToolStripMenuItem.Name = "roomsFacilitiesToolStripMenuItem";
            this.roomsFacilitiesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.roomsFacilitiesToolStripMenuItem.Text = "Rooms Facilities";
            // 
            // roomReservationToolStripMenuItem
            // 
            this.roomReservationToolStripMenuItem.AutoSize = false;
            this.roomReservationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reservationListToolStripMenuItem,
            this.roomCheckoutToolStripMenuItem,
            this.roomStatusToolStripMenuItem});
            this.roomReservationToolStripMenuItem.Name = "roomReservationToolStripMenuItem";
            this.roomReservationToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.roomReservationToolStripMenuItem.Text = "Room Reservation";
            // 
            // reservationListToolStripMenuItem
            // 
            this.reservationListToolStripMenuItem.Name = "reservationListToolStripMenuItem";
            this.reservationListToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.reservationListToolStripMenuItem.Text = "Reservation List";
            this.reservationListToolStripMenuItem.Click += new System.EventHandler(this.reservationListToolStripMenuItem_Click);
            // 
            // roomCheckoutToolStripMenuItem
            // 
            this.roomCheckoutToolStripMenuItem.Name = "roomCheckoutToolStripMenuItem";
            this.roomCheckoutToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.roomCheckoutToolStripMenuItem.Text = "Room Checkout";
            // 
            // roomStatusToolStripMenuItem
            // 
            this.roomStatusToolStripMenuItem.Name = "roomStatusToolStripMenuItem";
            this.roomStatusToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.roomStatusToolStripMenuItem.Text = "Room Status";
            // 
            // Home
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerMainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllCoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomsFacilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomReservationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservationListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomCheckoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomStatusToolStripMenuItem;
    }
}