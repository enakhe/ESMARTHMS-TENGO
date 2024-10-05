using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Report
{
    public partial class RoomReportForm : Form
    {
        private readonly RoomController _roomController;
        private readonly RoomTypeController _roomTypeController;
        public RoomReportForm(RoomController roomController, RoomTypeController roomTypeController)
        {
            _roomController = roomController;
            _roomTypeController = roomTypeController;
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            LoadData();
        }

        private void RoomReportForm_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvRooms.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvRooms.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
        }

        public void LoadData()
        {
            dgvRooms.AutoGenerateColumns = false;
            try
            {
                var allRooms = _roomController.GetAllRooms();
                var allRoomTypes = new List<RoomTypeViewModel>();
                var roomTypes = _roomTypeController.GetAllRoomType();

                if (roomTypes != null)
                {
                    RoomTypeViewModel all = new RoomTypeViewModel()
                    {
                        Id = "ALL",
                        RoomTypeId = "ALL",
                        Title = "ALL",
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                    };
                    allRoomTypes.Add(all);

                    foreach (var roomType in roomTypes)
                    {
                        allRoomTypes.Add(roomType);
                    }

                    txtType.DataSource = allRoomTypes;
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

        public void InitializeFlowPanel()
        {
            this.Load += (sender, e) => CenterFlowLayoutPanel(mainFlowLayoutPanel);
        }

        private void CenterFlowLayoutPanel(FlowLayoutPanel flowLayoutPanel)
        {
            int totalWidth = flowLayoutPanel.Controls.Cast<Control>().Sum(c => c.Width);
            int totalHeight = flowLayoutPanel.Controls.Cast<Control>().Sum(c => c.Height);

            int paddingX = (flowLayoutPanel.ClientSize.Width - totalWidth) / 2;
            int paddingY = (flowLayoutPanel.ClientSize.Height - totalHeight) / 2;

            flowLayoutPanel.Padding = new Padding(paddingX, paddingY, paddingX, paddingY);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportsForm exportForm = new ExportsForm(dgvRooms);
            exportForm.ShowDialog();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtStatus.SelectedItem.ToString(), txtType.SelectedValue.ToString());
            if (isNull == false)
            {
                var status = txtStatus.SelectedItem.ToString();
                var type = txtType.SelectedValue.ToString();

                if (type == "ALL" && status == "All")
                {
                    var allRooms = _roomController.GetAllRooms();
                    if (allRooms != null)
                    {
                        foreach (var room in allRooms)
                        {
                            FormHelper.TryConvertStringToDecimal(room.Rate.ToString(), out decimal rate);
                            room.Rate = FormHelper.FormatNumberWithCommas(rate);

                            room.DateCreated = FormHelper.FormatDateTimeWithSuffix(room.DateCreated);
                            room.DateModified = FormHelper.FormatDateTimeWithSuffix(room.DateModified);

                        }

                        dgvRooms.DataSource = allRooms;
                        dgvRooms.CellFormatting += DataGridViewRooms_CellFormatting;
                    }
                }
                else if (status == "All")
                {
                    List<RoomViewModel> roomByType = _roomController.FilterByType(type);
                    if (roomByType != null)
                    {
                        foreach (var room in roomByType)
                        {
                            FormHelper.TryConvertStringToDecimal(room.Rate.ToString(), out decimal rate);
                            room.Rate = FormHelper.FormatNumberWithCommas(rate);

                            room.DateCreated = FormHelper.FormatDateTimeWithSuffix(room.DateCreated);
                            room.DateModified = FormHelper.FormatDateTimeWithSuffix(room.DateModified);
                        }

                        dgvRooms.DataSource = roomByType;
                        dgvRooms.CellFormatting += DataGridViewRooms_CellFormatting;
                    }
                }
                else if (type == "ALL")
                {
                    List<RoomViewModel> roomByStatus = _roomController.FilterByStatus(status);
                    if (roomByStatus != null)
                    {
                        foreach (var room in roomByStatus)
                        {
                            FormHelper.TryConvertStringToDecimal(room.Rate.ToString(), out decimal rate);
                            room.Rate = FormHelper.FormatNumberWithCommas(rate);

                            room.DateCreated = FormHelper.FormatDateTimeWithSuffix(room.DateCreated);
                            room.DateModified = FormHelper.FormatDateTimeWithSuffix(room.DateModified);
                        }

                        dgvRooms.DataSource = roomByStatus;
                        dgvRooms.CellFormatting += DataGridViewRooms_CellFormatting;
                    }
                }
                else
                {
                    List<RoomViewModel> filteredRoom = _roomController.GetRoomByFilter(type, status);
                    if (filteredRoom != null)
                    {
                        foreach (var room in filteredRoom)
                        {
                            FormHelper.TryConvertStringToDecimal(room.Rate.ToString(), out decimal rate);
                            room.Rate = FormHelper.FormatNumberWithCommas(rate);

                            room.DateCreated = FormHelper.FormatDateTimeWithSuffix(room.DateCreated);
                            room.DateModified = FormHelper.FormatDateTimeWithSuffix(room.DateModified);
                        }

                        dgvRooms.DataSource = filteredRoom;
                        dgvRooms.CellFormatting += DataGridViewRooms_CellFormatting;
                    }
                }
            }
        }
    }
}
