using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.FormClasses
{
    public class RoundedButton : Button
    {
        public int BorderRadius { get; set; } = 20;
        public Color BorderColor { get; set; } = Color.Gray;
        public int BorderThickness { get; set; } = 2;

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            GraphicsPath path = new GraphicsPath();
            path.AddArc(new Rectangle(0, 0, BorderRadius, BorderRadius), 180, 90);
            path.AddArc(new Rectangle(Width - BorderRadius, 0, BorderRadius, BorderRadius), -90, 90);
            path.AddArc(new Rectangle(Width - BorderRadius, Height - BorderRadius, BorderRadius, BorderRadius), 0, 90);
            path.AddArc(new Rectangle(0, Height - BorderRadius, BorderRadius, BorderRadius), 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);

            using (Pen pen = new Pen(BorderColor, BorderThickness))
            {
                pevent.Graphics.DrawPath(pen, path);
            }

            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                pevent.Graphics.FillPath(brush, path);
            }

            TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
