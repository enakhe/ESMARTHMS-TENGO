namespace ESMART_HMS.Presentation.Forms.RoleHome
{
    partial class FrontDeskHomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrontDeskHomeForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.guestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservationReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guestsToolStripMenuItem,
            this.roomsToolStripMenuItem1,
            this.reservationToolStripMenuItem,
            this.bookingToolStripMenuItem,
            this.manageReportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 10, 0, 10);
            this.menuStrip1.Size = new System.Drawing.Size(1924, 41);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // guestsToolStripMenuItem
            // 
            this.guestsToolStripMenuItem.Name = "guestsToolStripMenuItem";
            this.guestsToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.guestsToolStripMenuItem.Text = "Guests";
            this.guestsToolStripMenuItem.Click += new System.EventHandler(this.guestsToolStripMenuItem_Click);
            // 
            // roomsToolStripMenuItem1
            // 
            this.roomsToolStripMenuItem1.Name = "roomsToolStripMenuItem1";
            this.roomsToolStripMenuItem1.Size = new System.Drawing.Size(62, 21);
            this.roomsToolStripMenuItem1.Text = "Rooms";
            this.roomsToolStripMenuItem1.Click += new System.EventHandler(this.roomsToolStripMenuItem1_Click);
            // 
            // reservationToolStripMenuItem
            // 
            this.reservationToolStripMenuItem.Name = "reservationToolStripMenuItem";
            this.reservationToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.reservationToolStripMenuItem.Text = "Reservation";
            this.reservationToolStripMenuItem.Click += new System.EventHandler(this.reservationToolStripMenuItem_Click);
            // 
            // bookingToolStripMenuItem
            // 
            this.bookingToolStripMenuItem.Name = "bookingToolStripMenuItem";
            this.bookingToolStripMenuItem.Size = new System.Drawing.Size(70, 21);
            this.bookingToolStripMenuItem.Text = "Booking";
            this.bookingToolStripMenuItem.Click += new System.EventHandler(this.bookingToolStripMenuItem_Click);
            // 
            // manageReportsToolStripMenuItem
            // 
            this.manageReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roomReportToolStripMenuItem,
            this.bookingReportToolStripMenuItem,
            this.reservationReportToolStripMenuItem});
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
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 665);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1924, 52);
            this.panel2.TabIndex = 15;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel2.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel2.Controls.Add(this.pictureBox2);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(1590, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(322, 41);
            this.flowLayoutPanel2.TabIndex = 17;
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
            // FrontDeskHomeForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1924, 717);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrontDeskHomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "E-SMART HOTEL MANAGEMENT SOFTWARE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrontDeskHomeForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem manageReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookingReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservationReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reservationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookingToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}