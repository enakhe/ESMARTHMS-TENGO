using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Forms.FormClasses;
using System.Drawing;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Rooms
{
    public partial class RoomGridViewForm : Form
    {
        private readonly RoomController _roomController;
        public RoomGridViewForm(RoomController roomController)
        {
            _roomController = roomController;
            InitializeComponent();
            floyLayoutPopulate();
            InitializeFlowLayoutPanel();
            PopulateRooms();
            InitializeStatusIndicator();
        }

        public void floyLayoutPopulate()
        {
            this.flowLayoutPanel = new FlowLayoutPanel();
            this.statusIndicatorPanel = new Panel();
            this.SuspendLayout();

            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(1600, 828);
            this.flowLayoutPanel.TabIndex = 0;

            this.statusIndicatorPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusIndicatorPanel.Location = new System.Drawing.Point(0, 400);
            this.statusIndicatorPanel.Name = "statusIndicatorPanel";
            this.statusIndicatorPanel.Size = new System.Drawing.Size(800, 50);
            this.statusIndicatorPanel.TabIndex = 1;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 828);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.statusIndicatorPanel);
            this.Name = "Room Grid View";
            this.Text = "Room Grid View";
            this.ResumeLayout(false);
        }

        private void InitializeFlowLayoutPanel()
        {
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.WrapContents = true;
        }

        private void PopulateRooms()
        {
            // Example list of rooms
            var rooms = _roomController.GetAllRooms();

            foreach (var room in rooms)
            {
                var panel = CreateRoomPanel(room.RoomType, room.Rate, room.RoomNo, room.Status);
                flowLayoutPanel.Controls.Add(panel);
            }
        }

        private Panel CreateRoomPanel(string roomType, string roomPrice, string roomName, string roomStatus)
        {
            var panel = new RoundedPanel
            {
                Size = new Size(300, 150),
                BackColor = GetColorByStatus(roomStatus),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(15),
                BorderThickness = 0,
                BorderColor = Color.White
            };

            var roomNameLabel = new Label
            {
                Text = "Room " + roomName,
                AutoSize = true,
                Location = new Point(10, 10),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 15)
            };

            var roomTypeLabel = new Label
            {
                Text = "Type: " + roomType,
                AutoSize = true,
                Location = new Point(10, 50),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 15)
            };

            var roomPriceLabel = new Label
            {
                Text = "Price: " + FormHelper.FormatNumberWithCommas(decimal.Parse(roomPrice)),
                AutoSize = true,
                Location = new Point(10, 90),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 15)
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
