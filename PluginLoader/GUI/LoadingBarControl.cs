using System.Drawing;
using System.Windows.Forms;

namespace avaness.PluginLoader.GUI
{
    public class LoadingBarControl : Control
    {
        private const float barWidth = 0.98f; // 98% of width
        private const float barHeight = 0.03f; // 3% of height
        private readonly RectangleF bar;

        public float BarValue = float.NaN;

        public LoadingBarControl(Size screenSize)
        {
            Size = screenSize;

            SizeF barSize = new SizeF(Size.Width * barWidth, Size.Height * barHeight);
            float padding = (1 - barWidth) * Size.Width * 0.5f;
            PointF barStart = new PointF(padding, Size.Height - barSize.Height - padding);
            bar = new RectangleF(barStart, barSize);

            AutoSize = false;

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, true);
            this.BackColor = Color.Transparent;
            Application.DoEvents();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!float.IsNaN(BarValue))
            {
                Graphics graphics = e.Graphics;
                graphics.FillRectangle(Brushes.Gray, bar);
                graphics.FillRectangle(Brushes.White, new RectangleF(bar.Location, new SizeF(bar.Width * BarValue, bar.Height)));
            }
        }
    }
}
