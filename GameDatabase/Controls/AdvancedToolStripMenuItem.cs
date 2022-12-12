﻿using System.Drawing;
using System.Windows.Forms;

namespace GameDatabase.Controls
{
    internal class AdvancedToolStripMenuItem : ToolStripMenuItem
    {
        private SolidBrush _blackBrush = new SolidBrush( Color.FromArgb( 65,65,65 ) );
        private SolidBrush _fontOrange = new SolidBrush( Color.FromArgb( 242, 188, 87 ) );

        public AdvancedToolStripMenuItem( string text ) : base( text )
        {
        }

        public AdvancedToolStripMenuItem()
        {
        }

        public bool UseBelow;

        protected override void OnPaint( PaintEventArgs e )
        {
            base.OnPaint( e );

            if ( UseBelow )
            {
                using ( var pen = new Pen( _fontOrange, 1 ) )
                    e.Graphics.DrawRectangle( pen,
                        e.ClipRectangle.Left, e.ClipRectangle.Top,
                           e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1 );
            }

            if ( this.Selected )
            {
                e.Graphics.FillRectangle( _fontOrange, e.ClipRectangle );

                Rectangle rect = e.ClipRectangle;
                rect.X += 34;
                rect.Width -= 34;

                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString( this.Text, this.Font, _blackBrush, rect, sf );
            }
        }
    }
}