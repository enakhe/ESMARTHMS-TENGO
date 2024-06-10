using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Forms.RoomBooking
{
    public partial class RoomBookingForm : Form
    {
        public RoomBookingForm()
        {
            InitializeComponent();
        }

        private void RoomBookingForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }
    }
}
