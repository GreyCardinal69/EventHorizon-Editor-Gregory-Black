﻿using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static GameDatabase.Reusables;

namespace GameDatabase.Controls
{
    internal class AdvancedButton : Button
    {
        private Color _backgroundColor = DarkPrimary45;

        [DefaultValue( typeof( Color ), "45,45,45" )]
        public BorderStyle BorderStyle;

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
            if ( BorderStyle != BorderStyle.None )
            {
                using ( var pen = new Pen( BorderColor, 1 ) )
                    e.Graphics.DrawRectangle( pen,
                        ClientRectangle.Left, ClientRectangle.Top,
                        ClientRectangle.Width - 1, ClientRectangle.Height - 1 );
            }
        }
    }
}