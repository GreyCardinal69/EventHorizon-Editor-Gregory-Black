using EditorDatabase.Model;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GameDatabase.Controls
{
    public partial class VectorEditor : UserControl
    {
        private Color borderColor = Color.FromArgb( 45, 45, 45 );
        [DefaultValue( typeof( Color ), "45,45,45" )]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                if ( borderColor != value )
                {
                    borderColor = value;
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

        [Description( "Vector" ), Category( "Data" )]
        public Vector2 Value
        {
            get { return _vector; }
            set
            {
                _ignoreEvents = true;
                X.Value = ( decimal ) value.x;
                Y.Value = ( decimal ) value.y;
                _ignoreEvents = false;
                _vector = value;
            }
        }

        public event EventHandler ValueChanged;

        public VectorEditor()
        {
            InitializeComponent();
        }

        private Vector2 _vector;

        private void X_ValueChanged( object sender, System.EventArgs e )
        {
            if ( _ignoreEvents )
                return;

            UpdateData();
        }

        private void Y_ValueChanged( object sender, System.EventArgs e )
        {
            if ( _ignoreEvents )
                return;

            UpdateData();
        }

        private void UpdateData()
        {
            _vector.x = ( float ) X.Value;
            _vector.y = ( float ) Y.Value;

            ValueChanged?.Invoke( this, EventArgs.Empty );
        }

        private void VectorEditor_Load( object sender, EventArgs e )
        {
            X.MouseWheel += DisableMouseWheel;
            Y.MouseWheel += DisableMouseWheel;
        }

        private static void DisableMouseWheel( object sender, EventArgs args )
        {
            ( ( HandledMouseEventArgs ) args ).Handled = true;
        }

        private bool _ignoreEvents = false;
    }
}