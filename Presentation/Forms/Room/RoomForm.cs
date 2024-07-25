using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Middleware;
using ESMART_HMS.Presentation.Sessions;
using ESMART_HMS.Presentation.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Rooms
{
    public partial class RoomForm : Form
    {
        private readonly RoomController _roomController;
        private readonly RoomTypeController _roomTypeController;
        private readonly ApplicationUserController _applicationUserController;
        private PrintDocument printDocument = new PrintDocument();

        public RoomForm(RoomController roomController, RoomTypeController roomTypeController, ApplicationUserController applicationUserController)
        {
            _roomController = roomController;
            _roomTypeController = roomTypeController;
            printDocument.PrintPage += PrintDocument_PrintPage;
            printDocument.DefaultPageSettings.Landscape = true;
            _applicationUserController = applicationUserController;
            InitializeComponent();
            ApplyAuthorization();
        }

        private void ApplyAuthorization()
        {
            ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
            AuthorizationMiddleware.Protect(user, btnDelete, "SuperAdmin");
        }

        private void RoomsForm_Load(object sender, EventArgs e)
        {
            LoadData();
            this.roomTableAdapter.Fill(this.eSMART_HMSDBDataSet.Room);
        }

        public void LoadData()
        {
            dgvRooms.AutoGenerateColumns = false;
            try
            {
                var allRooms = _roomController.GetAllRooms();
                if (allRooms != null)
                {
                    foreach (var room in allRooms)
                    {
                        FormHelper.TryConvertStringToDecimal(room.Rate.ToString(), out decimal rate);
                        room.Rate = FormHelper.FormatNumberWithCommas(rate);
                    }

                    dgvRooms.DataSource = allRooms;
                    dgvRooms.CellFormatting += DataGridViewRooms_CellFormatting;
                    txtRoomCount.Text = allRooms.Count.ToString();
                    txtVacantRooms.Text = _roomController.GetAllRooms().Where(r => r.Status == RoomStatusEnum.Vacant.ToString()).Count().ToString();
                    txtReservedRooms.Text = _roomController.GetAllRooms().Where(r => r.Status == RoomStatusEnum.Reserved.ToString()).Count().ToString();
                }

                List<RoomType> roomType = _roomTypeController.GetAllRoomType();
                if (roomType != null)
                {
                    comboBox2.DataSource = roomType;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void DataGridViewRooms_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRooms.Columns[e.ColumnIndex].Name == "Status")
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

        private void addRoomBtn_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            AddRoomForm addRoomForm = serviceProvider.GetRequiredService<AddRoomForm>();
            if (addRoomForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRooms.SelectedRows.Count > 0)
                {
                    var row = dgvRooms.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();

                    using (ViewRoomForm viewGuestForm = new ViewRoomForm(id, _roomController))
                    {
                        if (viewGuestForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a customer to view.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void dgvRooms_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRooms.Rows[e.RowIndex];
                string roomId = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();

                using (EditRoomForm editRoomForm = new EditRoomForm(_roomController, _roomTypeController, roomId))
                {
                    if (editRoomForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRooms.SelectedRows.Count > 0)
                {
                    var result = MessageBox.Show("Are you sure you want to delete the selected rooms?\nIf you delete any room, its record including all orders tagged to such room will be added to the recycle bin as well.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvRooms.SelectedRows)
                        {
                            string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();
                            _roomController.DeleteRoom(id);
                        }
                        LoadData();
                        MessageBox.Show("Successfully deleted customer information", "Success", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a customer to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtSearch.Text);
            if (isNull == false)
            {
                List<RoomViewModel> searchedRooms = _roomController.SearchRoom(txtSearch.Text);
                if (searchedRooms != null)
                {
                    dgvRooms.DataSource = searchedRooms;
                }
            }
            else
            {
                LoadData();
            }
        }

        private void comboBox2_KeyUp(object sender, KeyEventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(comboBox2.Text);
            if (isNull == false)
            {
                List<RoomViewModel> filteredRooms = _roomController.SearchRoom(comboBox2.SelectedValue.ToString());
                if (filteredRooms != null)
                {
                    dgvRooms.DataSource = filteredRooms;
                }
            }
            else
            {
                LoadData();
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(comboBox1.Text);
            if (isNull == false)
            {
                List<RoomViewModel> filteredRooms = _roomController.FilterByStatus(comboBox1.Text);
                if (filteredRooms != null)
                {
                    if (filteredRooms.Count > 0)
                    {
                        foreach (var room in filteredRooms)
                        {
                            FormHelper.TryConvertStringToDecimal(room.Rate.ToString(), out decimal rate);
                            room.Rate = FormHelper.FormatNumberWithCommas(rate);
                        }

                        dgvRooms.DataSource = filteredRooms;
                    }
                    else
                    {
                        LoadData();
                    }
                }
            }
        }

        private void bntPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }


        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            PrintDataGridView(e);
        }

        private void PrintDataGridView(PrintPageEventArgs e)
        {
            int leftMargin = e.MarginBounds.Left;
            int topMargin = e.MarginBounds.Top;
            int rowCount = dgvRooms.Rows.Count;

            // Set font and brush for printing
            Font font = new Font("Arial", 9);
            SolidBrush brush = new SolidBrush(Color.Black);

            // Draw title
            string title = "Room List";
            Font titleFont = new Font("Arial", 20, FontStyle.Bold);
            e.Graphics.DrawString(title, titleFont, brush, e.MarginBounds.Left - 60, e.MarginBounds.Top - 50);

            // List of columns to print
            string[] columnsToPrint = { "dataGridViewTextBoxColumn1", "dataGridViewTextBoxColumn2", "dataGridViewTextBoxColumn3", "RoomTypeName", "dataGridViewTextBoxColumn6", "Status", "dataGridViewTextBoxColumn7", "dataGridViewTextBoxColumn8" };

            // Draw column headers
            topMargin += titleFont.Height;
            int colLeftMargin = leftMargin;
            foreach (string colName in columnsToPrint)
            {
                var col = dgvRooms.Columns[colName];
                if (col != null)
                {
                    e.Graphics.DrawString(col.HeaderText, font, brush, leftMargin, topMargin);
                    leftMargin += col.Width - 30;
                }
            }

            topMargin += font.Height;
            leftMargin = e.MarginBounds.Left;

            // Draw rows
            for (int i = 0; i < rowCount; i++)
            {
                foreach (string colName in columnsToPrint)
                {
                    var col = dgvRooms.Columns[colName];
                    if (col != null)
                    {
                        var cellValue = dgvRooms.Rows[i].Cells[colName].Value?.ToString() ?? "";
                        e.Graphics.DrawString(cellValue, font, brush, leftMargin, topMargin);
                        leftMargin += col.Width - 30;
                    }
                }
                topMargin += font.Height;
                leftMargin = e.MarginBounds.Left;
            }
        }
    }
}
