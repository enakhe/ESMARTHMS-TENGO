using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Forms.FormClasses;
using ESMART_HMS.Presentation.Forms.Rooms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly RoomController _roomController;
        private readonly GuestController _guestController;
        public DashboardForm(RoomController roomController, GuestController guestController)
        {
            _roomController = roomController;
            _guestController = guestController;
            InitializeComponent();
            InitializeFlowPanel();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadRoomData();
            LoadGuestData();
        }

        public void InitializeFlowPanel()
        {
            this.Load += (sender, e) => CenterFlowLayoutPanel(flowLayoutPanel1);
        }

        private void CenterFlowLayoutPanel(FlowLayoutPanel flowLayoutPanel)
        {
            // Calculate the total width and height of the FlowLayoutPanel
            int totalWidth = flowLayoutPanel.Controls.Cast<Control>().Sum(c => c.Width);
            int totalHeight = flowLayoutPanel.Controls.Cast<Control>().Sum(c => c.Height);

            // Calculate the padding needed to center the FlowLayoutPanel
            int paddingX = (flowLayoutPanel.ClientSize.Width - totalWidth) / 2;
            int paddingY = (flowLayoutPanel.ClientSize.Height - totalHeight) / 2;

            // Set the padding
            flowLayoutPanel.Padding = new Padding(paddingX, paddingY, paddingX, paddingY);
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
    }
}
