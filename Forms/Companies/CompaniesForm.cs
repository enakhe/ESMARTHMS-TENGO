using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Forms.Companies
{
    public partial class CompaniesForm : Form
    {
        public CompaniesForm()
        {
            InitializeComponent();
        }

        private void CompaniesForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }
    }
}
