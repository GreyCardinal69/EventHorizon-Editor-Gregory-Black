using System.Drawing;
using System.Windows.Forms;

namespace GameDatabase.Controls
{
    internal class AdvancedToolStripMenuItem : ToolStripMenuItem
    {
        private readonly SolidBrush _blackBrush = new SolidBrush(MainWindow.Accent);
        private readonly SolidBrush _fontOrange = new SolidBrush(MainWindow.FontColor);

        public AdvancedToolStripMenuItem(string text) : base(text)
        {
        }

        public AdvancedToolStripMenuItem()
        {
        }

        public bool UseBelow;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (UseBelow)
            {
                using (Pen pen = new Pen(_fontOrange, 1))
                    e.Graphics.DrawRectangle(pen,
                        e.ClipRectangle.Left, e.ClipRectangle.Top,
                           e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            }

            if (this.Selected)
            {
                e.Graphics.FillRectangle(_fontOrange, e.ClipRectangle);

                Rectangle rect = e.ClipRectangle;
                rect.X += 34;
                rect.Width -= 34;

                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(this.Text, this.Font, _blackBrush, rect, sf);
            }
        }
    }
}