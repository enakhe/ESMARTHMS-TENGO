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

namespace ESMART_HMS.Presentation.Forms.FrontDesk.Room.Area
{
    public partial class EditAreaForm : Form
    {
        private readonly RoomController _roomController;
        private readonly string _id;
        public EditAreaForm(RoomController roomController, string id)
        {
            _roomController = roomController;
            _id = id;
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                Domain.Entities.Area area = _roomController.GetAreaById(_id);
                if (area != null)
                {
                    txtAreaName.Text = area.AreaName;
                    txtAreaNumber.Text = area.AreaNo;
                    txtRemark.Text = area.Remark;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                bool isNull = FormHelper.AreAnyNullOrEmpty(txtAreaName.Text, txtAreaNumber.Text);
                if (isNull)
                {
                    MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                else
                {
                    Domain.Entities.Area area = _roomController.GetAreaById(_id);
                    if (area != null)
                    {
                        area.AreaName = txtAreaName.Text;
                        area.AreaNo = txtAreaNumber.Text;
                        area.Remark = txtRemark.Text;
                        area.DateModified = DateTime.Now;

                        _roomController.UpdateArea(area);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
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
