using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Forms.Booking;
using ESMART_HMS.Presentation.Forms.FrontDesk.Room;
using ESMART_HMS.Presentation.Forms.FrontDesk.Room.Area;
using ESMART_HMS.Presentation.Forms.FrontDesk.Room.Building;
using ESMART_HMS.Presentation.Forms.FrontDesk.Room.Floor;
using ESMART_HMS.Presentation.Forms.FrontDesk.RoomType;
using ESMART_HMS.Presentation.Forms.Rooms;
using ESMART_HMS.Presentation.Forms.RoomTypes;
using ESMART_HMS.Presentation.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Maintenance.RoomSetting
{
    public partial class RoomSettingForm : Form
    {
        private readonly RoomController _roomController;
        private readonly RoomTypeController _roomTypeController;
        public RoomSettingForm(RoomController roomController, RoomTypeController roomTypeController)
        {
            _roomController = roomController;
            _roomTypeController = roomTypeController;
            InitializeComponent();
            tabControl1.Appearance = TabAppearance.Normal;
            InitializeRoomTab(room);
            InitializeRoomTypeTab(roomTypeTab);
            InitializeAreaTab(area);
            InitializeFloorTab(floor);
            InitializeBuildingTab(buildingtab);
        }

        private void RoomSettingForm_Load(object sender, EventArgs e)
        {
           

        }

        private void InitializeRoomTab(TabPage tabPage)
        {
            if (tabPage != null)
            {
                if (tabPage.Text == "Room")
                {
                    List<RoomViewModel> allRooms = _roomController.GetAllRooms();
                    if (allRooms != null)
                    {
                        foreach (var room in allRooms)
                        {
                            FormHelper.TryConvertStringToDecimal(room.Rate.ToString(), out decimal rate);
                            room.Rate = FormHelper.FormatNumberWithCommas(rate);
                        }
                        dgvRooms.DataSource = allRooms;
                        dgvRooms.CellFormatting += DataGridViewRooms_CellFormatting;
                    }
                }
            }
        }

        private void InitializeRoomTypeTab(TabPage tabPage)
        {
            if (tabPage != null)
            {
                if (tabPage.Text == "Room Type")
                {
                    List<RoomTypeViewModel> allRoomType = _roomTypeController.GetAllRoomType();
                    if (allRoomType != null)
                    {
                        dgvRoomType.DataSource = allRoomType;
                    }
                }
            }

        }

        private void InitializeAreaTab(TabPage tabPage)
        {
            if (tabPage != null)
            {
                if (tabPage.Text == "Area")
                {
                    List<Area> allArea = _roomController.GetAllAreas();
                    if (allArea != null)
                    {
                        dgvArea.DataSource = allArea;
                    }
                }
            }
        }

        private void InitializeFloorTab(TabPage tabPage)
        {
            if (tabPage != null)
            {
                if (tabPage.Text == "Floor")
                {
                    List<Floor> allFloor = _roomController.GetAllFloors();
                    if (allFloor != null)
                    {
                        dgvFloor.DataSource = allFloor;
                    }
                }
            }
        }

        private void InitializeBuildingTab(TabPage tabPage)
        {
            if (tabPage != null)
            {
                if (tabPage.Text == "Building")
                {
                    List<Building> allBuildings = _roomController.GetAllBuildings();
                    if (allBuildings != null)
                    {
                        dgvBuilding.DataSource = allBuildings;
                    }
                }
            }
        }

        private void DataGridViewRooms_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRooms.Columns[e.ColumnIndex].Name == "statusDataGridViewTextBoxColumn")
            {
                var cell = dgvRooms.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null && cell.Value.ToString() == "Vacant")
                {
                    cell.Style.BackColor = System.Drawing.Color.Green;
                    cell.Style.ForeColor = System.Drawing.Color.White;
                }
                else if (cell.Value != null && cell.Value.ToString() == "Reserved")
                {
                    cell.Style.BackColor = System.Drawing.Color.Yellow;
                    cell.Style.ForeColor = System.Drawing.Color.Black;
                }
                else if (cell.Value != null && cell.Value.ToString() == "CheckedIn")
                {
                    cell.Style.BackColor = System.Drawing.Color.Blue;
                    cell.Style.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    cell.Style.BackColor = System.Drawing.Color.Red;
                    cell.Style.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            AddRoomForm addRoomForm = serviceProvider.GetRequiredService<AddRoomForm>();
            if (addRoomForm.ShowDialog() == DialogResult.OK)
            {
                RoomForm roomForm = serviceProvider.GetRequiredService<RoomForm>();
                InitializeRoomTab(room);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRooms.SelectedRows.Count > 0)
                {
                    var row = dgvRooms.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();

                    using (EditRoomForm editRoomForm = new EditRoomForm(_roomController, _roomTypeController, id))
                    {
                        if (editRoomForm.ShowDialog() == DialogResult.OK)
                        {
                            InitializeRoomTab(room);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a room to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void btnIssueCard_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRooms.SelectedRows.Count > 0)
                {
                    var row = dgvRooms.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();

                    using (IsssueRoomSettingCardForm issueCardForm = new IsssueRoomSettingCardForm(id, _roomController))
                    {
                        if (issueCardForm.ShowDialog() == DialogResult.OK)
                        {

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a room to issue card.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            TabPage tabPage = tabControl.TabPages[e.Index];

            Rectangle tabRect = tabControl.GetTabRect(e.Index);
            tabRect.Inflate(-2, -2);

            Color backColor;

            if (tabPage.Text == "Room")
            {
                backColor = ColorTranslator.FromHtml("#98b4d0");
            }
            else if (tabPage.Text == "Room Type")
            {
                backColor = ColorTranslator.FromHtml("#EF5A6F");
            }
            else if (tabPage.Text == "Building")
            {
                backColor = ColorTranslator.FromHtml("#80AF81");
            }
            else if (tabPage.Text == "Floor")
            {
                backColor = ColorTranslator.FromHtml("");
            }
            else if (tabPage.Text == "Area")
            {
                backColor = ColorTranslator.FromHtml("#98b4d0");
            }
            else
            {
                backColor = e.State == DrawItemState.Selected ? Color.LightBlue : Color.LightGray;
            }

            using (Brush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, tabRect);
            }

            Font font = new Font("Segoe UI", 13, FontStyle.Bold);

            TextRenderer.DrawText(e.Graphics, tabPage.Text, font, tabRect, tabPage.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void btnAddArea_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            AddAreaForm addAreaForm = serviceProvider.GetRequiredService<AddAreaForm>();
            if (addAreaForm.ShowDialog() == DialogResult.OK)
            {
                InitializeAreaTab(area);
            }
        }

        private void btnAddRoomType_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            AddRoomTypeForm addRoomType = serviceProvider.GetRequiredService<AddRoomTypeForm>();
            if (addRoomType.ShowDialog() == DialogResult.OK)
            {
                InitializeRoomTypeTab(roomTypeTab);
            }
        }

        private void btnEditArea_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvArea.SelectedRows.Count > 0)
                {
                    var row = dgvArea.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn2"].Value.ToString();

                    using (EditAreaForm editArea = new EditAreaForm(_roomController, id))
                    {
                        if (editArea.ShowDialog() == DialogResult.OK)
                        {
                            InitializeAreaTab(area);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select an are to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvArea.SelectedRows.Count > 0)
                {
                    var result = MessageBox.Show("Are you sure you want to add the selected areas to the recycle?\nIts record including all entries tagged to such area will be added to the recycle bin as well.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvArea.SelectedRows)
                        {
                            string id = row.Cells["idDataGridViewTextBoxColumn2"].Value.ToString();
                            _roomController.DeleteArea(id);
                        }
                        InitializeAreaTab(area);
                        MessageBox.Show("Successfully added area information to recycle", "Success", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select an area to recycle.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void btnEdiRoomType_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRoomType.SelectedRows.Count > 0)
                {
                    var row = dgvRoomType.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn1"].Value.ToString();

                    using (EditRoomTypeForm editRoomType = new EditRoomTypeForm(_roomTypeController, id))
                    {
                        if (editRoomType.ShowDialog() == DialogResult.OK)
                        {
                            InitializeRoomTypeTab(roomTypeTab);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select an are to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void btnDeleteRoomType_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRoomType.SelectedRows.Count > 0)
                {
                    var result = MessageBox.Show("Are you sure you want to add the selected room type to the recycle?\nIts record including all entries tagged to such room type will be added to the recycle bin as well.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvRoomType.SelectedRows)
                        {
                            string id = row.Cells["idDataGridViewTextBoxColumn1"].Value.ToString();
                            _roomTypeController.DeleteRoomType(id);
                        }
                        InitializeAreaTab(area);
                        MessageBox.Show("Successfully added room type information to recycle", "Success", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a room type to recycle.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void addFloorBtn_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            AddFloorForm addFloorForm = serviceProvider.GetRequiredService<AddFloorForm>();
            if (addFloorForm.ShowDialog() == DialogResult.OK)
            {
                InitializeFloorTab(floor);
            }
        }

        private void btnEditFloor_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFloor.SelectedRows.Count > 0)
                {
                    var row = dgvFloor.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn3"].Value.ToString();

                    using (EditFloorForm editFloorForm = new EditFloorForm(_roomController, id))
                    {
                        if (editFloorForm.ShowDialog() == DialogResult.OK)
                        {
                            InitializeFloorTab(floor);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a floor to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFloor.SelectedRows.Count > 0)
                {
                    var result = MessageBox.Show("Are you sure you want to add the selected floor to the recycle?\nIts record including all entries tagged to such floor will be added to the recycle bin as well.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvFloor.SelectedRows)
                        {
                            string id = row.Cells["idDataGridViewTextBoxColumn3"].Value.ToString();
                            _roomController.DeleteFloor(id);
                        }
                        InitializeFloorTab(floor);
                        MessageBox.Show("Successfully added floor information to recycle", "Success", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a floor to recycle.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void addbuildingBtn_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            AddBuildingForm addBuildingForm = serviceProvider.GetRequiredService<AddBuildingForm>();
            if (addBuildingForm.ShowDialog() == DialogResult.OK)
            {
                InitializeBuildingTab(buildingtab);
            }
        }

        private void editBuildingBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBuilding.SelectedRows.Count > 0)
                {
                    var row = dgvBuilding.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn4"].Value.ToString();

                    using (EditBuildingForm editBuildingForm = new EditBuildingForm(_roomController, id))
                    {
                        if (editBuildingForm.ShowDialog() == DialogResult.OK)
                        {
                            InitializeBuildingTab(buildingtab);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a floor to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void deleteBuildingBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBuilding.SelectedRows.Count > 0)
                {
                    var result = MessageBox.Show("Are you sure you want to add the selected building to the recycle?\nIts record including all entries tagged to such building will be added to the recycle bin as well.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvBuilding.SelectedRows)
                        {
                            string id = row.Cells["idDataGridViewTextBoxColumn4"].Value.ToString();
                            _roomController.DeleteBuilding(id);
                        }
                        InitializeBuildingTab(buildingtab);
                        MessageBox.Show("Successfully added building information to recycle", "Success", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a builing to recycle.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }
    }
}
