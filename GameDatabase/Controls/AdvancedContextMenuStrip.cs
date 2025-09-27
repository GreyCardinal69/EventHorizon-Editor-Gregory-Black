using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GameDatabase.Controls
{
    internal class AdvancedContextMenuStrip : ContextMenuStrip
    {
        private Color _backgroundColor = MainWindow.BackgroundColor;

        public AdvancedContextMenuStrip(IContainer container) : base(container)
        {
        }

        public Color BorderColor
        {
            get { return _backgroundColor; }
            set
            {
                if (_backgroundColor != value)
                {
                    _backgroundColor = value;
                    Invalidate();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen pen = new Pen(BorderColor, 1))
                e.Graphics.DrawRectangle(pen,
                    e.ClipRectangle.Left, e.ClipRectangle.Top,
                     e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
        }
    }
}