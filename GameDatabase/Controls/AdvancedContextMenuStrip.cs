using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GameDatabase.Controls
{
    internal class AdvancedContextMenuStrip : ContextMenuStrip
    {
        private Color _backgroundColor = Color.FromArgb( 45, 45, 45 );

        public AdvancedContextMenuStrip( IContainer container ) : base( container )
        {
        }

        [DefaultValue( typeof( Color ), "45,45,45" )]
        public Color BorderColor
        {
            get { return _backgroundColor; }
            set
            {
                if ( _backgroundColor != value )
                {
                    _backgroundColor = value;
                    Invalidate();
                }
            }
        }

        protected override void OnPaint( PaintEventArgs e )
        {
            base.OnPaint( e );

            using ( var pen = new Pen( BorderColor, 1 ) )
                e.Graphics.DrawRectangle( pen,
                    e.ClipRectangle.Left, e.ClipRectangle.Top,
                     e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1 );

        }
    }
}