using ESMART_HMS.Domain.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Report
{
    public partial class ExportsForm : Form
    {
        private readonly DataGridView _dataGridView;
        public ExportsForm(DataGridView dataGridView)
        {
            InitializeComponent();
            _dataGridView = dataGridView;
        }

        private void pictureExcel_Click(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtTitle.Text);
            if (isNull == false)
            {
                FormHelper.ExportDataGridViewToExcel(_dataGridView, txtTitle.Text);
            }
            else
            {
                MessageBox.Show($"Please provide the file name", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtTitle.Text);
            if (isNull == false)
            {
                FormHelper.ExportDataGridViewToPdf(_dataGridView, txtTitle.Text);
            }
            else
            {
                MessageBox.Show($"Please provide the file name", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
