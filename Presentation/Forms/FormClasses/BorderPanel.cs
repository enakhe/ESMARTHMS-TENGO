using System.Drawing;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.FormClasses
{
    public class BorderPanel : Panel
    {
        public bool DrawTopBorder { get; set; } = false;
        public bool DrawBottomBorder { get; set; } = true;
        public bool DrawLeftBorder { get; set; } = false;
        public bool DrawRightBorder { get; set; } = false;
        public int BorderThickness { get; set; } = 2;
        public Color BorderColor { get; set; } = Color.Gray;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen pen = new Pen(BorderColor, BorderThickness))
            {
                if (DrawTopBorder)
                {
                    e.Graphics.DrawLine(pen, 0, 0, this.Width, 0);
                }
                if (DrawBottomBorder)
                {
                    e.Graphics.DrawLine(pen, 0, this.Height - BorderThickness, this.Width, this.Height - BorderThickness);
                }
                if (DrawLeftBorder)
                {
                    e.Graphics.DrawLine(pen, 0, 0, 0, this.Height);
                }
                if (DrawRightBorder)
                {
                    e.Graphics.DrawLine(pen, this.Width - BorderThickness, 0, this.Width - BorderThickness, this.Height);
                }
            }
        }
    }
}
