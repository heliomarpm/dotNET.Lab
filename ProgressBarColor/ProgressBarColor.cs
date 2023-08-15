using System.Drawing;
using System.Windows.Forms;

namespace ProgressBarColor
{
    public class ProgressBarColor : ProgressBar
    {
        public ProgressBarColor()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        public Brush Color { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Color == null)
                Color = Brushes.Green;

            Rectangle rec = e.ClipRectangle;

            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);

            rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
            rec.Height = rec.Height - 4;
            e.Graphics.FillRectangle(Color, 2, 2, rec.Width, rec.Height);
        }
    }
}
