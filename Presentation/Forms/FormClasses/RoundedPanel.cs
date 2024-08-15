using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.FormClasses
{
    public class RoundedPanel : Panel
    {
        public int BorderRadius { get; set; } = 15;
        public int BorderThickness { get; set; } = 2;
        public Color BorderColor { get; set; } = Color.Gray;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(new Rectangle(0, 0, BorderRadius, BorderRadius), 180, 90);
                path.AddArc(new Rectangle(Width - BorderRadius, 0, BorderRadius, BorderRadius), -90, 90);
                path.AddArc(new Rectangle(Width - BorderRadius, Height - BorderRadius, BorderRadius, BorderRadius), 0, 90);
                path.AddArc(new Rectangle(0, Height - BorderRadius, BorderRadius, BorderRadius), 90, 90);
                path.CloseFigure();

                this.Region = new Region(path);

                using (Pen pen = new Pen(BorderColor, BorderThickness))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
    }
}
