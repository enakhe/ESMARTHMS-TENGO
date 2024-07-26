using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Forms.Rooms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly RoomController _roomController;
        public DashboardForm(RoomController roomController)
        {
            _roomController = roomController;
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadRoomData();
        }

        public void LoadRoomData()
        {
            int roomCount = _roomController.GetAllRooms().Count;
            txtRoomCount.Text = roomCount.ToString();
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
