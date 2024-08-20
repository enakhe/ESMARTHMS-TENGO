using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Forms.FormClasses;
using ESMART_HMS.Presentation.Forms.Rooms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ESMART_HMS.Presentation.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly RoomController _roomController;
        private readonly GuestController _guestController;
        private DispatcherTimer dispatcherTimer;

        public DashboardForm(RoomController roomController, GuestController guestController)
        {
            _roomController = roomController;
            _guestController = guestController;
            InitializeComponent();
            InitializeFlowPanel();
            floyLayoutPopulate();
            InitializeFlowLayoutPanel();
            PopulateRooms();
            InitializeStatusIndicator();

            InitializeTimer();
        }

        private void InitializeTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(30);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            mainFlowLayoutPanel.Controls.Clear();
            PopulateRooms();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadRoomData();
            LoadGuestData();
            dispatcherTimer.Start();
        }

        public void InitializeFlowPanel()
        {
            this.Load += (sender, e) => CenterFlowLayoutPanel(flowLayoutPanel1, mainFlowLayoutPanel);
        }

        private void CenterFlowLayoutPanel(FlowLayoutPanel flowLayoutPanel, FlowLayoutPanel flowLayoutPanel2)
        {
            int totalWidth = flowLayoutPanel.Controls.Cast<Control>().Sum(c => c.Width);
            int totalHeight = flowLayoutPanel.Controls.Cast<Control>().Sum(c => c.Height);

            int paddingX = (flowLayoutPanel.ClientSize.Width - totalWidth) / 2;
            int paddingY = (flowLayoutPanel.ClientSize.Height - totalHeight) / 2;

            flowLayoutPanel.Padding = new Padding(paddingX, paddingY, paddingX, paddingY);

            int totalWidth2 = flowLayoutPanel2.Controls.Cast<Control>().Sum(c => c.Width);
            int totalHeight2 = flowLayoutPanel2.Controls.Cast<Control>().Sum(c => c.Height);

            int paddingX2 = (flowLayoutPanel2.ClientSize.Width - totalWidth) / 2;
            int paddingY2 = (flowLayoutPanel2.ClientSize.Height - totalHeight) / 2;

            flowLayoutPanel2.Padding = new Padding(paddingX, paddingY, paddingX, paddingY);
        }

        public void LoadRoomData()
        {
            int roomCount = _roomController.GetAllRooms().Count;
            txtRoomCount.Text = roomCount.ToString();
        }

        public void LoadGuestData()
        {
            int guestCount = _guestController.LoadGuests().Count;
            txtGuestCount.Text = guestCount.ToString();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            RoomGridViewForm roomGridView = serviceProvider.GetRequiredService<RoomGridViewForm>();
            roomGridView.Show();
        }

        public void floyLayoutPopulate()
        {
            this.mainFlowLayoutPanel = new FlowLayoutPanel();
            this.statusIndicatorPanel = new Panel();
            this.SuspendLayout();

            this.mainFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mainFlowLayoutPanel.Location = new System.Drawing.Point(12, 241);
            this.mainFlowLayoutPanel.Name = "flowLayoutPanel";
            this.mainFlowLayoutPanel.Size = new System.Drawing.Size(1600, 828);
            this.mainFlowLayoutPanel.TabIndex = 0;

            this.statusIndicatorPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusIndicatorPanel.Location = new System.Drawing.Point(12, 174);
            this.statusIndicatorPanel.Name = "statusIndicatorPanel";
            this.statusIndicatorPanel.Size = new System.Drawing.Size(800, 50);
            this.statusIndicatorPanel.TabIndex = 1;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 828);
            this.Controls.Add(this.mainFlowLayoutPanel);
            this.Controls.Add(this.statusIndicatorPanel);
            this.Name = "Room Grid View";
            this.Text = "Room Grid View";
            this.ResumeLayout(false);
        }

        private void InitializeFlowLayoutPanel()
        {
            mainFlowLayoutPanel.AutoScroll = true;
            mainFlowLayoutPanel.WrapContents = true;
        }

        private void PopulateRooms()
        {
            mainFlowLayoutPanel.Controls.Clear();

            List<Building> buildings = _roomController.GetAllBuildings();
            List<Floor> floors = _roomController.GetAllFloors(); 

            foreach (var buiding in buildings)
            {
                foreach (var floor in buiding.Floors)
                {
                    Panel panel = new Panel
                    {
                        Dock = DockStyle.Top,
                        Padding = new Padding(10),
                    };

                    FlowLayoutPanel floorFlowLayoutPanel = new FlowLayoutPanel
                    {
                        AutoScroll = true,
                        WrapContents = false,
                        Size = new Size(1500, 200),
                        Padding = new Padding(10),
                        Margin = new Padding(10),
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    Label floorLabel = new Label
                    {
                        Text = $"Building: {buiding.BuildingName} ({buiding.BuildingNo}) \n Floor: {floor.FloorNo}",
                        AutoSize = true,
                        Dock = DockStyle.Top,
                        Font = new Font("Segoe UI", 12, FontStyle.Bold),
                        ForeColor = Color.Black,
                        Margin = new Padding(0, 0, 0, 10)
                    };

                    panel.Controls.Add(floorLabel);
                    floorFlowLayoutPanel.Controls.Add(panel);

                    var rooms = floor.Rooms;
                    foreach (var room in rooms)
                    {
                        var roomPanel = CreateRoomPanel(room.RoomType.Title, room.Rate.ToString(), room.RoomNo, room.Status);
                        floorFlowLayoutPanel.Controls.Add(roomPanel);
                    }

                    mainFlowLayoutPanel.Controls.Add(floorFlowLayoutPanel);
                } 
            }
        }

        private Panel CreateRoomPanel(string roomType, string roomPrice, string roomName, string roomStatus)
        {
            var panel = new RoundedPanel
            {
                Size = new Size(100, 80),
                BackColor = GetColorByStatus(roomStatus),
                BorderStyle = BorderStyle.None,
                Margin = new Padding(9),
                Dock = DockStyle.Bottom,
                BorderThickness = 0,
                BorderColor = Color.White
            };

            var roomNameLabel = new Label
            {
                Text = roomName,
                AutoSize = true,
                Location = new Point(10, 10),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10)
            };

            var roomTypeLabel = new Label
            {
                Text = roomType,
                AutoSize = true,
                Location = new Point(10, 30),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10)
            };

            var roomPriceLabel = new Label
            {
                Text = FormHelper.FormatNumberWithCommas(decimal.Parse(roomPrice)),
                AutoSize = true,
                Location = new Point(10, 50),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10)
            };

            panel.Controls.Add(roomNameLabel);
            panel.Controls.Add(roomTypeLabel);
            panel.Controls.Add(roomPriceLabel);
            return panel;
        }


        private Color GetColorByStatus(string status)
        {
            switch (status)
            {
                case "Vacant":
                    return Color.Green;
                case "CheckedIn":
                    return Color.Blue;
                case "Reserved":
                    return Color.Yellow;
                default:
                    return Color.Red;
            }
        }

        private void InitializeStatusIndicator()
        {
            var statusColors = new[]
            {
            new { Status = "Vacant", Color = Color.Green },
            new { Status = "Booked", Color = Color.Blue },
            new { Status = "Reserved", Color = Color.Yellow },
            new { Status = "Maintenance", Color = Color.Red }
            };

            int x = 10;
            foreach (var statusColor in statusColors)
            {
                var colorBox = new Panel
                {
                    Size = new Size(20, 20),
                    BackColor = statusColor.Color,
                    Location = new Point(x, 15)
                };

                var statusLabel = new Label
                {
                    Text = statusColor.Status,
                    AutoSize = true,
                    Location = new Point(x + 25, 15),
                    Font = new Font("Segoe UI", 10)
                };

                statusIndicatorPanel.Controls.Add(colorBox);
                statusIndicatorPanel.Controls.Add(statusLabel);

                x += 100;
            }
        }
    }
}
