using System.Drawing;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(200, 100);
            var label = new Label
            {
                Text = "Loading...",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(label);
        }
    }
}
