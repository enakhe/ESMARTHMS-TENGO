using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.FrontDesk.Room
{
    public partial class AddAreaForm : Form
    {
        private readonly RoomController _roomController;
        public AddAreaForm(RoomController roomController)
        {
            _roomController = roomController;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtAreaName.Text, txtAreaNumber.Text);
            if (isNull)
            {
                MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                Domain.Entities.Area area = new Domain.Entities.Area()
                {
                    Id = Guid.NewGuid().ToString(),
                    AreaName = txtAreaName.Text,
                    AreaNo = txtAreaNumber.Text,
                    Remark = txtRemark.Text,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                };
                _roomController.AddArea(area);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
