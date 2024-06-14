using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Rooms
{
    public partial class ViewRoomForm : Form
    {
        private readonly RoomController _roomController;
        private readonly string _Id;
        public ViewRoomForm(string id, RoomController roomController)
        {
            InitializeComponent();
            _Id = id;
            _roomController = roomController;
            LoadRoomData();
        }

        private void LoadRoomData()
        {
            try
            {
                RoomViewModel room = _roomController.GetRoomById( _Id );
                if (room == null)
                {
                    MessageBox.Show("Customer not found", "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                else
                {
                    txtRoomId.Text = room.RoomId;
                    txtRoomNo.Text = room.RoomName;
                    txtRoomCard.Text = room.RoomCardNo;
                    txtRoomType.Text = room.RoomTypeName;
                    txtAdult.Text = room.AdultPerRoom.ToString();
                    txtChildren.Text = room.ChildrenPerRoom.ToString();
                    txtRate.Text = room.Rate.ToString();
                    txtAvailable.Text = room.IsAvailable.ToString();
                    txtDescription.Text = room.Description;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void ViewRoomForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var closeForm = MessageBox.Show("Are you sure you want to close this form?", "Confirm Closure", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (closeForm == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.DocumentName = txtRealRoomNo.Text;
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {

            try
            {
                RoomViewModel roomViewModel = _roomController.GetRoomById(_Id);
                if (roomViewModel == null)
                {
                    MessageBox.Show("Room not found", "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                else
                {
                    string roomId = roomViewModel.RoomId;
                    string roomNo = roomViewModel.RoomName;
                    string roomType = roomViewModel.RoomTypeName;
                    string adultPerRoom = roomViewModel.AdultPerRoom.ToString();
                    string childrenPerRoom = roomViewModel.ChildrenPerRoom.ToString();
                    string rate = roomViewModel.Rate.ToString();
                    string isAvailable = roomViewModel.IsAvailable.ToString();
                    string description = roomViewModel.Description;

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Room Details");
                    sb.AppendLine($"Room ID: {roomId}");
                    sb.AppendLine($"Room No: {roomNo}");
                    sb.AppendLine($"Room Type: {roomType}");
                    sb.AppendLine($"Adult Per Room: {adultPerRoom}");
                    sb.AppendLine($"Children Per Room: {childrenPerRoom}");
                    sb.AppendLine($"Rate: {rate}");
                    sb.AppendLine($"Availability: {isAvailable}");
                    sb.AppendLine($"Description: {description}");


                    e.Graphics.DrawString(sb.ToString(), new Font("Segeo UI", 12), Brushes.Black, new PointF(100, 100));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }
    }
}
