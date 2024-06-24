using ESMART_HMS.Domain.Utils;
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

namespace ESMART_HMS.Presentation.Forms.Reservation
{
    public partial class ReservationForm : Form
    {
        private readonly ReservationController _reservationController;
        public ReservationForm(ReservationController reservationController)
        {
            _reservationController = reservationController;
            InitializeComponent();
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var allReservations = _reservationController.GetAllReservation();
                if (allReservations != null)
                {
                    foreach (var reservation in allReservations)
                    {
                        FormHelper.TryConvertStringToDecimal(reservation.Amount, out decimal amount);
                        reservation.Amount = FormHelper.FormatNumberWithCommas(amount);
                    }

                    dgvReservation.DataSource = allReservations;
                    txtReservationCount.Text = allReservations.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void addReservationBtn_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            AddReservationForm addReservationForm = serviceProvider.GetRequiredService<AddReservationForm>();
            if (addReservationForm.ShowDialog() == DialogResult.OK)
            {
                RoomForm roomForm = serviceProvider.GetRequiredService<RoomForm>();
                LoadData();
                roomForm.LoadData();
            }
        }
    }
}
